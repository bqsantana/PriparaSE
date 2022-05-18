using System.Text;

namespace PriparaSE
{
    internal class SaveFile
    {
        public int Unknown_value_1 { get; set; }
        public int Unknown_value_2 { get; set; }
        public Misc Misc { get; set; }
        public List<UnlockedSongData> UnlockedSongDatas { get; set; }
        public List<UnlockedStory> UnlockedStories { get; set; }
        public int Unknown_value_3 { get; set; }
        public List<MissionCondition> MissionConditions { get; set; }
        public List<StorySection> StorySections { get; set; }
        public int Unknown_value_4 { get; set; }
        public List<Avatar> Avatars { get; set; }
        public List<ClothCollection> ClothCollections { get; set; }
        public List<UnlockedSong> UnlockedSongs { get; set; }
        public List<UnlockedCharacter> UnlockedCharacters { get; set; }
        public List<Tomoticket> Tomotickets { get; set; }
        public List<EyeType> EyeTypes { get; set; }
        public List<SkinColor> SkinColors { get; set; }
        public List<HairType> HairTypes { get; set; }
        public List<HairColor> HairColors { get; set; }
        public List<EyeColor> EyeColors { get; set; }
        public List<Glasses> Glasses { get; set; }
        public List<MakeUp> MakeUps { get; set; }
        public int Unknown_value_5 { get; set; }
        public int MusicVol { get; set; }
        public int SFXVol { get; set; }
        public int VoiceVol { get; set; }
        public int VoiceSetting { get; set; }
        public int TextSpeed { get; set; }
        public int JoystickScheme { get; set; }

