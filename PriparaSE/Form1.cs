using System.Security;
using System.Linq;
using System.Diagnostics;

namespace PriparaSE
{
    public partial class Form1 : Form
    {
        Stream openedFile;
        MemoryStream workFile;
        SaveFile saveFile = new SaveFile();
        ListViewItem closetItem;
        WebBrowser webBrowser = new WebBrowser();
        public Form1()
        {
            InitializeComponent();
        }

         private void openToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (openFileDialog1.ShowDialog() == DialogResult.OK)
            {
                try
                {
                    using (openedFile = openFileDialog1.OpenFile())
                    {
                        listViewCloset.Items.Clear();
                        listViewEyeTypes.Items.Clear();
                        listViewSkinColor.Items.Clear();
                        listViewHairColor.Items.Clear();
                        listViewHairStyle.Items.Clear();
                        listViewEyeColor.Items.Clear();
                        listViewGlasses.Items.Clear();
                        listViewSongs.Items.Clear();
                        listViewCharacters.Items.Clear();
                        listViewTomotickets.Items.Clear();

                        workFile = new MemoryStream();
                        openedFile.Seek(0, SeekOrigin.Begin);
                        openedFile.CopyTo(workFile);

                        saveFile.mapSaveFile(openedFile);

                        saveFile.ClothCollections = saveFile.ClothCollections.OrderBy(x => x.id).ToList();
                        saveFile.EyeTypes = saveFile.EyeTypes.OrderBy(x => x.id).ToList();
                        saveFile.HairTypes = saveFile.HairTypes.OrderBy(x => x.id).ToList();
                        saveFile.SkinColors = saveFile.SkinColors.OrderBy(x => x.id).ToList();
                        saveFile.HairColors = saveFile.HairColors.OrderBy(x => x.id).ToList();
                        saveFile.EyeColors = saveFile.EyeColors.OrderBy(x => x.id).ToList();
                        saveFile.Glasses = saveFile.Glasses.OrderBy(x => x.id).ToList();
                        saveFile.MakeUps = saveFile.MakeUps.OrderBy(x => x.id).ToList();
                        saveFile.UnlockedSongs = saveFile.UnlockedSongs.OrderBy(x => x.id).ToList();
                        saveFile.UnlockedCharacters = saveFile.UnlockedCharacters.OrderBy(x => x.id).ToList();
                        saveFile.Tomotickets = saveFile.Tomotickets.OrderBy(x => x.id).ToList();

                        foreach (ClothCollection closet in saveFile.ClothCollections)
                        {
                            listViewCloset.Items.Add(new ListViewItem() { Text = closet.id.ToString() });
                        }
                        foreach (EyeType eyeType in saveFile.EyeTypes)
                        {
                            listViewEyeTypes.Items.Add(new ListViewItem() { Text = eyeType.id.ToString() });
                        }
                        foreach (HairType hairStyle in saveFile.HairTypes)
                        {
                            listViewHairStyle.Items.Add(new ListViewItem() { Text = hairStyle.id.ToString() });
                        }
                        foreach (SkinColor skinColor in saveFile.SkinColors)
                        {
                            listViewSkinColor.Items.Add(new ListViewItem() { Text = skinColor.id.ToString() });
                        }
                        foreach (HairColor hairColor in saveFile.HairColors)
                        {
                            listViewHairColor.Items.Add(new ListViewItem() { Text = hairColor.id.ToString() });
                        }
                        foreach (EyeColor eyeColor in saveFile.EyeColors)
                        {
                            listViewEyeColor.Items.Add(new ListViewItem() { Text = eyeColor.id.ToString() });
                        }
                        foreach (Glasses glasses in saveFile.Glasses)
                        {
                            listViewGlasses.Items.Add(new ListViewItem() { Text = glasses.id.ToString() });
                        }
                        foreach (MakeUp makeUp in saveFile.MakeUps)
                        {
                            listViewMakeUp.Items.Add(new ListViewItem() { Text = makeUp.id.ToString() });
                        }
                        foreach (UnlockedSong unlockedSong in saveFile.UnlockedSongs)
                        {
                            listViewSongs.Items.Add(new ListViewItem() { Text = unlockedSong.id.ToString() });
                        }
                        foreach (UnlockedCharacter unlockedCharacter in saveFile.UnlockedCharacters)
                        {
                            listViewCharacters.Items.Add(new ListViewItem() { Text = unlockedCharacter.id.ToString() });
                        }
                        foreach (Tomoticket tomoticket in saveFile.Tomotickets)
                        {
                            listViewTomotickets.Items.Add(new ListViewItem() { Text = tomoticket.id.ToString() });
                        }

                        moneyNbox.Value = saveFile.Misc.Money;
                        iineNbox.Value = saveFile.Misc.Iine;
                        musicVolNbox.Value = saveFile.MusicVol;
                        sfxVolNbox.Value = saveFile.SFXVol;
                        voiceVolNbox.Value = saveFile.VoiceVol;
                        voiceSetCbox.SelectedIndex = saveFile.VoiceSetting;
                        textSpdCbox.SelectedIndex = saveFile.TextSpeed;
                        joystickScmCbox.SelectedIndex = saveFile.JoystickScheme;

                        listBox1.SelectedIndex = 0;
                        mainTabs.Enabled = true;
                        saveAsToolStripMenuItem.Enabled = true;
                    }
                }

                catch (SecurityException ex)
                {
                    MessageBox.Show($"Security error.\n\nError message: {ex.Message}\n\n" +
                    $"Details:\n\n{ex.StackTrace}");
                }
            }
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            saveFile.VoiceSetting = voiceSetCbox.SelectedIndex;
        }

