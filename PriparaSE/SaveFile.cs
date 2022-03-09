using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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

            for (int i = 0; i < (arrayLenght/2); i++)
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
    }
}
