﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Vizr.API
{
    public interface IResultProvider
    {
        /// <summary>
        /// Unique name of provider such as 'com.example.myprovider'
        /// </summary>
        string UniqueName { get; }

        /// <summary>
        /// Friendly name identifiable to the user
        /// </summary>
        string Name { get; }

        /// <summary>
        /// FontAwesome icon key to display on a result
        /// </summary>
        string Icon { get; }

        /// <summary>
        /// Called when the application is started
        /// </summary>
        void OnStart();

        /// <summary>
        /// Called when application is closed from the screen
        /// </summary>
        void OnExit();

        /// <summary>
        /// Called when user changes query text
        /// </summary>
        void OnQueryChange(string queryText);

        /// <summary>
        /// List of all IResults from this provider
        /// </summary>
        /// <param name="message">Search query from the user</param>
        /// <returns>List of IResult based on input <paramref name="message"/></returns>
        IEnumerable<IResult> Items { get; set; }
    }
}
