using System;
using System.Collections.Generic;
using DataReceiving;
using Microsoft.Extensions.Logging;

namespace TextFileReceiver
{
    /// <summary>
    /// The data receiver from text file.
    /// </summary>
    public class TextStreamReceiver : IDataReceiver
    {
        private readonly string path;
        private readonly ILogger<TextStreamReceiver> logger;
        
        /// <summary>
        /// Initializes a new instance of the <see cref="TextStreamReceiver"/> class.
        /// </summary>
        /// <param name="path">The path to text file.</param>
        /// <param name="logger">The logger.</param>
        /// <exception cref="ArgumentException">Throw if text reader is null or empty.</exception>
        public TextStreamReceiver(string? path, ILogger<TextStreamReceiver>? logger = default)
        {
            if (string.IsNullOrEmpty(path))
            {
                throw new ArgumentException("Value cannot be null or empty.", nameof(path));
            }
            
            this.path = path;
            this.logger = logger ?? throw new ArgumentNullException(nameof(logger));
        }

        /// <summary>
        /// Receives lines from text reader.
        /// </summary>
        /// <returns>Strings.</returns>
        public IEnumerable<string> Receive()
        {
            using TextReader reader = new StreamReader(this.path);
            string? line;
            while ((line = reader.ReadLine()) is not null)
            {
                this.logger?.LogTrace("line {Line} received", line);
                yield return line;
            }
        }
    }
}
