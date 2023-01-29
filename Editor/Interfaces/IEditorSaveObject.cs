namespace Ikonoclast.Common.Editor
{
    public interface IEditorSaveObject : ISaveObject
    {
        /// <summary>
        /// Determines if the editor object is used.
        /// </summary>
        bool Enabled
        {
            get;
            set;
        }

        /// <summary>
        /// Reset the configuration to its default settings.
        /// </summary>
        void Reset();
    }
}
