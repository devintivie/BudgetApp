using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BudgetApp.Managers
{
    public class DependencyManager
    {
        private static DependencyManager instance;

        public static DependencyManager Instance
        {
            get { return instance ?? (instance = new DependencyManager()); }
        }

        private DependencyManager() { }

        private static Dictionary<Type, Type> registeredDependecies = new Dictionary<Type, Type>();
        public int Count
        {
            get { return registeredDependecies.Count; }
        }

        public void ClearRegistrations()
        {
            registeredDependecies.Clear();
        }

        public void Register<S,T>() where S: class where T : class
        {
            if (!typeof(S).IsInterface) throw new ArgumentException("The S generic type parameter of the Register method must be an interface.", "S");
            if (!typeof(S).IsAssignableFrom(typeof(T))) throw new ArgumentException("The T generic type parameter must be a class that implements the interface specified by the S generic type parameter.", "T");
            if (!registeredDependecies.ContainsKey(typeof(S))) registeredDependecies.Add(typeof(S), typeof(T));
        }

        public T Resolve<T>() where T: class
        {
            Type type = registeredDependecies[typeof(T)];
            return Activator.CreateInstance(type) as T;
        }

        public T Resolve<T>(params object[] args) where T : class
        {
            Type type = registeredDependecies[typeof(T)];
            if (args == null || args.Length == 0) return Activator.CreateInstance(type) as T;
            else return Activator.CreateInstance(type, args) as T;
        }

    }
}
