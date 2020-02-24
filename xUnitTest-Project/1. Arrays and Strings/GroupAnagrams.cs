/*

Given an array of strings, group anagrams together.

Example:

Input: ["eat", "tea", "tan", "ate", "nat", "bat"],
Output:
[
  ["ate","eat","tea"],
  ["nat","tan"],
  ["bat"]
]
Note:

All inputs will be in lowercase.
The order of your output does not matter.

*/

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Xunit;

namespace xUnitTest_Project.ArraysandStrings
{
    public partial class Solution
    {
        public static IList<IList<string>> GroupAnagrams(string[] strs)
        {
            var lists = new List<IList<string>>();

            if (strs.Length == 0)
            {
                return lists;
            }

            for (int i = 0; i < strs.Length; i++)
            {
                if (!FoundAnagram1(strs[i], lists))
                {
                    lists.Add(new List<string>() { strs[i] });
                }
            }

            return lists;
        }

        private static bool FoundAnagram(string str, IList<IList<string>> lists)
        {
            for (int i = 0; i < lists.Count(); i++)
            {
                var tempString = lists[i].First();
                var tempCharArray = str.ToCharArray();

                if (tempString == "" && tempCharArray.Length > 0)
                {
                    return false;
                }
                else if (tempString == str)
                {
                    lists[i].Add(str);
                    return true;
                }

                if (tempString.Length == str.Length)
                {
                    for (int j = 0; j < tempCharArray.Length; j++)
                    {
                        int index = tempString.IndexOf(str.Substring(j, 1));
                        if (index > -1)
                        {
                            tempString = tempString.Remove(index, 1);
                        }
                    }

                    if (tempString.Length == 0)
                    {
                        lists[i].Add(str);
                        return true;
                    }
                }
            }

            return false;
        }

        private static bool FoundAnagram1(string str, IList<IList<string>> lists)
        {
            for (int i = 0; i < lists.Count(); i++)
            {
                //var tempString = SortString(lists[i].First());
                //var tempCharArray = SortString(str);

                var tempString = String.Concat(lists[i].First().OrderBy(c => c));
                var tempCharArray = String.Concat(str.OrderBy(c => c));

                if (tempString == tempCharArray)
                {
                    lists[i].Add(str);
                    return true;
                }

                if (tempString == "" && tempCharArray.Length > 0)
                {
                    return false;
                }
                else if (tempString == str)
                {
                    lists[i].Add(str);
                    return true;
                }
            }

            return false;
        }

        private static string SortString(string input)
        {
            char[] characters = input.ToArray();
            Array.Sort(characters);
            return new string(characters);
        }

        [Fact]
        public static void GroupAnagrams1()
        {
            var input = new string[] { "eat", "tea", "tan", "ate", "nat", "bat" };
            var expected = new List<IList<string>>();
            expected.Add(new List<string>() { "eat", "tea", "ate" });
            expected.Add(new List<string>() { "tan", "nat" });
            expected.Add(new List<string>() { "bat" });
            var result = GroupAnagrams(input);
            Assert.Equal(expected, result);
        }

        [Fact]
        public static void GroupAnagrams2()
        {
            var input = new string[] { "", "b" };
            var expected = new List<IList<string>>();
            expected.Add(new List<string>() { "" });
            expected.Add(new List<string>() { "b" });
            var result = GroupAnagrams(input);
            Assert.Equal(expected, result);
        }

