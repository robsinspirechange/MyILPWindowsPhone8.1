﻿using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Controls.Primitives;
using Windows.UI.Xaml.Data;
using Windows.UI.Xaml.Input;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Media.Animation;
using Windows.UI.Xaml.Navigation;

// The Blank Page item template is documented at http://go.microsoft.com/fwlink/?LinkID=390556

namespace MyILP.Pages
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class TestPage : Page
    {
        public TestPage()
        {
            this.InitializeComponent();

            feedControl.FeedbackReceived += feedControl_FeedbackReceived;
            feedControl.FeedbackCancelled += feedControl_FeedbackCancelled;
        }

        void feedControl_FeedbackCancelled(Code.FeedbackObject feedbackObj)
        {
            string fdString = string.Format("Cancelled feedback for {0}\nCourse: {1}\n",
                feedbackObj.FacultyName, feedbackObj.CourseName);

#if DEBUG
            System.Diagnostics.Debug.WriteLine(fdString);
#endif        
        }

        void feedControl_FeedbackReceived(Code.FeedbackObject feedbackObj)
        {
            string fdString = string.Format("Received feedback for {0}\nCourse: {1}\nRating: {2}\nComments: {3}\n",
                feedbackObj.FacultyName, feedbackObj.CourseName, feedbackObj.Rating, feedbackObj.Comments);

#if DEBUG
            System.Diagnostics.Debug.WriteLine(fdString);
#endif
        }

        /// <summary>
        /// Invoked when this page is about to be displayed in a Frame.
        /// </summary>
        /// <param name="e">Event data that describes how this page was reached.
        /// This parameter is typically used to configure the page.</param>
        protected override void OnNavigatedTo(NavigationEventArgs e)
        {
            
        }

        private void btnGet_Click(object sender, RoutedEventArgs e)
        {
            feedControl.GetFeedback("Milind Gour", "Innovations");
        }
    }
}
