﻿// --------------------------------------------------------------------------------------------------------------------
// <copyright file="CruncherCacheSection.cs" company="James South">
//   Copyright (c) James South.
//   Licensed under the Apache License, Version 2.0.
// </copyright>
// <summary>
//   Represents a CruncherCacheSection within a configuration file.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace Cruncher.Web.Configuration
{
    #region Using
    using System.Configuration;
    #endregion

    /// <summary>
    /// Represents a CruncherCacheSection within a configuration file.
    /// </summary>
    public class CruncherCacheSection : ConfigurationSection
    {
        #region Properties
        /// <summary>
        /// Gets or sets the maximum number of days to store a css or JavaScript resource in the cache.
        /// </summary>
        /// <value>The maximum number of days to store a css or JavaScript resource in the cache.</value>
        /// <remarks>Defaults to 365 if not set.</remarks>
        [ConfigurationProperty("maxDays", DefaultValue = "365", IsRequired = false)]
        [IntegerValidator(ExcludeRange = false, MinValue = 0)]
        public int MaxDays
        {
            get
            {
                return (int)this["maxDays"];
            }

            set
            {
                this["maxDays"] = value;
            }
        }
        #endregion

        #region Methods
        /// <summary>
        /// Retrieves the cache configuration section from the current application configuration. 
        /// </summary>
        /// <returns>The cache configuration section from the current application configuration.</returns>
        public static CruncherCacheSection GetConfiguration()
        {
            CruncherCacheSection clientResourcesCacheSection = ConfigurationManager.GetSection("cruncher/cache") as CruncherCacheSection;

            if (clientResourcesCacheSection != null)
            {
                return clientResourcesCacheSection;
            }

            return new CruncherCacheSection();
        }
        #endregion
    }
}
