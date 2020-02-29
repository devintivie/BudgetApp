using System;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media.Animation;

namespace BudgetApp
{
    public static class PageAnimations
    {
        /// <summary>
        /// Slides a page in from the right
        /// </summary>
        /// <param name="page">The page to animate</param>
        /// <param name="seconds">The time the animation will take to complete</param>
        /// <returns></returns>
        public static async Task SlideAndFadeInFromRight(this Page page, float seconds)
        {
            // Create the storyboard
            var sb = new Storyboard();


            // Add slide from right animation
            sb.AddSlideFromRight(seconds, page.WindowWidth);

            // Add fadeslide from right animation
            sb.AddFadeIn(seconds);

            //Start animating
            sb.Begin(page);

            // make page visible
            page.Visibility = Visibility.Visible;

            // Wait for it to finish
            await Task.Delay((int)(seconds * 1000));
        }

        /// <summary>
        /// Slides a page in from the right
        /// </summary>
        /// <param name="page">The page to animate</param>
        /// <param name="seconds">The time the animation will take to complete</param>
        /// <returns></returns>
        public static async Task SlideAndFadeOutToLeft(this Page page, float seconds)
        {
            // Create the storyboard
            var sb = new Storyboard();


            // Add slide from right animation
            sb.AddSlideToLeft(seconds, page.WindowWidth);

            // Add fadeslide from right animation
            sb.AddFadeOut(seconds);

            //Start animating
            sb.Begin(page);

            // make page visible
            page.Visibility = Visibility.Visible;

            // Wait for it to finish
            await Task.Delay((int)(seconds * 1000));
        }
    }
}
