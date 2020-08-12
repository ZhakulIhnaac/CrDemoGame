namespace Assets.Scripts.Constants
{
    internal static class GameDictionary
    {
        // Purpose of this dictionary is to standardize the text messages to be shown to the user.

        #region inGameTexts
        public const string YouWin = "You Win!";
        #endregion

        #region editorTexts
        public const string EnterLevelName = "Please enter a name for the level (Under LevelEditorSceneController, please find 'Level Name' on Inspector Panel.)";
        public const string PathAlreadyExists = "The name for the level is already exist.";
        #endregion

    }
}
