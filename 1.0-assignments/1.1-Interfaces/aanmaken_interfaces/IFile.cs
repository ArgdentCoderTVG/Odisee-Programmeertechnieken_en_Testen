namespace aanmaken_interfaces
{
    /*1.2) Deze interface noem je IFile.*/
    public interface IFile
    {
        #region Interface_Read_File
        /* [»]OPGAVE[«] 1.1.a) Een interface die ervoor zorgt dat we tekst van een file kunnen inlezen*/

        /// <summary>
        /// Read the text from a provided file(path), which is local.
        /// </summary>
        /// <param name="filePathStatic">The static filepath to a provided file.</param>
        string ReadTextFromLocalOrigin(string filePathLocal);

        /// <summary>
        /// Read the text from a provided source(path), which is remote.
        /// This method ties into medium-agnostic methods that infer the protocol identifier, then communicates.
        /// </summary>
        /// <param name="destinationString">The stringified path (f.e. URL) to a provided source.</param>
        string ReadTextFromRemoteOrigin(string destinationString);
        #endregion

        #region Interface_Write_File
        /* [»]OPGAVE[«] 1.1.b) Een interface die ervoor zorgt dat we tekst van een file kunnen wegschrijven*/

        /// <summary>
        /// Writes the text to a provided file(path), which is local. (Creates one, if none is found at specified location)
        /// </summary>
        /// <param name="filePathStatic">The static filepath to a provided file.</param>
        void WriteTextToLocalOrigin(string text, string filePathLocal);

        /// <summary>
        /// Writes the text to a provided source(path), which is remote. (Creates one, if none is found at specified location)
        /// This method ties into medium-agnostic methods that infer the protocol identifier, then communicates.
        /// </summary>
        /// <param name="destinationString">The stringified path (f.e. URL) to a provided source.</param>
        void WriteTextToRemoteOrigin(string text, string destinationString);
        #endregion

        // Simple solution:
        /*
         * void ReadText( string filePath);
         * void WriteText(string tekst, string filePath);
        */
    }
}