        [Fact]
        public static void GroupAnagrams3()
        {
            var input = new string[] { "compilations", "bewailed", "horology", "lactated", "blindsided", "swoop", "foretasted", "ware", "abuts", "stepchild", "arriving", "magnet", "vacating", "relegates", "scale", "melodically", "proprietresses", "parties", "ambiguities", "bootblacks", "shipbuilders", "umping", "belittling", "lefty", "foremost", "bifocals", "moorish", "temblors", "edited", "hint", "serenest", "rendezvousing", "schoolmate", "fertilizers", "daiquiri", "starr", "federate", "rectal", "case", "kielbasas", "monogamous", "inflectional", "zapata", "permitted", "concessions", "easters", "communique", "angelica", "shepherdess", "jaundiced", "breaks", "raspy", "harpooned", "innocence", "craters", "cajun", "pueblos", "housetop", "traits", "bluejacket", "pete", "snots", "wagging", "tangling", "cheesecakes", "constructing", "balanchine", "paralyzed", "aftereffects", "dotingly", "definitions", "renovations", "surfboards", "lifework", "knacking", "apprises", "minimalism", "skyrocketed", "artworks", "instrumentals", "eardrums", "hunching", "codification", "vainglory", "clarendon", "peters", "weeknight", "statistics", "ay", "aureomycin", "lorrie", "compassed", "speccing", "galen", "concerto", "rocky", "derision", "exonerate", "sultrier", "mastoids", "repackage", "cyclical", "gowns", "regionalism", "supplementary", "bierce", "darby", "memorize", "songster", "biplane", "calibrates", "decriminalizes", "shack", "idleness", "confessions", "snippy", "barometer", "earthing", "sequence", "hastiness", "emitted", "superintends", "stockades", "busywork", "dvina", "aggravated", "furbelow", "hashish", "overextended", "foreordain", "lie", "insurance", "recollected", "interpreted", "congregate", "ranks", "juts", "dampen", "gaits", "eroticism", "neighborhoods", "perihelion", "simulations", "fumigating", "balkiest", "semite", "epicure", "heavier", "masterpiece", "bettering", "lizzie", "wail", "batsmen", "unbolt", "cudgeling", "bungalow", "behalves", "refurnishes", "pram", "spoonerisms", "cornered", "rises", "encroachments", "gabon", "cultivation", "parsed", "takeovers", "stampeded", "persia", "devotional", "doorbells", "psalms", "cains", "copulated", "archetypal", "cursores", "inbred", "paradigmatic", "thesauri", "rose", "stopcocks", "weakness", "ballsier", "jagiellon", "torches", "hover", "conservationists", "brightening", "dotted", "rodgers", "mandalay", "overjoying", "supervision", "gonads", "portage", "crap", "capers", "posy", "collateral", "funny", "garvey", "ravenously", "arias", "kirghiz", "elton", "gambolled", "highboy", "kneecaps", "southey", "etymology", "overeager", "numbers", "ebullience", "unseemly", "airbrushes", "excruciating", "gemstones", "juiciest", "muftis", "shadowing", "organically", "plume", "guppy", "obscurely", "clinker", "confederacies", "unhurried", "monastic", "witty", "breastbones", "ijsselmeer", "dublin", "linnaeus", "dervish", "bluefish", "selectric", "syllable", "pogroms", "pacesetters", "anastasia", "pandora", "foci", "bipartisan", "loomed", "emits", "gracious", "warfare", "uncouples", "augusts", "portray", "refinery", "resonances", "expediters", "deputations", "indubitably", "richly", "motivational", "gringo", "hubris", "mislay", "scad", "lambastes", "reemerged", "wart", "zirconium", "linus", "moussorgsky", "swopped", "sufferer", "sputtered", "tamed", "merrimack", "conglomerate", "blaspheme", "overcompensate", "rheas", "pares", "ranted", "prisoning", "rumor", "gabbles", "lummox", "lactated", "unzipping", "tirelessly", "backdate", "puzzling", "interject", "rejections", "bust", "centered", "oxymoron", "tangibles", "sejong", "not", "tameness", "consumings", "prostrated", "rowdyism", "ardent", "macabre", "rustics", "dodoes", "warheads", "wraths", "bournemouth", "staffers", "retold", "stiflings", "petrifaction", "larkspurs", "crunching", "clanks", "briefest", "clinches", "attaching", "extinguished", "ryder", "shiny", "antiqued", "gags", "assessments", "simulated", "dialed", "confesses", "livelongs", "dimensions", "lodgings", "cormorants", "canaries", "spineless", "widening", "chappaquiddick", "blurry", "lassa", "vilyui", "desertions", "trinket", "teamed", "bidets", "mods", "lessors", "impressiveness", "subjugated", "rumpuses", "swamies", "annotations", "batiks", "ratliff", "waxwork", "grander", "junta", "chutney", "exalted", "yawl", "joke", "vocational", "diabetic", "bullying", "edit", "losing", "banns", "doleful", "precision", "excreting", "foals", "smarten", "soliciting", "disturbance", "soggily", "gabrielle", "margret", "faded", "pane", "jerusalem", "bedpan", "overtaxed", "brigs", "honors", "repackage", "croissants", "kirov", "crummier", "limeades", "grandson", "criers", "bring", "jaundicing", "omnibusses", "gawking", "tonsillectomies", "deodorizer", "nosedove", "commence", "faulkner", "adultery", "shakedown", "wigwag", "wiper", "compatible", "ultra", "adamant", "distillation", "gestates", "semi", "inmate", "onlookers", "grudgingly", "recipe", "chaise", "dialectal", "aphids", "flimsier", "orgasm", "sobs", "swellheaded", "utilize", "karenina", "irreparably", "preteen", "mumble", "gingersnaps", "alumnus", "chummiest", "snobbish", "crawlspaces", "inappropriate", "ought", "continence", "hydrogenate", "eskimo", "desolated", "oceanic", "evasive", "sake", "laziest", "tramps", "joyridden", "acclimatized", "riffraff", "thanklessly", "harmonizing", "guinevere", "demanded", "capabler", "syphilitics", "brainteaser", "creamers", "upholds", "stiflings", "walt", "luau", "deafen", "concretely", "unhand", "animations", "map", "limbos", "tranquil", "windbreakers", "limoges", "varying", "declensions", "signs", "green", "snowbelt", "homosexual", "hopping", "residue", "ransacked", "emeritus", "pathologist", "brazenly", "forbiddingly", "alfredo", "glummest", "deciphered", "delusive", "repentant", "complainants", "beets", "syntactics", "vicissitude", "incompetents", "concur", "canaan", "rowdies", "streamer", "martinets", "shapeliness", "videodiscs", "restfulness", "rhea", "consumed", "pooching", "disenfranchisement", "impoverishes", "behalf", "unsuccessfully", "complicity", "ulcerating", "derisive", "jephthah", "clearing", "reputation", "kansan", "sledgehammer", "benchmarks", "escutcheon", "portfolios", "mandolins", "marketable", "megalomaniacs", "kinking", "bombarding", "wimple", "perishes", "rukeyser", "squatter", "coddle", "traditionalists", "sifts", "agglomerations", "seasonings", "brightness", "spices", "claimant", "sofas", "ambulatories", "bothered", "businessmen", "orly", "kinetic", "contracted", "grenadiers", "flooding", "dissolved", "corroboration", "mussed", "squareness", "alabamans", "dandelions", "labyrinthine", "pot", "waxwing", "residential", "pizza", "overjoying", "whelps", "overlaying", "elanor", "tented", "masterminded", "balsamed", "powerhouses", "tramps", "eisenstein", "voile", "repellents", "beaus", "coordinated", "wreckers", "eternities", "untwists", "estrangements", "vitreous", "embodied"};
            var expected = new List<IList<string>>();
            expected.Add(new List<string>() { "" });
            expected.Add(new List<string>() { "b" });
            var result = GroupAnagrams(input);
            Assert.Equal(expected, result);
        }
    }
}
