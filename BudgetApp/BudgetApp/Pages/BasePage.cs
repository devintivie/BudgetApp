using IvieBaseClasses;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media.Animation;

namespace BudgetApp
{
    /// <summary>
    /// A base page for all pages to gain base functionality
    /// </summary>
    public class BasePage<VM> : Page
        where VM : BaseViewModel, new()
    {

        #region Private Member
        private VM viewModel;

        #endregion
        #region Public Properties
        /// <summary>
        /// The animation to play when the page is first loaded
        /// </summary>
        public PageAnimation PageLoadAnimation { get; set; } = PageAnimation.SlideAndFadeInFromRight;

        /// <summary>
        /// The animation to play when the page is unloaded
        /// </summary>
        public PageAnimation PageUnloadAnimation { get; set; } = PageAnimation.SlideAndFadeOutToLeft;


        /// <summary>
        /// The time any slide animation takes to complete
        /// </summary>
        public float SlideSeconds { get; set; } = 0.8f;


        /// <summary>
        /// The associated view model
        /// </summary>
        public VM ViewModel
        {
            get { return viewModel; }
            set
            {
                if (viewModel == value)
                {
                    return;
                }
                viewModel = value;
                this.DataContext = viewModel;
            }
        }

        #endregion

        #region Constructor
        public BasePage()
        {
            if (PageLoadAnimation != PageAnimation.None)
            {
                Visibility = Visibility.Collapsed;
            }
            // Listen out for the page loading
            Loaded += BasePage_Loaded;

            ViewModel = new VM();
        }

        #endregion

        #region Animation Load Unload
        /// <summary>
        /// Once the page is loaded, perform any required animation
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private async void BasePage_Loaded(object sender, System.Windows.RoutedEventArgs e)
        {
            await AnimateIn();
        }


        /// <summary>
        /// Animates the page in
        /// </summary>
        /// <returns></returns>
        public async Task AnimateIn()
        {
            if (PageLoadAnimation == PageAnimation.None)
            {
                return;
            }

            switch (PageLoadAnimation)
            {
                case PageAnimation.SlideAndFadeInFromRight:
                    //start the animations
                    await this.SlideAndFadeInFromRight(SlideSeconds);

                    break;
            }
        }

        /// <summary>
        /// Animate the page out
        /// </summary>
        /// <returns></returns>
        public async Task AnimateOut()
        {
            if (PageUnloadAnimation == PageAnimation.None)
            {
                return;
            }

            switch (PageUnloadAnimation)
            {
                case PageAnimation.SlideAndFadeOutToLeft:
                    //start the animations
                    await this.SlideAndFadeOutToLeft(SlideSeconds);

                    break;
            }
        }

        #endregion





    }
}