        public void mapSaveFile(Stream str)
        {
            GetByteValue getByteValue = new GetByteValue();
            int offsetPositions = 0;
            int arrayLenght = 0;
            int[] valueArray;
            int incrementValue = 0;

            // UNKNOWN VALUES 1 2 //--------------------------------------------------------------

            Unknown_value_1 = getByteValue.ExtractByteToInt(str, offsetPositions, 4); offsetPositions = offsetPositions + 4;
            Unknown_value_2 = getByteValue.ExtractByteToInt(str, offsetPositions, 2); offsetPositions = offsetPositions + 2;

            // IINE & IDOL RANK //----------------------------------------------------------------

            Misc = new Misc();

            Misc.Iine = getByteValue.ExtractByteToInt(str, offsetPositions, 4); offsetPositions = offsetPositions + 4;
            Misc.IdolRank = getByteValue.ExtractByteToInt(str, offsetPositions, 4); offsetPositions = offsetPositions + 4;

            arrayLenght = getByteValue.ExtractByteToInt(str, offsetPositions, 4) * 2; offsetPositions = offsetPositions + 4;
            valueArray = getByteValue.ExtractBytetoIntArray(str, offsetPositions, 4, arrayLenght);

            // SONG DATA //-----------------------------------------------------------------------

            UnlockedSongDatas = new List<UnlockedSongData>();

            for (int i = 0; i < (arrayLenght / 2); i++)
            {
                UnlockedSongDatas.Add(new UnlockedSongData()
                {
                    id = valueArray[0 + incrementValue],
                    timesExecuted = valueArray[1 + incrementValue]
                });
                incrementValue = incrementValue + 2;
                offsetPositions = offsetPositions + 8;
            }

            arrayLenght = getByteValue.ExtractByteToInt(str, offsetPositions, 4); offsetPositions = offsetPositions + 4;
            valueArray = getByteValue.ExtractBytetoIntArray(str, offsetPositions, 4, arrayLenght);

            // UNLOCKED STORIES //----------------------------------------------------------------

            UnlockedStories = new List<UnlockedStory>();

            for (int i = 0; i < arrayLenght; i++)
            {
                UnlockedStories.Add(new UnlockedStory()
                {
                    id = valueArray[i]
                });
                offsetPositions = offsetPositions + 4;
            }

            arrayLenght = getByteValue.ExtractByteToInt(str, offsetPositions, 4); offsetPositions = offsetPositions + 4;
            valueArray = getByteValue.ExtractBytetoIntArray(str, offsetPositions, 4, arrayLenght);

            // MISSION CONDITIONS //--------------------------------------------------------------

            MissionConditions = new List<MissionCondition>();

            for (int i = 0; i < arrayLenght; i++)
            {
                MissionConditions.Add(new MissionCondition()
                {
                    value = valueArray[i]
                });
                offsetPositions = offsetPositions + 4;
            }

            // UNKNOWN VALUE 3 //------------------------------------------------------------------

            Unknown_value_3 = getByteValue.ExtractByteToInt(str, offsetPositions, 4); offsetPositions = offsetPositions + 4;

            arrayLenght = getByteValue.ExtractByteToInt(str, offsetPositions, 4) * 2; offsetPositions = offsetPositions + 4;
            valueArray = getByteValue.ExtractBytetoIntArray(str, offsetPositions, 4, arrayLenght);
            incrementValue = 0;

            // STORY SECTIONS //-------------------------------------------------------------------

            StorySections = new List<StorySection>();

            for (int i = 0; i < (arrayLenght / 2); i++)
            {
                StorySections.Add(new StorySection()
                {
                    id = valueArray[0 + incrementValue],
                    mission = valueArray[1 + incrementValue],
                });
                incrementValue = incrementValue + 2;
                offsetPositions = offsetPositions + 8;
            }

            // MONEY //----------------------------------------------------------------------------

            Misc.Money = getByteValue.ExtractByteToInt(str, offsetPositions, 4); offsetPositions = offsetPositions + 4;

            // UNKNOWN VALUE 4 //------------------------------------------------------------------

            Unknown_value_4 = getByteValue.ExtractByteToInt(str, offsetPositions, 4); offsetPositions = offsetPositions + 4;

            // AVATARS //--------------------------------------------------------------------------

            Avatars = new List<Avatar>();

            for (int i = 0; i < 6; i++)
            {
                arrayLenght = getByteValue.ExtractByteToInt(str, offsetPositions, 1); offsetPositions = offsetPositions + 1;
                Avatars.Add(new Avatar()
                {
                    Name = getByteValue.ExtractByteToString(str, offsetPositions, arrayLenght),
                    EyeType = getByteValue.ExtractByteToInt(str, offsetPositions + arrayLenght, 4),
                    SkinColor = getByteValue.ExtractByteToInt(str, offsetPositions + arrayLenght + 4, 4),
                    HairStyle = getByteValue.ExtractByteToInt(str, offsetPositions + arrayLenght + 8, 4),
                    HairColor = getByteValue.ExtractByteToInt(str, offsetPositions + arrayLenght + 12, 4),
                    EyeColor = getByteValue.ExtractByteToInt(str, offsetPositions + arrayLenght + 16, 4),
                    Glass = getByteValue.ExtractByteToInt(str, offsetPositions + arrayLenght + 20, 4),
                    MakeUp = getByteValue.ExtractByteToInt(str, offsetPositions + arrayLenght + 24, 4),
                    Top = getByteValue.ExtractByteToInt(str, offsetPositions + arrayLenght + 28, 4),
                    Bottom = getByteValue.ExtractByteToInt(str, offsetPositions + arrayLenght + 32, 4),
                    Shoot = getByteValue.ExtractByteToInt(str, offsetPositions + arrayLenght + 36, 4),
                    Head = getByteValue.ExtractByteToInt(str, offsetPositions + arrayLenght + 40, 4)
                });
                offsetPositions = offsetPositions + arrayLenght + 44;
            }

            arrayLenght = getByteValue.ExtractByteToInt(str, offsetPositions, 4); offsetPositions = offsetPositions + 4;
            valueArray = getByteValue.ExtractBytetoIntArray(str, offsetPositions, 4, arrayLenght);

            // CLOTH COLLECTION //------------------------------------------------------------------

            ClothCollections = new List<ClothCollection>();

            for (int i = 0; i < arrayLenght; i++)
            {
                ClothCollections.Add(new ClothCollection()
                {
                    id = valueArray[i]
                });
                offsetPositions = offsetPositions + 4;
            }

            arrayLenght = getByteValue.ExtractByteToInt(str, offsetPositions, 4); offsetPositions = offsetPositions + 4;
            valueArray = getByteValue.ExtractBytetoIntArray(str, offsetPositions, 4, arrayLenght);

            // UNLOCKED SONGS //-------------------------------------------------------------------

            UnlockedSongs = new List<UnlockedSong>();

            for (int i = 0; i < arrayLenght; i++)
            {
                UnlockedSongs.Add(new UnlockedSong()
                {
                    id = valueArray[i]
                });
                offsetPositions = offsetPositions + 4;
            }

            arrayLenght = getByteValue.ExtractByteToInt(str, offsetPositions, 4); offsetPositions = offsetPositions + 4;
            valueArray = getByteValue.ExtractBytetoIntArray(str, offsetPositions, 4, arrayLenght);

            // UNLOCKED CHARACTERS //--------------------------------------------------------------

            UnlockedCharacters = new List<UnlockedCharacter>();

            for (int i = 0; i < arrayLenght; i++)
            {
                UnlockedCharacters.Add(new UnlockedCharacter()
                {
                    id = valueArray[i]
                });
                offsetPositions = offsetPositions + 4;
            }

            arrayLenght = getByteValue.ExtractByteToInt(str, offsetPositions, 4); offsetPositions = offsetPositions + 4;
            valueArray = getByteValue.ExtractBytetoIntArray(str, offsetPositions, 4, arrayLenght);

            // UNLOCKED TOMOTICKETS //-------------------------------------------------------------

            Tomotickets = new List<Tomoticket>();

            for (int i = 0; i < arrayLenght; i++)
            {
                Tomotickets.Add(new Tomoticket()
                {
                    id = valueArray[i]
                });
                offsetPositions = offsetPositions + 4;
            }

            arrayLenght = getByteValue.ExtractByteToInt(str, offsetPositions, 4); offsetPositions = offsetPositions + 4;
            valueArray = getByteValue.ExtractBytetoIntArray(str, offsetPositions, 4, arrayLenght);

            // EYE TYPES //--------------------------------------------------------------

            EyeTypes = new List<EyeType>();

            for (int i = 0; i < arrayLenght; i++)
            {
                EyeTypes.Add(new EyeType()
                {
                    id = valueArray[i]
                });
                offsetPositions = offsetPositions + 4;
            }

            arrayLenght = getByteValue.ExtractByteToInt(str, offsetPositions, 4); offsetPositions = offsetPositions + 4;
            valueArray = getByteValue.ExtractBytetoIntArray(str, offsetPositions, 4, arrayLenght);

            // SKIN COLORS //------------------------------------------------------------

            SkinColors = new List<SkinColor>();

            for (int i = 0; i < arrayLenght; i++)
            {
                SkinColors.Add(new SkinColor()
                {
                    id = valueArray[i]
                });
                offsetPositions = offsetPositions + 4;
            }

            arrayLenght = getByteValue.ExtractByteToInt(str, offsetPositions, 4); offsetPositions = offsetPositions + 4;
            valueArray = getByteValue.ExtractBytetoIntArray(str, offsetPositions, 4, arrayLenght);

            // HAIR TYPES //-------------------------------------------------------------

            HairTypes = new List<HairType>();

            for (int i = 0; i < arrayLenght; i++)
            {
                HairTypes.Add(new HairType()
                {
                    id = valueArray[i]
                });
                offsetPositions = offsetPositions + 4;
            }

            arrayLenght = getByteValue.ExtractByteToInt(str, offsetPositions, 4); offsetPositions = offsetPositions + 4;
            valueArray = getByteValue.ExtractBytetoIntArray(str, offsetPositions, 4, arrayLenght);

            // HAIR COLORS //------------------------------------------------------------

            HairColors = new List<HairColor>();

            for (int i = 0; i < arrayLenght; i++)
            {
                HairColors.Add(new HairColor()
                {
                    id = valueArray[i]
                });
                offsetPositions = offsetPositions + 4;
            }

            arrayLenght = getByteValue.ExtractByteToInt(str, offsetPositions, 4); offsetPositions = offsetPositions + 4;
            valueArray = getByteValue.ExtractBytetoIntArray(str, offsetPositions, 4, arrayLenght);

            // EYE COLORS //-------------------------------------------------------------

            EyeColors = new List<EyeColor>();

            for (int i = 0; i < arrayLenght; i++)
            {
                EyeColors.Add(new EyeColor()
                {
                    id = valueArray[i]
                });
                offsetPositions = offsetPositions + 4;
            }

            arrayLenght = getByteValue.ExtractByteToInt(str, offsetPositions, 4); offsetPositions = offsetPositions + 4;
            valueArray = getByteValue.ExtractBytetoIntArray(str, offsetPositions, 4, arrayLenght);

            // GLASSES //-------------------------------------------------------------

            Glasses = new List<Glasses>();

            for (int i = 0; i < arrayLenght; i++)
            {
                Glasses.Add(new Glasses()
                {
                    id = valueArray[i]
                });
                offsetPositions = offsetPositions + 4;
            }

            arrayLenght = getByteValue.ExtractByteToInt(str, offsetPositions, 4); offsetPositions = offsetPositions + 4;
            valueArray = getByteValue.ExtractBytetoIntArray(str, offsetPositions, 4, arrayLenght);

            // MAKE UPS //--------------------------------------------------------------------

            MakeUps = new List<MakeUp>();

            for (int i = 0; i < arrayLenght; i++)
            {
                MakeUps.Add(new MakeUp()
                {
                    id = valueArray[i]
                });
                offsetPositions = offsetPositions + 4;
            }

            // UNKNOWN VALUE 5 //-------------------------------------------------------------

            Unknown_value_5 = getByteValue.ExtractByteToInt(str, offsetPositions, 2); offsetPositions = offsetPositions + 2;

            // SETTINGS //-------------------------------------------------------------

            MusicVol = getByteValue.ExtractByteToInt(str, offsetPositions, 4); offsetPositions = offsetPositions + 4;
            SFXVol = getByteValue.ExtractByteToInt(str, offsetPositions, 4); offsetPositions = offsetPositions + 4;
            VoiceVol = getByteValue.ExtractByteToInt(str, offsetPositions, 4); offsetPositions = offsetPositions + 4;
            VoiceSetting = getByteValue.ExtractByteToInt(str, offsetPositions, 4); offsetPositions = offsetPositions + 4;
            TextSpeed = getByteValue.ExtractByteToInt(str, offsetPositions, 4); offsetPositions = offsetPositions + 4;
            JoystickScheme = getByteValue.ExtractByteToInt(str, offsetPositions, 4); offsetPositions = offsetPositions + 4;
        }

