using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Rock_Paper_Scissors_Battle_Royale {

    class NameSettings {

        public Dictionary<string, int> formatWeights = new Dictionary<string, int>() {
            {"English", 1},
            {"Japanese", 1},
            {"Japanese Syllables", 1},
            {"Chinese Syllables", 1}
        };
        public Dictionary<string, int[]> formatSyllables = new Dictionary<string, int[]>() {
            {"Japanese Syllables", new int[]{2, 6, 1, 9}},
            {"Chinese Syllables", new int[]{1, 4, 1, 3}},
        };

        // Probability chance of modifying name
        public double probabilitySuffix = 0.25;
    }

    public class NameLibrary {

        List<string> Localisations(string format, bool first) {
            switch (format) {
                case "English":
                    if (first) return namesFirst;
                    else return namesLast;
                case "Japanese":
                    if (first) return namesFirstJapanese;
                    else return namesLastJapanese;

                // Syllabkes
                case "Japanese Syllables":
                    return JapaneseSyllables;
                case "Chinese Syllables":
                    return ChineseSyllables;

            }

            return new List<string>();
        }

        // English
        readonly List<string> namesFirst = new List<string>() {
            // Male
            "John", "Frederick", "Jasper", "Calvin", "Connor",
            "Ernest", "Frank", "Tyler", "Damian", "Joaquin",
            "Felix", "Jason", "Albert", "Stephen", "Thomas",
            "Tom", "Alexander", "Nikola", "Henry",

            // Neutral
            "Adrian", "Taylor", "Robin",


            // Female
            "Jane", "Sophie", "Ellen", "Karen", "Claire",

            // Huniepop
            "Audrey", "Nikki",

            // Flowers
            "Rose", "Lavender", "Lily", "Poppy",

            // Seasons
            "Summer", "Autumn", "Winter", "Spring"
        };
        readonly List<string> namesLast = new List<string>() {
            // Generic
            "Bean", "Walker", "Jones",
            "Baker", "Smith", "Mason",

            // Chess
            "Kasparov", "Carlsen", "Fischer",

            // Piano
            "Beethoven", "Chopin", "Mozart", "Bach", "Debussy",
            "Grieg",

            // Inventors/Scientists
            "Edison", "Graham Bell", "Franklin", "Tesla", "Leibniz",
            "Wright", "da Vinci", "Ford", "Einstein", "Newton",
            "Morse", "Watt", "Archimedes", "Galilei", "Whitney",
            "Carver", "Marconi", "Babbage", "Watt", "Gates",
            "Jobs", "Faraday", "Nobel", "Diesel", "Fleming",
            "Braille", "Turing", "Volt", "Hawking",

            // Roman
            "Kaiser", "Caesar",

            // Fantasy - Celestial
            "Starlight", "Moondancer", "Dragonfire", "Whirlwind",

            // Leaders
            "Hitler", "Stalin", "Khan", "Kjellberg", "Trump",
            "bin Laden",

            // JoJo
            "Joestar", "Giovanna", "Cujoh",
        };

        // Japanese
        readonly List<string> namesFirstJapanese = new List<string>() {
            // Generic
            "Yamato", "Mikage", "Kamigahara", "Mio",

            // Sons
            "Ichiro", "Taro", "Shinichi", "Hajime",
            "Jiro", "Shinji", "Tsugio",
            "Saburo", "Shinzo", "Keizo",
            "Shiro",
            "Goro",
            "Rokuro",
            "Shichiro",
            "Hachiro",
            "Kuro",
            "Juro",

            // Daughters
            "Hatsuko",

            "Akiko",
            "Haruko", "Himawari",
            "Natsuko",
            "Fuuko", "Yukiko",

            // Female
            "Kirigiri", "Chiaki", "Kaede",
            "Fubuki",
        };
        readonly List<string> namesLastJapanese = new List<string>() {
            "Nadeshiko",

            "Kujo",

            // Danganronpa
            "Kyouko", "Nanami", "Akamatsu",

            // Cars
            "Toyota", "Honda", "Daihatsu",
            "Nissan", "Suzuki", "Mazda",
            "Mitsubishi", "Subaru", "Isuzu",
            "Kawasaki", "Yamaha", "Mitsuoka",

            // Yakuza
            "Kiryu", "Majima",

            // Animal
            "Inugami", "Nekoyama",

            // VTuber
            "Hoshimachi", "Suzuhara", "Usada", "Shirakami", "Natsuiro",
        };

        // Suffixes
        readonly List<string> nameSuffix = new List<string>() {
            // Classes
            "the Barbarian", "the Rogue", "the Mage",
            "the Greatshielder", "the Ranger", "the Spellblade",
            "the Paladin", "the Scout", "the Priest",

            // Chess
            "the Pawn",
            "the Knight", "the Bishop",
            "the Rook",
            "the Queen",
            "the King",

            // Edge
            "1337 D3$7R0Y3R", "The Destroyer of Worlds",

            // Weeb
            "Kawaii-licious", "Nekohime",

            // Job
            "Attorney at Law", "the Godfather"
        };

        // Syllables
        readonly List<string> JapaneseSyllables = new List<string>() {
            // Japanese Syllables
            "a", "i", "u", "e", "o",
            "ka", "ki", "ku", "ke", "ko",
            "ga", "gi", "gu", "ge", "go",
            "sa", "shi", "su", "se", "so",
            "za", "ji", "zu", "ze", "zo",
            "ta", "chi", "tsu", "te", "to",
            "da", "de", "do",
            "na", "ni", "nu", "ne", "no",
            "ha", "hi", "fu", "he", "ho",
            "ba", "bi", "bu", "be", "bo",
            "pa", "pi", "pu", "pe", "po",
            "ma", "mi", "mu", "me", "mo",
            "ya", "yu", "yo",
            "ra", "ri", "ru", "re", "ro",
            "wa", "wo", "n",
            "kya", "kyu", "kyo",
            "gya", "gyu", "gyo",
            "sha", "shu", "sho",
            "ja", "ju", "jo",
            "cha", "chu", "cho",
            "nya", "nyu", "nyo",
            "hya", "hyu", "hyo",
            "bya", "byu", "byo",
            "pya", "pyu", "pyo",
            "mya", "myu", "myo",
            "rya", "ryu", "ryo"
        };
        readonly List<string> ChineseSyllables = new List<string>() {
            "a", "ai", "an", "ang", "ao",
            "ba", "bai", "ban", "bang", "bao", "bei", "ben", "beng", "bi", "bian", "biang", "biao", "bie", "bin", "bing", "bo", "bu",
            "ca", "cai", "can", "cang", "cao", "ce", "cei", "cen", "ceng", "cha", "chai", "chan", "chang", "chao", "che", "chen", "cheng", "chi", "chong", "chou", "chu", "chua", "chuai", "chuan", "chuang", "chui", "chun", "chuo", "ci", "cong", "cou", "cu", "cuan", "cui", "cun", "cuo",
            "da", "dai", "dan", "dang", "dao", "de", "dei", "den", "deng", "di", "dian", "diao", "die", "ding", "diu", "dong", "dou", "du", "duan", "dui", "dun", "duo",
            "e", "ei", "en", "eng", "er",
            "fa", "fan", "fang", "fei", "fen", "feng", "fo", "fou", "fu",
            "ga", "gai", "gan", "gang", "gao", "ge", "gei", "gen", "geng", "gong", "gou", "gu", "gua", "guai", "guan", "guang", "gui", "gun", "guo",
            "ha", "hai", "han", "hang", "hao", "he", "hei", "hen", "heng", "hong", "hou", "hu", "hua", "huai", "huan", "huang", "hui", "hun", "huo",
            "ji", "jia", "jian", "jiang", "jiao", "jie", "jin", "jing", "jiong", "jiu", "ju", "juan", "jue", "jun",
            "ka", "kai", "kan", "kang", "kao", "ke", "kei", "ken", "keng", "kong", "kou", "ku", "kua", "kuai", "kuan", "kuang", "kui", "kun", "kuo",
            "la", "lai", "lan", "lang", "lao", "le", "lei", "leng", "li", "lia", "lian", "liang", "liao", "lie", "lin", "ling", "liu", "lo", "long", "lou", "lu", "luan", "lun", "luo", "lü", "lüe",
            "ma", "mai", "man", "mang", "mao", "me", "mei", "men", "meng", "mi", "mian", "miao", "mie", "min", "ming", "miu", "mo", "mou", "mu",
            "na", "nai", "nan", "nang", "nao", "ne", "nei", "nen", "neng", "ni", "nian", "niang", "niao", "nie", "nin", "ning", "niu", "nong", "nou", "nu", "nuan", "nuo", "nü", "nüe",
            "o", "ou",
            "pa", "pai", "pan", "pang", "pao", "pei", "pen", "peng", "pi", "pian", "piao", "pie", "pin", "ping", "po", "pou", "pu",
            "qi", "qia", "qian", "qiang", "qiao", "qie", "qin", "qing", "qiong", "qiu", "qu", "quan", "que", "qun",
            "ran", "rang", "rao", "re", "ren", "reng", "ri", "rong", "rou", "ru", "rua", "ruan", "rui", "run", "ruo",
            "sa", "sai", "san", "sang", "sao", "se", "sen", "seng", "sha", "shai", "shan", "shang", "shao", "she", "shei", "shen", "sheng", "shi", "shou", "shu", "shua", "shuai", "shuan", "shuang", "shui", "shun", "shuo", "si", "song", "sou", "su", "suan", "sui", "sun", "suo",
            "ta", "tai", "tan", "tang", "tao", "te", "teng", "ti", "tian", "tiao", "tie", "ting", "tong", "tou", "tu", "tuan", "tui", "tun", "tuo",
            "wa", "wai", "wan", "wang", "wei", "wen", "weng", "wo", "wu",
            "xi", "xia", "xian", "xiang", "xiao", "xie", "xin", "xing", "xiong", "xiu", "xu", "xuan", "xue", "xun",
            "ya", "yan", "yang", "yao", "ye", "yi", "yin", "ying", "yong", "you", "yu", "yuan", "yue", "yun",
            "za", "zai", "zan", "zang", "zao", "ze", "zei", "zen", "zeng", "zha", "zhai", "zhan", "zhang", "zhao", "zhe", "zhei", "zhen", "zheng", "zhi", "zhong", "zhou", "zhu", "zhua", "zhuai", "zhuan", "zhuang", "zhui", "zhun", "zhuo", "zi", "zong", "zou", "zu", "zuan", "zui", "zun", "zuo",

        };

        string WeightedNameFormat() {
            NameSettings settings = new NameSettings();
            Random rnd = new Random();

            int weights = 0;
            string selection = "";
            int randSelection = rnd.Next(settings.formatWeights.Count);

            foreach (KeyValuePair<string, int> format in settings.formatWeights) {
                if (randSelection < format.Value + weights) {
                    selection = format.Key;
                    break;
                }
                else {
                    weights += format.Value;
                }
            }

            return selection;
        }

        public string GetName() {
            Random rnd = new Random();
            NameSettings settings = new NameSettings();
            string format = WeightedNameFormat();
            string name = "";
            if (format == "English" ||
                format == "Japanese") { // Full Name Generator
                List<string> firstNames = Localisations(format, true);
                List<string> lastNames = Localisations(format, false);

                name = string.Join(" ", firstNames[rnd.Next(firstNames.Count)], lastNames[rnd.Next(lastNames.Count)]);
            }
            else if (format == "Japanese Syllables") { // Japanese Name Generator
                int[] syllableCounts = settings.formatSyllables[format];

                int firstNameSyllableCount = rnd.Next(syllableCounts[0], syllableCounts[1] + 1);
                int lastNameSyllableCount = rnd.Next(syllableCounts[2], syllableCounts[3] + 1);

                string firstName = "";
                string lastName = "";

                for (int i = 0; i < firstNameSyllableCount; i++) {
                    firstName += JapaneseSyllables[rnd.Next(JapaneseSyllables.Count)];
                }
                firstName = char.ToUpper(firstName[0]) + firstName.Substring(1);

                for (int i = 0; i < lastNameSyllableCount; i++) {
                    lastName += JapaneseSyllables[rnd.Next(JapaneseSyllables.Count)];
                }
                lastName = char.ToUpper(lastName[0]) + lastName.Substring(1);

                name = string.Concat(firstName, " ", lastName);
            }
            else if (format == "Chinese Syllables") {
                int[] syllableCounts = settings.formatSyllables[format];

                int firstNameSyllableCount = rnd.Next(syllableCounts[0], syllableCounts[1] + 1);
                int lastNameSyllableCount = rnd.Next(syllableCounts[2], syllableCounts[3] + 1);

                string firstName = "";
                string lastName = "";

                for (int i = 0; i < firstNameSyllableCount; i++) {
                    firstName += ChineseSyllables[rnd.Next(ChineseSyllables.Count)];
                }
                firstName = char.ToUpper(firstName[0]) + firstName.Substring(1);

                for (int i = 0; i < lastNameSyllableCount; i++) {
                    lastName += ChineseSyllables[rnd.Next(ChineseSyllables.Count)];
                }
                lastName = char.ToUpper(lastName[0]) + lastName.Substring(1);

                name = string.Concat(firstName, " ", lastName); return name;
            }

            // Suffix?
            if (rnd.NextDouble() < settings.probabilitySuffix) {
                name = string.Join(", ", name, nameSuffix[rnd.Next(nameSuffix.Count)]);
            }


            return name;
        }

    }
}
