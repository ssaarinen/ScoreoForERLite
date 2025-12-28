namespace ScoreoForERLite.Lib
{
    public sealed class ScoringFunctions
    {
        public const String CODE_IS_RESULT_NAME = "Code = points (default)";
        public static int CodeIsResultFunc(int code)
        {
            return code;
        }

        public static int ResultWithCapping(int result, int capAt)
        {
            
            return Math.Min(result, capAt);
        }

        public const String FIRST_NUMBER_NAME = "1st number = points";

        public static int FirstNumberIsResultFunc(int code)
        {
            // 38 => 3 , 45 => 4, 89 => 8, 131 => 13
            return code / 10;
        }

        public const String FIRST_NUMBER_WITH_10_POINT_CAP_NAME = "1st number = points (max 10)";
        public static int FirstNumberIsResultWith10PointCapFunc(int code)
        {
            return ResultWithCapping(FirstNumberIsResultFunc(code), 10);
        }

        public static Func<int, int> GetFunctionByName(string name)
        {
            return name switch
            {
                var n when n == CODE_IS_RESULT_NAME => CodeIsResultFunc,
                var n when n == FIRST_NUMBER_NAME => FirstNumberIsResultFunc,
                var n when n == FIRST_NUMBER_WITH_10_POINT_CAP_NAME => FirstNumberIsResultWith10PointCapFunc,
                _ => CodeIsResultFunc,
            };
        }

        public static List<string> GetAllFunctionNames()
        {
            return
            [
                CODE_IS_RESULT_NAME,
                FIRST_NUMBER_NAME,
                FIRST_NUMBER_WITH_10_POINT_CAP_NAME
            ];
        }

        public static Dictionary<int, int> GetControlsToPoints(String controlCodes, Func<int, int> scoringFunction)
        {
            var parts = controlCodes.Split(',', StringSplitOptions.RemoveEmptyEntries & StringSplitOptions.TrimEntries);
            return parts.Select(parts => parts.Split(":"))
                .Select(ParseCode)
                .Where(x => x.Success)
                .DistinctBy(x => x.Code)
                .ToDictionary(x => x.Code, x => x.Points ?? scoringFunction.Invoke(x.Code));

        }
        private static (bool Success, int Code, int? Points) ParseCode(string[] parts)
        {
            //parse string like 30:30 or 45 to (Success, code, points?)

            var codeParsed = int.TryParse(parts[0], out int code);
            var pointsParsed = int.TryParse(parts.ElementAtOrDefault(1), out int tryPoints);
            int? points = pointsParsed ? tryPoints : null;
            return (Success: codeParsed, Code: code, Points: points);



        }

    }
}
