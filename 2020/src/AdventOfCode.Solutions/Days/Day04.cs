using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;

namespace PontusDacke.AdventOfCode2020.Solutions.Days
{
    class Day04 : Day
    {
        protected override long Part1()
        {
            var validPassports = 0;
            var passports = Input.Split("\n\n");
            foreach (var passport in passports)
            {
                var fields = new Dictionary<string, string>();
                var fieldSources = passport.Split(new char[] { ' ', '\n' }, StringSplitOptions.RemoveEmptyEntries);
                foreach (var fieldSource in fieldSources)
                {
                    var values = fieldSource.Split(':');
                    fields.Add(values[0], values[1]);
                }

                if (ContainsFields(fields))
                {
                    validPassports++;
                }
            }

            return validPassports;
        }


        protected override long Part2()
        {
            var validPassports = 0;
            var passports = Input.Split("\n\n");
            foreach (var passport in passports)
            {
                var fields = new Dictionary<string, string>();
                var fieldSources = passport.Split(new char[] { ' ', '\n' }, StringSplitOptions.RemoveEmptyEntries);
                foreach (var fieldSource in fieldSources)
                {
                    var values = fieldSource.Split(':');
                    fields.Add(values[0], values[1]);
                }

                if (ContainsFields(fields) && AreValidFields(fields))
                {
                    validPassports++;
                }
            }

            return validPassports;
        }

        private static bool ContainsFields(Dictionary<string, string> fields)
        {
            return fields.ContainsKey("byr")
                && fields.ContainsKey("iyr")
                && fields.ContainsKey("eyr")
                && fields.ContainsKey("hgt")
                && fields.ContainsKey("hcl")
                && fields.ContainsKey("ecl")
                && fields.ContainsKey("pid");
        }

        private static bool AreValidFields(Dictionary<string, string> fields)
        {
            return LengthFourAndBetweenXAndY(fields["byr"], 1920, 2002)
                && LengthFourAndBetweenXAndY(fields["iyr"], 2010, 2020)
                && LengthFourAndBetweenXAndY(fields["eyr"], 2020, 2030)
                 && ValidateHeight(fields["hgt"])
                 && ValidateHairColor(fields["hcl"])
                 && ValidateEyeColor(fields["ecl"])
                 && ValidatePassportId(fields["pid"]);
        }

        private static bool ValidatePassportId(string pid)
        {
            return pid.Length == 9 && pid.All(c => char.IsDigit(c));
        }

        private static bool ValidateEyeColor(string ecl)
        {
            return (ecl == "amb" || ecl == "blu" || ecl == "brn" || ecl == "gry" || ecl == "grn" || ecl == "hzl" || ecl == "oth");
        }

        private static bool ValidateHairColor(string hcl)
        {
            return hcl.StartsWith("#") && hcl.Length == 7 && hcl.Substring(1).All(c => char.IsDigit(c) || c >= 'a' && c <= 'f');
        }

        private static bool ValidateHeight(string hgt)
        {
            var hgtIsCm = hgt.EndsWith("cm");
            var hgtInt = int.Parse(Regex.Match(hgt, @"\d+").Value);
            return (hgtIsCm && hgtInt >= 150 && hgtInt <= 193 || !hgtIsCm && hgtInt >= 59 && hgtInt <= 76);
        }

        private static bool LengthFourAndBetweenXAndY(string field, int x, int y)
        {
            var fieldInt = int.Parse(field);
            return field.Length == 4 && fieldInt >= x && fieldInt <= y;
        }
    }
}