        public MemoryStream injectSaveFile()
        {
            MemoryStream memoryStream = new MemoryStream();
            SetByteValue setByteValue = new SetByteValue();
            int offsetPositions = 0;
            int arrayLenght = 0;
            int[] valueArray;
            int incrementValue = 0;

            // UNKNOWN VALUES 1 2 //--------------------------------------------------------------

            //Unknown_value_1 = getByteValue.ExtractByteToInt(str, offsetPositions, 4); offsetPositions = offsetPositions + 4;
            memoryStream = setByteValue.InjectByteFromInt(memoryStream, Unknown_value_1, offsetPositions, 4); offsetPositions = offsetPositions + 4;
            //Unknown_value_2 = getByteValue.ExtractByteToInt(str, offsetPositions, 2); offsetPositions = offsetPositions + 2;
            memoryStream = setByteValue.InjectByteFromInt(memoryStream, Unknown_value_2, offsetPositions, 2); offsetPositions = offsetPositions + 2;

            // IINE & IDOL RANK //----------------------------------------------------------------

            //Misc.Iine = getByteValue.ExtractByteToInt(str, offsetPositions, 4); offsetPositions = offsetPositions + 4;
            memoryStream = setByteValue.InjectByteFromInt(memoryStream, Misc.Iine, offsetPositions, 4); offsetPositions = offsetPositions + 4;
            //Misc.IdolRank = getByteValue.ExtractByteToInt(str, offsetPositions, 4); offsetPositions = offsetPositions + 4;
            memoryStream = setByteValue.InjectByteFromInt(memoryStream, Misc.IdolRank, offsetPositions, 4); offsetPositions = offsetPositions + 4;

            // SONG DATA //-----------------------------------------------------------------------

            setByteValue.InjectByteFromInt(memoryStream, UnlockedSongDatas.Count, offsetPositions, 4); offsetPositions = offsetPositions + 4;

            for (int i = 0; i < UnlockedSongDatas.Count; i++)
            {
                setByteValue.InjectByteFromInt(memoryStream, UnlockedSongDatas[i].id, offsetPositions, 4); offsetPositions = offsetPositions + 4;
                setByteValue.InjectByteFromInt(memoryStream, UnlockedSongDatas[i].timesExecuted, offsetPositions, 4); offsetPositions = offsetPositions + 4;
            }

            // UNLOCKED STORIES //----------------------------------------------------------------

            setByteValue.InjectByteFromInt(memoryStream, UnlockedStories.Count, offsetPositions, 4); offsetPositions = offsetPositions + 4;

            for (int i = 0; i < UnlockedStories.Count; i++)
            {
                setByteValue.InjectByteFromInt(memoryStream, UnlockedStories[i].id, offsetPositions, 4); offsetPositions = offsetPositions + 4;
            }

            // MISSION CONDITIONS //--------------------------------------------------------------

            setByteValue.InjectByteFromInt(memoryStream, MissionConditions.Count, offsetPositions, 4); offsetPositions = offsetPositions + 4;

            for (int i = 0; i < MissionConditions.Count; i++)
            {
                setByteValue.InjectByteFromInt(memoryStream, MissionConditions[i].value, offsetPositions, 4); offsetPositions = offsetPositions + 4;
            }

            // UNKNOWN VALUE 3 //------------------------------------------------------------------

            setByteValue.InjectByteFromInt(memoryStream, Unknown_value_3, offsetPositions, 4); offsetPositions = offsetPositions + 4;

            // STORY SECTIONS //-------------------------------------------------------------------

            setByteValue.InjectByteFromInt(memoryStream, StorySections.Count, offsetPositions, 4); offsetPositions = offsetPositions + 4;

            for (int i = 0; i < StorySections.Count; i++)
            {
                setByteValue.InjectByteFromInt(memoryStream, StorySections[0].id, offsetPositions, 4); offsetPositions = offsetPositions + 4;
                setByteValue.InjectByteFromInt(memoryStream, StorySections[0].mission, offsetPositions, 4); offsetPositions = offsetPositions + 4;
            }

            // MONEY //----------------------------------------------------------------------------

            setByteValue.InjectByteFromInt(memoryStream, Misc.Money, offsetPositions, 4); offsetPositions = offsetPositions + 4;

            // UNKNOWN VALUE 4 //------------------------------------------------------------------

            setByteValue.InjectByteFromInt(memoryStream, Unknown_value_4, offsetPositions, 4); offsetPositions = offsetPositions + 4;

            // AVATARS //--------------------------------------------------------------------------

            for (int i = 0; i < 6; i++)
            {
                setByteValue.InjectByteFromInt(memoryStream, Encoding.UTF8.GetBytes(Avatars[i].Name).Length, offsetPositions, 1); offsetPositions = offsetPositions + 1;
                setByteValue.InjectByteFromString(memoryStream, Avatars[i].Name, offsetPositions, Encoding.UTF8.GetBytes(Avatars[i].Name).Length); offsetPositions = offsetPositions + Encoding.UTF8.GetBytes(Avatars[i].Name).Length;
                setByteValue.InjectByteFromInt(memoryStream, Avatars[i].EyeType, offsetPositions, 4); offsetPositions = offsetPositions + 4;
                setByteValue.InjectByteFromInt(memoryStream, Avatars[i].SkinColor, offsetPositions, 4); offsetPositions = offsetPositions + 4;
                setByteValue.InjectByteFromInt(memoryStream, Avatars[i].HairStyle, offsetPositions, 4); offsetPositions = offsetPositions + 4;
                setByteValue.InjectByteFromInt(memoryStream, Avatars[i].HairColor, offsetPositions, 4); offsetPositions = offsetPositions + 4;
                setByteValue.InjectByteFromInt(memoryStream, Avatars[i].EyeColor, offsetPositions, 4); offsetPositions = offsetPositions + 4;
                setByteValue.InjectByteFromInt(memoryStream, Avatars[i].Glass, offsetPositions, 4); offsetPositions = offsetPositions + 4;
                setByteValue.InjectByteFromInt(memoryStream, Avatars[i].MakeUp, offsetPositions, 4); offsetPositions = offsetPositions + 4;
                setByteValue.InjectByteFromInt(memoryStream, Avatars[i].Top, offsetPositions, 4); offsetPositions = offsetPositions + 4;
                setByteValue.InjectByteFromInt(memoryStream, Avatars[i].Bottom, offsetPositions, 4); offsetPositions = offsetPositions + 4;
                setByteValue.InjectByteFromInt(memoryStream, Avatars[i].Shoot, offsetPositions, 4); offsetPositions = offsetPositions + 4;
                setByteValue.InjectByteFromInt(memoryStream, Avatars[i].Head, offsetPositions, 4); offsetPositions = offsetPositions + 4;
            }

            // CLOTH COLLECTION //------------------------------------------------------------------

            setByteValue.InjectByteFromInt(memoryStream, ClothCollections.Count, offsetPositions, 4); offsetPositions = offsetPositions + 4;

            for (int i = 0; i < ClothCollections.Count; i++)
            {
                setByteValue.InjectByteFromInt(memoryStream, ClothCollections[i].id, offsetPositions, 4); offsetPositions = offsetPositions + 4;
            }

            // UNLOCKED SONGS //-------------------------------------------------------------------

            setByteValue.InjectByteFromInt(memoryStream, UnlockedSongs.Count, offsetPositions, 4); offsetPositions = offsetPositions + 4;

            for (int i = 0; i < UnlockedSongs.Count; i++)
            {
                setByteValue.InjectByteFromInt(memoryStream, UnlockedSongs[i].id, offsetPositions, 4); offsetPositions = offsetPositions + 4;
            }

            // UNLOCKED CHARACTERS //--------------------------------------------------------------

            setByteValue.InjectByteFromInt(memoryStream, UnlockedCharacters.Count, offsetPositions, 4); offsetPositions = offsetPositions + 4;

            for (int i = 0; i < UnlockedCharacters.Count; i++)
            {
                setByteValue.InjectByteFromInt(memoryStream, UnlockedCharacters[i].id, offsetPositions, 4); offsetPositions = offsetPositions + 4;
            }

            // UNLOCKED TOMOTICKETS //-------------------------------------------------------------

            setByteValue.InjectByteFromInt(memoryStream, Tomotickets.Count, offsetPositions, 4); offsetPositions = offsetPositions + 4;

            for (int i = 0; i < Tomotickets.Count; i++)
            {
                setByteValue.InjectByteFromInt(memoryStream, Tomotickets[i].id, offsetPositions, 4); offsetPositions = offsetPositions + 4;
            }

            // EYE TYPES //--------------------------------------------------------------

            setByteValue.InjectByteFromInt(memoryStream, EyeTypes.Count, offsetPositions, 4); offsetPositions = offsetPositions + 4;

            for (int i = 0; i < EyeTypes.Count; i++)
            {
                setByteValue.InjectByteFromInt(memoryStream, EyeTypes[i].id, offsetPositions, 4); offsetPositions = offsetPositions + 4;
            }

            // SKIN COLORS //------------------------------------------------------------

            setByteValue.InjectByteFromInt(memoryStream, SkinColors.Count, offsetPositions, 4); offsetPositions = offsetPositions + 4;

            for (int i = 0; i < SkinColors.Count; i++)
            {
                setByteValue.InjectByteFromInt(memoryStream, SkinColors[i].id, offsetPositions, 4); offsetPositions = offsetPositions + 4;
            }

            // HAIR TYPES //-------------------------------------------------------------

            setByteValue.InjectByteFromInt(memoryStream, HairTypes.Count, offsetPositions, 4); offsetPositions = offsetPositions + 4;

            for (int i = 0; i < HairTypes.Count; i++)
            {
                setByteValue.InjectByteFromInt(memoryStream, HairTypes[i].id, offsetPositions, 4); offsetPositions = offsetPositions + 4;
            }

            // HAIR COLORS //------------------------------------------------------------

            setByteValue.InjectByteFromInt(memoryStream, HairColors.Count, offsetPositions, 4); offsetPositions = offsetPositions + 4;

            for (int i = 0; i < HairColors.Count; i++)
            {
                setByteValue.InjectByteFromInt(memoryStream, HairColors[i].id, offsetPositions, 4); offsetPositions = offsetPositions + 4;
            }

            // EYE COLORS //-------------------------------------------------------------

            setByteValue.InjectByteFromInt(memoryStream, EyeColors.Count, offsetPositions, 4); offsetPositions = offsetPositions + 4;

            for (int i = 0; i < EyeColors.Count; i++)
            {
                setByteValue.InjectByteFromInt(memoryStream, EyeColors[i].id, offsetPositions, 4); offsetPositions = offsetPositions + 4;
            }

            // GLASSES //-------------------------------------------------------------

            setByteValue.InjectByteFromInt(memoryStream, Glasses.Count, offsetPositions, 4); offsetPositions = offsetPositions + 4;

            for (int i = 0; i < Glasses.Count; i++)
            {
                setByteValue.InjectByteFromInt(memoryStream, Glasses[i].id, offsetPositions, 4); offsetPositions = offsetPositions + 4;
            }

            // MAKE UPS //--------------------------------------------------------------------

            setByteValue.InjectByteFromInt(memoryStream, MakeUps.Count, offsetPositions, 4); offsetPositions = offsetPositions + 4;

            for (int i = 0; i < MakeUps.Count; i++)
            {
                setByteValue.InjectByteFromInt(memoryStream, MakeUps[i].id, offsetPositions, 4); offsetPositions = offsetPositions + 4;
            }

            // UNKNOWN VALUE 5 //-------------------------------------------------------------

            setByteValue.InjectByteFromInt(memoryStream, Unknown_value_5, offsetPositions, 2); offsetPositions = offsetPositions + 2;

            // SETTINGS //-------------------------------------------------------------

            //MusicVol = getByteValue.ExtractByteToInt(str, offsetPositions, 4); offsetPositions = offsetPositions + 4;
            setByteValue.InjectByteFromInt(memoryStream, MusicVol, offsetPositions, 4); offsetPositions = offsetPositions + 4;
            //SFXVol = getByteValue.ExtractByteToInt(str, offsetPositions, 4); offsetPositions = offsetPositions + 4;
            setByteValue.InjectByteFromInt(memoryStream, SFXVol, offsetPositions, 4); offsetPositions = offsetPositions + 4;
            //VoiceVol = getByteValue.ExtractByteToInt(str, offsetPositions, 4); offsetPositions = offsetPositions + 4;
            setByteValue.InjectByteFromInt(memoryStream, VoiceVol, offsetPositions, 4); offsetPositions = offsetPositions + 4;
            //VoiceSetting = getByteValue.ExtractByteToInt(str, offsetPositions, 4); offsetPositions = offsetPositions + 4;
            setByteValue.InjectByteFromInt(memoryStream, VoiceSetting, offsetPositions, 4); offsetPositions = offsetPositions + 4;
            //TextSpeed = getByteValue.ExtractByteToInt(str, offsetPositions, 4); offsetPositions = offsetPositions + 4;
            setByteValue.InjectByteFromInt(memoryStream, TextSpeed, offsetPositions, 4); offsetPositions = offsetPositions + 4;
            //JoystickScheme = getByteValue.ExtractByteToInt(str, offsetPositions, 4); offsetPositions = offsetPositions + 4;
            setByteValue.InjectByteFromInt(memoryStream, JoystickScheme, offsetPositions, 4); offsetPositions = offsetPositions + 4;

            memoryStream.SetLength(16355);

            return memoryStream;
        }
    }
}
