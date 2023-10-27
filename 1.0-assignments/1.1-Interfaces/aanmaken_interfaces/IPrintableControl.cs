namespace aanmaken_interfaces
{
    internal interface IPrintableOptionsControl
    {

        #region Interface_Method_PrintOptionsControl
        /* [»]OPGAVE[«] Interface die ervoor zorgt we checkboxen/radiobuttons kunnen printen op het scherm.*/
        void MapControlContentToDictionary(ref object targetControl, out Dictionary<string, string> dictLabelToValuePairs);
        void PrintOptionsControl(Dictionary<string, string> dictLabelToValuePairs);
        #endregion

        #region Interface_Method_Select
        /* [»]OPGAVE[«] 3.2.a) We verwachten hier een Select functie.*/

        /// <summary>
        /// A logo (in ByteArray form) for the enclosing notification; 
        /// versatile, but often in need of conversion before use.
        /// </summary>
        byte[] LogoByteArray { get; }
        #endregion

        #region Interface_Method_Deselect
        /* [»]OPGAVE[«] 3.2.b) We verwachten hier een Deselect functie.*/

        /// <summary>
        /// A logo (in ByteArray form) for the enclosing notification; 
        /// versatile, but often in need of conversion before use.
        /// </summary>
        byte[] LogoByteArray { get; }
        #endregion

        #region #region Interface_Prop_Selected
        /* [»]OPGAVE[«] 3.3) We willen ook weten of een item geselecteerd is of niet.*/

        /// <summary>
        /// A logo (in ByteArray form) for the enclosing notification; 
        /// versatile, but often in need of conversion before use.
        /// </summary>
        byte[] LogoByteArray { get; }
        #endregion
    }
}
