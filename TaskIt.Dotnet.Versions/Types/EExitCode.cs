﻿using System.Diagnostics.CodeAnalysis;

namespace TaskIt.Dotnet.Versions.Types
{
    /// <summary>
    /// Return codes
    /// </summary>
    [SuppressMessage("Naming", "CA1707:Identifiers should not contain underscores", Justification = "<Pending>")]
    public enum EExitCode
    {
        /// <summary>
        /// ok
        /// </summary>
        SUCCESS = 0,

        /// <summary>
        /// Parsing Error
        /// </summary>
        PARSE_ERROR = 1,

        /// <summary>
        /// invalid parameters
        /// </summary>
        INVALID_PARAMS = 2,

        /// <summary>
        /// invalid file
        /// </summary>
        INVALID_FILE = 3,

        /// <summary>
        /// general Error, any Excetion thrown
        /// </summary>
        GENERAL_ERROR = 4
    }
}