        private void groupBox3_Enter(object sender, EventArgs e)
        {

        }

        private void numericUpDown1_ValueChanged(object sender, EventArgs e)
        {
            saveFile.Misc.Money = Convert.ToInt32(moneyNbox.Value);
        }

        private void listBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            AvatarLoad(listBox1.SelectedIndex);
        }

        private void AvatarLoad(int index)
        {
            avatarName.Text = saveFile.Avatars[index].Name;
            eyeTypeNbox.Value = saveFile.Avatars[index].EyeType;
            skinColorNbox.Value = saveFile.Avatars[index].SkinColor;
            hairColorNbox.Value = saveFile.Avatars[index].HairColor;
            eyeColor.Value = saveFile.Avatars[index].EyeColor;
            glassesNbox.Value = saveFile.Avatars[index].Glass;
            makeUpNbox.Value = saveFile.Avatars[index].MakeUp;
            topNbox.Value = saveFile.Avatars[index].Top;
            bottomNbox.Value = saveFile.Avatars[index].Bottom;
            shootNbox.Value = saveFile.Avatars[index].Shoot;
            headNbox.Value = saveFile.Avatars[index].Head;

        }

        private void saveAsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (saveFileDialog1.ShowDialog() == DialogResult.OK)
            {
                try
                {
                    saveFile.ClothCollections = new List<ClothCollection>();
                    saveFile.EyeTypes = new List<EyeType>();
                    saveFile.HairTypes = new List<HairType>();
                    saveFile.SkinColors = new List<SkinColor>();
                    saveFile.HairColors = new List<HairColor>();
                    saveFile.EyeColors = new List<EyeColor>();
                    saveFile.Glasses = new List<Glasses>();
                    saveFile.MakeUps = new List<MakeUp>();
                    saveFile.UnlockedSongs = new List<UnlockedSong>();
                    saveFile.UnlockedCharacters = new List<UnlockedCharacter>();
                    saveFile.Tomotickets = new List<Tomoticket>();

                    foreach (ListViewItem item in listViewCloset.Items)
                    {
                        saveFile.ClothCollections.Add(new ClothCollection() { id = Convert.ToInt32(item.Text) });
                    }
                    foreach (ListViewItem item in listViewEyeTypes.Items)
                    {
                        saveFile.EyeTypes.Add(new EyeType() { id = Convert.ToInt32(item.Text) });
                    }
                    foreach (ListViewItem item in listViewHairStyle.Items)
                    {
                        saveFile.HairTypes.Add(new HairType() { id = Convert.ToInt32(item.Text) });
                    }
                    foreach (ListViewItem item in listViewSkinColor.Items)
                    {
                        saveFile.SkinColors.Add(new SkinColor() { id = Convert.ToInt32(item.Text) });
                    }
                    foreach (ListViewItem item in listViewHairColor.Items)
                    {
                        saveFile.HairColors.Add(new HairColor() { id = Convert.ToInt32(item.Text) });
                    }
                    foreach (ListViewItem item in listViewEyeColor.Items)
                    {
                        saveFile.EyeColors.Add(new EyeColor() { id = Convert.ToInt32(item.Text) });
                    }
                    foreach (ListViewItem item in listViewGlasses.Items)
                    {
                        saveFile.Glasses.Add(new Glasses() { id = Convert.ToInt32(item.Text) });
                    }
                    foreach (ListViewItem item in listViewMakeUp.Items)
                    {
                        saveFile.MakeUps.Add(new MakeUp() { id = Convert.ToInt32(item.Text) });
                    }
                    foreach (ListViewItem item in listViewSongs.Items)
                    {
                        saveFile.UnlockedSongs.Add(new UnlockedSong() { id = Convert.ToInt32(item.Text) });
                    }
                    foreach (ListViewItem item in listViewCharacters.Items)
                    {
                        saveFile.UnlockedCharacters.Add(new UnlockedCharacter() { id = Convert.ToInt32(item.Text) });
                    }
                    foreach (ListViewItem item in listViewTomotickets.Items)
                    {
                        saveFile.Tomotickets.Add(new Tomoticket() { id = Convert.ToInt32(item.Text) });
                    }

                    workFile = saveFile.injectSaveFile();
                    File.WriteAllBytes(saveFileDialog1.FileName, workFile.ToArray());
                }
                catch (SecurityException ex)
                {
                    MessageBox.Show($"Security error.\n\nError message: {ex.Message}\n\n" +
                    $"Details:\n\n{ex.StackTrace}");
                }
            }
        }

        private void iineNbox_ValueChanged(object sender, EventArgs e)
        {
            saveFile.Misc.Iine = Convert.ToInt32(iineNbox.Value);
        }

        private void musicVolNbox_ValueChanged(object sender, EventArgs e)
        {
            saveFile.MusicVol = Convert.ToInt32(musicVolNbox.Value);
        }

        private void sfxVolNbox_ValueChanged(object sender, EventArgs e)
        {
            saveFile.SFXVol = Convert.ToInt32(sfxVolNbox.Value);
        }

        private void voiceVolNbox_ValueChanged(object sender, EventArgs e)
        {
            saveFile.VoiceVol = Convert.ToInt32(voiceVolNbox.Value);
        }

        private void textSpdCbox_SelectedIndexChanged(object sender, EventArgs e)
        {
            saveFile.TextSpeed = textSpdCbox.SelectedIndex;
        }

        private void joystickScmCbox_SelectedIndexChanged(object sender, EventArgs e)
        {
            saveFile.JoystickScheme = joystickScmCbox.SelectedIndex;
        }

        private void avatarName_TextChanged(object sender, EventArgs e)
        {
            saveFile.Avatars[listBox1.SelectedIndex].Name = avatarName.Text;
        }

        private void eyeTypeNbox_ValueChanged(object sender, EventArgs e)
        {
            saveFile.Avatars[listBox1.SelectedIndex].EyeType = Convert.ToInt32(eyeTypeNbox.Value);
        }

        private void skinColorNbox_ValueChanged(object sender, EventArgs e)
        {
            saveFile.Avatars[listBox1.SelectedIndex].SkinColor = Convert.ToInt32(skinColorNbox.Value);
        }

        private void hairStyleNbox_ValueChanged(object sender, EventArgs e)
        {
            saveFile.Avatars[listBox1.SelectedIndex].HairStyle = Convert.ToInt32(hairStyleNbox.Value);
        }

        private void hairColorNbox_ValueChanged(object sender, EventArgs e)
        {
            saveFile.Avatars[listBox1.SelectedIndex].HairColor = Convert.ToInt32(hairColorNbox.Value);
        }

        private void eyeColor_ValueChanged(object sender, EventArgs e)
        {
            saveFile.Avatars[listBox1.SelectedIndex].EyeColor = Convert.ToInt32(eyeColor.Value);
        }

        private void glassesNbox_ValueChanged(object sender, EventArgs e)
        {
            saveFile.Avatars[listBox1.SelectedIndex].Glass = Convert.ToInt32(glassesNbox.Value);
        }

        private void makeUpNbox_ValueChanged(object sender, EventArgs e)
        {
            saveFile.Avatars[listBox1.SelectedIndex].MakeUp = Convert.ToInt32(makeUpNbox.Value);
        }

        private void topNbox_ValueChanged(object sender, EventArgs e)
        {
            saveFile.Avatars[listBox1.SelectedIndex].Top = Convert.ToInt32(topNbox.Value);
        }

        private void bottomNbox_ValueChanged(object sender, EventArgs e)
        {
            saveFile.Avatars[listBox1.SelectedIndex].Bottom = Convert.ToInt32(bottomNbox.Value);
        }

        private void shootNbox_ValueChanged(object sender, EventArgs e)
        {
            saveFile.Avatars[listBox1.SelectedIndex].Shoot = Convert.ToInt32(shootNbox.Value);
        }

        private void headNbox_ValueChanged(object sender, EventArgs e)
        {
            saveFile.Avatars[listBox1.SelectedIndex].Head = Convert.ToInt32(headNbox.Value);
        }

        private void button1_Click(object sender, EventArgs e)
        {
            listViewCloset.Items.Add(new ListViewItem() { Text = itemIdNbox.Value.ToString() });
        }

        private void button2_Click(object sender, EventArgs e)
        {
            foreach (ListViewItem item in listViewCloset.SelectedItems)
            {
                listViewCloset.Items.Remove(item);
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            int[] completeItemList = new int[] { 7000, 7001, 7002, 7003, 7004, 7005, 7006, 7007, 7008, 7009, 7010, 7011, 7012, 7013, 7014, 7100, 7101, 7102, 7103, 7104, 7105, 7106, 7107, 7108, 7110, 7112, 7113, 7200, 7201, 7202, 7203, 7204, 7205, 7206, 7207, 7208, 7209, 7210, 7211, 7212, 7300, 7301, 7302, 7303, 7304, 7305, 7306, 7307, 7308, 7309, 7310, 7311, 7313, 7314, 7315, 7316, 7317, 7318, 7319, 7320, 7321, 7400, 7401, 7402, 7403, 7404, 7405, 7406, 7407, 7408, 7409, 7410, 7411, 7412, 7413, 7414, 7415, 7416, 7418, 7419, 7420, 7422, 7423, 7500, 7501, 7502, 7503, 7504, 7505, 7506, 7507, 7508, 7509, 7510, 7512, 7513, 7514, 7515, 7516, 7518, 7522, 7600, 7602, 7603, 7604, 7605, 7606, 7607, 7608, 7611, 7700, 7701, 7702, 7703, 7704, 7705, 7706, 7707, 7708, 7710, 7711, 7713, 7715, 7800, 7801, 7802, 7803, 7804, 7805, 7806, 7807, 7808, 7809, 7811, 7812, 7813, 7814, 7815, 7816, 7818, 7819, 7820, 7822, 7823, 7824, 7900, 7901, 7902, 7903, 7905, 7907, 7908, 7909, 7910, 7911, 7912, 7913, 7914, 7915, 7916, 7917, 7918, 7919, 7921, 7923, 7924, 7925, 8000, 8001, 8002, 8003, 8004, 8005, 8006, 8007, 8008, 8009, 8010, 8011, 8012, 8013, 8100, 8101, 8102, 8103, 8104, 8105, 8106, 8107, 8108, 8109, 8110, 8111, 8112, 8115, 8116, 8117, 8200, 8201, 8202, 8203, 8204, 8205, 8206, 8207, 8208, 8209, 8300, 8301, 8302, 8303, 8304, 8305, 8306, 8307, 8308, 8309, 8310, 8313, 8314, 8315, 8316, 8317, 8400, 8401, 8402, 8403, 8404, 8405, 8407, 8408, 8409, 8410, 8411, 8412, 8413, 8414, 8415, 8416, 8417, 8418, 8422, 8423, 8424, 8425, 8500, 8501, 8502, 8503, 8505, 8506, 8507, 8508, 8509, 8510, 8600, 8601, 8602, 8603, 8605, 8700, 8701, 8702, 8703, 8705, 8706, 8707, 8800, 8801, 8802, 8803, 8804, 8805, 8807, 8808, 8810, 8812, 8813, 8900, 8901, 8902, 8903, 8905, 8906, 8908, 8911, 8913, 8915, 9000, 9001, 9002, 9003, 9004, 9005, 9006, 9007, 9008, 9009, 9010, 9011, 9012, 9100, 9101, 9102, 9103, 9104, 9107, 9108, 9200, 9201, 9202, 9203, 9204, 9205, 9206, 9207, 9208, 9209, 9210, 9300, 9301, 9302, 9303, 9304, 9305, 9306, 9307, 9308, 9311, 9312, 9315, 9316, 9317, 9318, 9400, 9401, 9402, 9403, 9404, 9405, 9406, 9407, 9408, 9410, 9412, 9414, 9416, 9417, 9500, 9501, 9502, 9504, 9505, 9506, 9507, 9600, 9603, 9604, 9605, 9608, 9611, 9612, 9700, 9701, 9702, 9704, 9705, 9706, 9707, 9800, 9801, 9802, 9803, 9804, 9805, 9806, 9808, 9809, 9810, 9813, 9814, 9900, 9901, 9902, 9903, 9904, 9905, 9906, 9907, 9908, 9909, 9910, 9911, 9912, 9913, 15000, 15100, 15101, 15102, 15103, 15200, 15300, 15301, 15302, 15303, 15304, 15400, 15401, 15500, 15501, 15502, 15503, 15504, 15700, 15701, 15702, 15800, 15802, 15803, 15804, 15900, 15901, 15902, 15903, 15904, 15905, 15906, 15907, 25001, 25002, 25003, 25012, 25089, 25090, 25159, 25167, 25168, 25169, 25170, 25171, 25172, 25173, 25174, 25175, 25186, 25198, 25199, 25200, 25201, 25206, 25207, 25250, 25251, 25252, 25253, 25273, 25274, 25275, 25282, 25283, 25284, 25285, 25286, 25287, 25288, 25289, 25290, 25291, 25292, 25294, 25295, 25309, 25310, 25313, 25314, 25315, 25320, 25391, 25392, 25393, 25394, 25395, 25396, 25397, 25398, 25399, 25400, 25404, 25405, 25406, 25420, 25451, 25452, 25453, 25454, 25455, 25456, 25498, 25499, 25500, 25505, 25506, 25507, 25508, 25509, 25510, 25511, 25512, 25513, 25514, 25515, 25516, 25517, 25518, 25519, 25520, 25521, 25522, 25572, 25573, 25574, 25575, 25576, 25618, 25619, 25620, 25650, 25651, 25652, 25677, 25678, 25679, 25706, 25707, 25708, 25734, 25735, 25736, 25749, 25750, 25751, 25752, 25753, 25754, 25797, 25798, 25809, 25810, 25811, 25812, 25843, 25845, 25947, 25948, 25949, 25950, 25951, 25952, 25979, 25980, 25981, 26004, 26005, 26006, 26019, 26020, 26021, 27000, 27009, 27010, 27011, 27012, 27013, 27016, 27017, 27023, 27031, 27032, 27034, 27038, 27039, 27040, 27041, 27048, 27059, 27060, 27062, 27075, 27076, 27086, 27089, 27090, 27091, 27096, 27098, 27110, 27115, 27118, 27132, 27135, 27136, 27155, 27159, 27160, 27162, 27163, 27164, 27199, 27200, 27209, 27220, 27225, 27334, 27335, 27336, 27337, 27338, 27339, 27340, 27341, 27378, 27379, 27380, 27381, 27382, 27383, 27384, 27385, 27386, 27387, 27388, 27389, 27426, 27427, 27428, 27429, 27471, 27472, 27473, 27474, 27479, 27480, 27481, 27482, 27526, 27527, 27528, 27533, 27534, 27535, 27536, 27537, 27538, 27539, 27540, 27541, 27685, 27686, 27687, 27692, 27693, 27694, 27695, 27696, 27697, 27698, 27699, 27700, 27701, 27702, 27703, 27704, 27736, 27737, 27738, 27784, 27785, 27786, 27787, 27862, 27863, 27864, 27865, 27870, 27871, 27872, 27873, 27950, 27951, 27952, 27953, 27954, 27955, 27956, 27957, 27958, 27959, 27960, 27961, 27965, 27966, 27967, 30035, 35005, 35006, 35007, 35008, 35018, 35019, 35020, 35021, 35029, 35030, 35031, 35032, 35033, 35034, 35051, 35052, 35053, 35054, 35059, 35060, 35061, 35062, 35063, 35064, 35065, 35066, 35067, 35068, 35071, 35072, 35073, 35074, 35100, 35101, 35102, 35103, 35104, 35105, 35109, 35110, 35111, 35113, 35114, 35115, 35116, 35117, 35118, 35119, 35120, 35121, 35122, 35123, 35124, 35125, 35126, 35130, 35131, 35133, 35134, 35137, 35138, 35139, 35140, 35141, 35142, 35144, 35146, 35148, 35150, 35151, 35153, 35154, 35156, 35158, 35159, 35160, 35161, 35166, 35167, 35168, 35198, 35199, 35206, 40100, 40101, 40102, 40103, 40104, 40105, 40106, 40109, 40110, 40111, 40112, 40113, 40120, 40121, 40122, 40123, 40124, 40125, 40126, 40127, 40128, 40129, 40132, 40137, 40138, 40139, 40143, 40144, 40145, 40146, 40149, 40150, 40151, 40152, 40153, 40155, 40156, 40158, 40159, 40160, 40161, 40162, 40163, 40164, 40165, 40166, 40168, 40169, 40170, 40175, 40178, 40180, 40181, 40182, 40183, 40184, 40185, 40186, 40191, 40192, 40193, 40194, 40195, 40196, 40197, 40198, 40206, 40210, 40215, 40216, 40217, 40219, 40220, 40222, 40223, 40224, 40226, 40227, 40228, 40229, 40230, 40240, 40244, 40245, 40248, 40249, 40250, 40251, 40252, 40253, 40254, 40255, 40256, 40257, 40258, 40259, 40260, 40261, 40264, 40265, 40266, 40268, 40269, 40270, 40271, 40272, 40274, 50000, 50001, 50002, 50003, 50004, 50005, 50006, 50007, 50008, 50009, 50010, 50011, 50012, 50013, 50014, 50015, 50016, 50017, 50018, 50019, 50020, 50029, 50030, 50031, 50032, 50033, 50034, 50035, 50036, 50037, 50038, 50039, 50040, 50041, 50042, 50043, 50044, 50045, 50046, 50047, 50048, 50049, 50050, 50051, 50052, 50053, 50055, 50056, 50074, 50075, 50076, 50077, 50078, 50079, 50080, 50081, 50082, 50083, 50084, 50085, 50086, 50087, 50088, 50089, 50091, 50092, 50093, 50094, 50095, 50096, 50097, 50098, 50099, 50100, 50101, 50102, 50103, 50104, 50105, 50106, 50107, 50108, 50109, 50110, 50111, 50112, 50113, 50114, 50115, 50116, 50117, 50118, 50123, 50124, 50200, 50201, 50202, 50203, 50204, 50205, 50208, 50209, 50210, 50211, 50212, 50213, 50225, 50226, 50227, 50228, 50229, 50230, 50231, 50232, 50233, 50234, 50235, 50236, 50238, 50239, 50240, 50241, 50242, 50243, 50244, 50245, 50246, 50247, 50248, 50249, 50250, 50251, 50252, 50253, 50260, 50261, 50262, 50263, 50264, 50265, 50266, 50267, 50268, 50269, 50270, 50271, 50278, 50279, 50280, 50281, 50282, 50283, 50284, 50285, 50286, 50300, 50301, 50302, 50303, 50304, 50305, 50312, 50313, 50314, 50315, 50316, 50317, 50318, 50319, 50320, 50321, 50322, 50323, 50324, 50325, 50328, 50329, 50330, 50331, 50332, 50333, 50334, 50335, 50336, 50337, 50338, 50339, 50340, 50341, 50342, 50343, 50344, 50345, 50346, 50347, 50348, 50351, 50352, 50353, 50354, 50355, 50356, 50357, 50358, 50359, 50360, 50361, 50362, 50363, 50364, 50365, 50372, 50373, 50374, 50375, 50376, 50377, 50378, 50379, 50380, 50381, 50382, 50383, 50393, 50394, 50395, 50396, 50397, 50398, 50399, 50401, 50405, 50406, 50407, 50408, 50409, 50410, 50411, 50412, 50413, 50414, 50415, 50416, 50417, 50436, 50437, 50438, 50439, 50440, 50441, 50442, 50443, 50444, 50448, 50449, 50450, 50454, 50455, 50456, 50482, 50483, 50484, 50485, 50486, 50487, 50488, 50489, 50490, 50491, 50492, 50493, 50494, 50495, 50496, 50497, 50498, 50499, 50500, 50501, 50505, 50506, 50507, 50529, 50530, 50531, 50532, 50533, 50534, 50535, 50536, 50537, 50538, 50539, 50540, 50541, 50542, 50543, 50544, 50545, 50546, 50547, 50548, 50549, 50559, 50560, 50561, 50562, 50563, 50564, 50565, 50566, 50567, 50568, 50569, 50570, 50571, 50572, 50573, 50574, 50575, 50600, 50601, 50602, 50603, 50604, 50605, 50606, 50607, 50608, 50609, 50610, 50611, 50612, 50622, 50623, 50624, 50625, 50626, 50627, 50628, 50629, 50637, 50638, 50639, 50640, 50651, 50652, 50654, 50655, 50656, 50657, 50658, 50659, 50660, 50661, 50700, 50701, 50702, 50703, 50707, 50708, 50709, 50710, 50713, 50714, 50715, 50716, 50717, 50718, 50719, 50720, 50721, 50722, 50723, 50724, 50725, 50726, 50727, 50728, 50729, 50730, 50731, 50732, 50733, 50734, 50735, 50736, 50737, 50738, 50739, 50740, 50741, 50742, 50815, 50816, 50817, 50818, 50819, 50820, 50821, 50822, 50823, 50824, 50825, 50826, 50851, 50852, 50853, 50854, 50855, 50860, 50861, 50862, 50863, 50871, 50872, 50873, 50874, 50900, 50901, 50902, 50903, 50904, 50905, 50906, 50907, 50908, 50909, 50910, 50918, 50919, 50920, 50921, 50922, 50923, 50924, 50925, 50926, 50927, 50928, 50929, 50930, 50931, 50932, 50939, 50940, 51006, 51007, 51008, 51009, 51010, 51014, 51015, 51022, 51023, 51030, 51031, 51032, 51033, 51034, 51035, 51036, 51037, 51038, 51039, 51040, 51041, 51042, 51043, 51044, 51045, 51046, 51047, 51048, 51049, 51050, 51051, 51052, 51053, 51054, 51055, 51062, 51063, 51064, 51065, 51066, 51067, 51068, 51069, 51070, 51071, 51074, 51075, 51082, 51083, 51084, 51085, 51086, 51087, 51088, 51089, 51090, 51091, 51092, 51093, 51500, 51501, 51502, 51503, 51504, 51505, 51506, 51507, 51508, 51509, 51510, 51511, 51512, 51513, 51514, 51515, 51516, 51517, 51518, 51519, 51520, 51521, 51562, 51563, 51564, 51565, 51566, 51567, 51568, 51569, 51570, 51571, 51572, 51573, 51574, 51575, 51576, 51577, 51578, 51579, 51580, 51581, 51582, 51583, 51584, 51585, 51586, 51587, 51588, 51589, 51590, 51591, 51599, 51600, 51601, 51700, 51701, 51702, 51703, 51704, 51705, 51706, 51707, 51708, 51709, 51710, 51711, 51712, 51713, 51714, 51715, 51716, 51717, 51718, 51719, 51720, 51721, 51722, 51723, 51724, 51725, 51726, 51727, 51728, 51729, 51730, 51731, 51732, 51741, 51742, 51743, 51744, 51745, 51746, 51747, 51748, 51749, 51750, 51751, 51770, 51771, 51772, 51773, 51774, 51775, 51776, 51777, 51778, 51779, 51780, 51785, 51786, 51787, 51788, 51789, 51790, 51791, 51792, 51793, 51815, 51816, 51817, 51818, 51822, 51823, 51824, 51900, 51901, 51902, 51903, 51904, 51905, 51906, 51907, 51908, 51909, 51910, 51911, 51912, 51913, 51914, 51915, 51916, 51917, 51918, 51919, 51920, 51921, 51922, 51923, 51924, 51925, 51926, 51927, 51928, 51929, 51930, 51931, 51932, 51933, 51934, 51935, 51936, 51937, 51938, 51939, 51940, 52000, 52001, 52002, 52003, 52004, 52005, 52006, 52007, 52008, 52009, 52010, 52011, 52016, 52017, 52018, 52019, 52020, 52021, 52022, 52023, 52029, 52030, 52031, 52032, 52033, 52034, 52035, 52036, 52037, 52038, 52039, 52040, 52041, 52042, 52043, 52044, 52045, 52046, 52047, 52070, 52071, 52072, 52073, 52074, 52075, 52076, 52077, 52078, 52079, 52080, 52081, 52082, 52083, 52084, 52089, 52090, 52091, 52092, 52093, 52094, 52095, 52096, 52097, 52098, 52099, 52100, 52201, 52202, 52203, 52204, 52205, 52206, 52207, 52208, 52209, 52210, 52211, 52212, 52213, 52214, 52215, 52216, 52217, 52218, 52219, 52220, 52221, 52222, 52223, 52224, 52233, 52234, 52235, 52236, 52237, 52238, 52239, 52240, 52241, 52242, 52243, 52248, 52249, 52250, 52251, 52266, 52267, 52268, 52269, 52270, 52271, 52272, 52273, 52274, 52275, 52276, 52277, 52278, 52279, 52280, 52281, 52282, 52283, 52284, 52285, 52286, 52287, 52288, 52289, 52290, 52291, 52292, 52293, 52294, 52295, 52296, 52297, 52400, 52401, 52402, 52403, 52404, 52405, 52406, 52407, 52408, 52409, 52410, 52411, 52412, 52413, 52414, 52415, 52416, 52417, 52418, 52419, 52420, 52421, 52422, 52423, 52424, 52425, 52426, 52427, 52428, 52433, 52434, 52435, 52436, 52437, 52438, 52439, 52440, 52441, 52442, 52443, 52444, 52445, 52446, 52467, 52468, 52469, 52470, 52471, 52472, 52473, 52474, 52475, 52476, 52477, 52478, 52479, 52480, 52481, 52490, 52491, 52492, 52493, 52494, 52495, 52496, 52497, 52498, 52499, 52500, 52501, 52502, 52503, 52512, 52513, 52514, 52515, 52550, 52551, 52552, 52553, 52554, 52555, 52556, 52557, 52558, 52559, 52560, 52561, 52562, 52563, 52564, 52565, 52566, 52567, 52568, 52569, 52570, 52571, 52572, 52573, 52574, 52575, 52576, 52577, 52578, 52579, 52580, 52581, 52582, 52583, 52584, 52585, 52586, 52587, 52588, 52589, 52590, 52591, 52592, 52593, 52594, 52595, 52596, 52625, 52626, 52627, 52628, 52629, 52630, 52631, 52632, 52633, 52634, 52635, 52636, 52637, 52638, 52639, 52640, 52641, 52642, 52643, 52644, 52645, 52646, 52647, 52648, 52649, 52650, 52651, 52652, 52653, 52654, 52655, 52656, 52657, 52658, 52659, 52660, 52661, 52662, 52663, 52664, 52665, 52666, 52667, 52668, 52669, 52670, 52671, 52700, 52701, 52702, 52703, 52704, 52705, 52706, 52707, 52708, 52709, 52710, 52711, 52712, 52713, 52714, 52715, 52720, 52721, 52722, 52723, 52732, 52733, 52734, 52735, 52736, 52737, 52738, 52739, 52740, 52741, 52742, 52775, 52776, 52777, 52786, 52787, 52788, 52789, 52794, 52795, 52796, 52797, 52798, 52799, 52800, 52801, 52827, 52828, 52829, 52830, 52850, 52851, 52852, 52853, 52854, 52855, 52856, 52857, 52858, 52859, 52860, 52861, 52862, 52863, 52864, 52865, 52866, 52867, 52868, 52869, 52870, 52871, 52872, 52873, 52874, 52875, 52876, 52877, 52878, 52879, 52880, 52881, 52882, 52883, 52884, 52885, 52886, 52887, 52888, 52889, 52890, 52891, 52892, 52901, 52902, 52903, 52904, 52905, 52906, 52907, 52925, 52926, 52927, 52928, 52929, 52930, 52931, 52932, 52933, 52934, 52935, 52936, 52937, 52938, 52939, 52940, 52941, 52942, 52943, 52944, 52945, 52946, 52955, 52956, 52957, 52958, 52959, 52960, 52961, 53000, 53001, 53002, 53003, 53004, 53005, 53006, 53007, 53008, 53009, 53010, 53011, 53012, 53013, 53014, 53015, 53016, 53017, 53018, 53019, 53020, 53021, 53022, 53023, 53024, 53025, 53026, 53027, 53028, 53029, 53030, 53031, 53032, 53033, 53034, 53035, 53036, 53037, 53038, 53039, 53040, 53041, 53042, 53043, 53044, 53045, 53057, 53058, 53059, 53080, 53081, 53082, 53083, 53084, 53085, 53086, 53087, 53088, 53089, 53090, 53091, 53092, 53093, 53094, 53095, 53096, 53097, 53098, 53099, 53100, 53101, 53102, 53103, 53104, 53105, 53106, 53107, 53108, 53109, 53110, 53111, 53112, 53113, 53114, 53115, 53119, 53120, 53121, 53122, 53133, 53134, 53135, 53136, 53137, 53138, 53139, 53140, 53200, 53201, 53202, 53203, 53204, 53205, 53206, 53207, 53208, 53209, 53210, 53211, 53212, 53213, 53214, 53215, 53216, 53217, 53218, 53219, 53220, 53221, 53222, 53223, 53224, 53225, 53226, 53227, 53228, 53229, 53230, 53231, 53232, 53233, 53234, 53235, 53236, 53237, 53238, 53239, 53240, 53241, 53242, 53243, 53244, 53245, 53258, 53259, 53260, 53261, 53266, 53267, 53268, 53276, 53277, 53278, 53279, 53280, 53281, 53282, 53283, 53284, 53285, 53292, 53293, 53294, 53295, 53296, 53297, 53298, 53299, 53300, 53301, 53302, 53303, 53304, 53305, 53306, 53307, 53308, 53309, 53310, 53311, 53312, 53313, 53318, 53319, 53320, 53321, 53334, 53335, 53336, 53350, 53351, 53352, 53353, 53354, 53355, 53356, 53357, 53358, 53359, 53360, 53361, 53362, 53363, 53364, 53365, 53366, 53367, 53368, 53369, 53370, 53371, 53372, 53373, 53374, 53375, 53376, 53377, 53378, 53379, 53380, 53381, 53382, 53464, 53465, 53466, 53467, 53475, 53476, 53477, 53478, 53500, 53501, 53502, 53503, 53504, 53505, 53506, 53507, 53508, 53509, 53510, 53511, 53512, 53513, 53514, 53515, 53516, 53521, 53522, 53523, 53524, 53525, 53526, 53531, 53532, 53533, 53534, 53542, 53543, 53544, 53545, 53570, 53571, 53572, 53573, 53574, 53575, 53576, 53577, 53578, 53579, 53596, 53597, 53598, 53599, 53600, 53601, 53602, 53603, 53644, 53645, 53646, 53647, 53648, 53649, 53650, 53651, 53652, 53653, 53654 };
            listViewCloset.Items.Clear();
            for (int i = 0; i < completeItemList.Length; i++)
            {
                listViewCloset.Items.Add(new ListViewItem() { Text = completeItemList[i].ToString() });
            }
        }

        private void exitToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void button4_Click(object sender, EventArgs e)
        {
            listViewEyeTypes.Items.Add(new ListViewItem() { Text = eyeTypeIdNbox.Value.ToString() });
        }

        private void button5_Click(object sender, EventArgs e)
        {
            foreach (ListViewItem item in listViewEyeTypes.SelectedItems)
            {
                listViewEyeTypes.Items.Remove(item);
            }
        }

        private void button9_Click(object sender, EventArgs e)
        {
            listViewHairStyle.Items.Add(new ListViewItem() { Text = hairStyleIdNbox.Value.ToString() });
        }

        private void button8_Click(object sender, EventArgs e)
        {
            foreach (ListViewItem item in listViewHairStyle.SelectedItems)
            {
                listViewHairStyle.Items.Remove(item);
            }
        }

        private void addSkinColorBtn_Click(object sender, EventArgs e)
        {
            listViewSkinColor.Items.Add(new ListViewItem() { Text = skinColorIdNbox.Value.ToString() });
        }

        private void removeSkinColorBtn_Click(object sender, EventArgs e)
        {
            foreach (ListViewItem item in listViewSkinColor.SelectedItems)
            {
                listViewSkinColor.Items.Remove(item);
            }
        }

        private void addHairColorBtn_Click(object sender, EventArgs e)
        {
            listViewHairColor.Items.Add(new ListViewItem() { Text = hairColorIdNbox.Value.ToString()});
        }

        private void removeHairColor_Click(object sender, EventArgs e)
        {
            foreach (ListViewItem item in listViewHairColor.SelectedItems)
            {
                listViewHairColor.Items.Remove(item);
            }
        }

        private void addEyeColorBtn_Click(object sender, EventArgs e)
        {
            listViewEyeColor.Items.Add(new ListViewItem() { Text = eyeColorIdNbox.Value.ToString() });
        }

        private void removeEyeColorBtn_Click(object sender, EventArgs e)
        {
            foreach (ListViewItem item in listViewEyeColor.SelectedItems)
            {
                listViewEyeColor.Items.Remove(item);
            }
        }

        private void addGlassesBtn_Click(object sender, EventArgs e)
        {
            listViewGlasses.Items.Add(new ListViewItem() { Text = glassesIdNbox.Value.ToString() });
        }

        private void removeGlassesBtn_Click(object sender, EventArgs e)
        {
            foreach (ListViewItem item in listViewGlasses.SelectedItems)
            {
                listViewGlasses.Items.Remove(item);
            }
        }

        private void addMakeUpBtn_Click(object sender, EventArgs e)
        {
            listViewMakeUp.Items.Add(new ListViewItem() { Text = makeUpIdNbox.Value.ToString() });
        }

        private void removeMakeUpBtn_Click(object sender, EventArgs e)
        {
            foreach (ListViewItem item in listViewMakeUp.SelectedItems)
            {
                listViewMakeUp.Items.Remove(item);
            }
        }

        private void addSongBtn_Click(object sender, EventArgs e)
        {
            listViewSongs.Items.Add(new ListViewItem() { Text = songsIdNbox.Value.ToString() });
        }

        private void removeSongsBtn_Click(object sender, EventArgs e)
        {
            foreach (ListViewItem item in listViewSongs.SelectedItems)
            {
                listViewSongs.Items.Remove(item);
            }
        }

        private void addCharacterBtn_Click(object sender, EventArgs e)
        {
            listViewCharacters.Items.Add(new ListViewItem() { Text = characterIdNbox.Value.ToString() });
        }

        private void removeCharacterBtn_Click(object sender, EventArgs e)
        {
            foreach (ListViewItem item in listViewCharacters.SelectedItems)
            {
                listViewCharacters.Items.Remove(item);
            }
        }

        private void addTomoticketsBtn_Click(object sender, EventArgs e)
        {
            listViewTomotickets.Items.Add(new ListViewItem() { Text = tomoticketsIdNbox.Value.ToString() });
        }

        private void removeTomoticketsBtn_Click(object sender, EventArgs e)
        {
            foreach (ListViewItem item in listViewTomotickets.SelectedItems)
            {
                listViewTomotickets.Items.Remove(item);
            }
        }

        private void infoSheetToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Process.Start(new ProcessStartInfo("https://docs.google.com/spreadsheets/d/1awtHVhl3M2Xf26nWuxNJnmrwOw1oJkXzoRBE6wUjFo4") { UseShellExecute = true });
        }

        private void donateToolStripMenuItem_Click_1(object sender, EventArgs e)
        {
            Process.Start(new ProcessStartInfo("https://www.buymeacoffee.com/bqsantana") { UseShellExecute = true });
        }
    }
}