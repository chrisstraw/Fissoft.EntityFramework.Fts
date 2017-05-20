﻿using System;
using System.Text.RegularExpressions;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Fissoft.EntityFramework.Fts.Tests
{
    [TestClass]
    public class Issue5Test
    {
        [TestMethod]
        public void Match()
        {
            var text = "SELECT \r\n    [Extent1].[CreatedOn] AS [CreatedOn]\r\n    FROM  [dbo].[Ads] AS [Extent1]\r\n    LEFT OUTER JOIN [dbo].[Labels] AS [Extent2] ON [Extent1].[Label_Id] = [Extent2].[Id]\r\n    WHERE ((@p__linq__0 IS NULL) OR ( EXISTS (SELECT \r\n        1 AS [C1]\r\n        FROM  [dbo].[Encounters] AS [Extent3]\r\n        INNER JOIN [dbo].[AppUsers] AS [Extent4] ON [Extent3].[FacebookUser_Id] = [Extent4].[Id]\r\n        WHERE ([Extent3].[Ad_Id] = [Extent1].[Id]) AND ([Extent4].[Birthday] IS NOT NULL) AND ((DATEPART (year, [Extent4].[Birthday])) <= ((DATEPART (year, SysUtcDateTime())) - @p__linq__1))\r\n    ))) AND ((@p__linq__2 IS NULL) OR ( EXISTS (SELECT \r\n        1 AS [C1]\r\n        FROM  [dbo].[Encounters] AS [Extent5]\r\n        INNER JOIN [dbo].[AppUsers] AS [Extent6] ON [Extent5].[FacebookUser_Id] = [Extent6].[Id]\r\n        WHERE ([Extent5].[Ad_Id] = [Extent1].[Id]) AND ([Extent6].[Birthday] IS NOT NULL) AND ((DATEPART (year, [Extent6].[Birthday])) >= ((DATEPART (year, SysUtcDateTime())) - @p__linq__3))\r\n    ))) AND ((@p__linq__4 IS NULL) OR (( CAST(LEN(@p__linq__4) AS int)) = 0) OR ( EXISTS (SELECT \r\n        1 AS [C1]\r\n        FROM  [dbo].[Encounters] AS [Extent7]\r\n        LEFT OUTER JOIN [dbo].[AppUsers] AS [Extent8] ON [Extent7].[FacebookUser_Id] = [Extent8].[Id]\r\n        WHERE ([Extent7].[Ad_Id] = [Extent1].[Id]) AND (([Extent8].[Gender] = @p__linq__5) OR (([Extent8].[Gender] IS NULL) AND (@p__linq__5 IS NULL)))\r\n    ))) AND ((@p__linq__6 IS NULL) OR ([Extent1].[AvgLikesPerDay] > @p__linq__7)) AND ((@p__linq__8 IS NULL) OR ([Extent1].[TotalLikes] > @p__linq__9)) AND ((@p__linq__10 IS NULL) OR ( EXISTS (SELECT \r\n        1 AS [C1]\r\n        FROM  [dbo].[Encounters] AS [Extent9]\r\n        LEFT OUTER JOIN [dbo].[AppUsers] AS [Extent10] ON [Extent9].[FacebookUser_Id] = [Extent10].[Id]\r\n        WHERE ([Extent9].[Ad_Id] = [Extent1].[Id]) AND (([Extent10].[Country] = @p__linq__11) OR (([Extent10].[Country] IS NULL) AND (@p__linq__11 IS NULL)))\r\n    ))) AND ((@p__linq__12 IS NULL) OR ([Extent2].[LabelName] = @p__linq__13) OR (([Extent2].[LabelName] IS NULL) AND (@p__linq__13 IS NULL))) AND ((@p__linq__14 IS NULL) OR ( EXISTS (SELECT \r\n        1 AS [C1]\r\n        FROM [dbo].[AdActors] AS [Extent11]\r\n        WHERE ([Extent1].[Id] = [Extent11].[Ad_Id]) AND ([Extent11].[Actor_Id] = @p__linq__15)\r\n    ))) AND ((@p__linq__16 IS NULL) OR ((N'video' = @p__linq__17) AND ( EXISTS (SELECT \r\n        1 AS [C1]\r\n        FROM [dbo].[Media] AS [Extent12]\r\n        WHERE ([Extent1].[Id] = [Extent12].[Ad_Id]) AND (([Extent12].[Type] = @p__linq__18) OR (([Extent12].[Type] IS NULL) AND (@p__linq__18 IS NULL)))\r\n    ))) OR (( NOT ((N'video' = @p__linq__19) AND (@p__linq__19 IS NOT NULL))) AND ( NOT EXISTS (SELECT \r\n        1 AS [C1]\r\n        FROM [dbo].[Media] AS [Extent13]\r\n        WHERE ([Extent1].[Id] = [Extent13].[Ad_Id]) AND ((N'video' = [Extent13].[Type]) OR (CASE WHEN ( NOT ((N'video' = [Extent13].[Type]) AND ([Extent13].[Type] IS NOT NULL))) THEN cast(1 as bit) WHEN (N'video' = [Extent13].[Type]) THEN cast(0 as bit) END IS NULL))\r\n    )))) AND ((@p__linq__20 IS NULL) OR ((@p__linq__21 IS NULL) AND (([Extent1].[Text] LIKE @p__linq__22 ESCAPE N'~') OR ([Extent1].[AttachedText] LIKE @p__linq__23 ESCAPE N'~') OR ([Extent1].[MediaTexts] LIKE @p__linq__24 ESCAPE N'~') OR ([Extent1].[Urls] LIKE @p__linq__25 ESCAPE N'~') OR ([Extent1].[ActorsNames] LIKE @p__linq__26 ESCAPE N'~'))) OR ((N'url' = @p__linq__27) AND ([Extent1].[Urls] LIKE @p__linq__28 ESCAPE N'~')) OR ((N'advertiser' = @p__linq__29) AND ([Extent1].[ActorsNames] LIKE @p__linq__30 ESCAPE N'~')) OR ((N'text' = @p__linq__31) AND (([Extent1].[Text] LIKE @p__linq__32 ESCAPE N'~') OR ([Extent1].[AttachedText] LIKE @p__linq__33 ESCAPE N'~') OR ([Extent1].[MediaTexts] LIKE @p__linq__34 ESCAPE N'~'))) OR ((N'comments' = @p__linq__35) AND ( EXISTS (SELECT \r\n        1 AS [C1]\r\n        FROM [dbo].[Comments] AS [Extent14]\r\n        WHERE ([Extent1].[Id] = [Extent14].[Ad_Id]) AND (([Extent14].[Text] LIKE @p__linq__36 ESCAPE N'~') OR ([Extent14].[FacebookUserName] LIKE @p__linq__37 ESCAPE N'~'))\r\n    )))) AND ((@p__linq__38 IS NULL) OR ( EXISTS (SELECT \r\n        1 AS [C1]\r\n        FROM [dbo].[Snapshots] AS [Extent15]\r\n        WHERE ([Extent1].[Id] = [Extent15].[Ad_Id]) AND ([Extent15].[TakenOn] >= @p__linq__39)\r\n    ))) AND ([Extent1].[CreatedOn] IS NOT NULL) AND ([Extent1].[CreatedOn] > @p__linq__40)";
            var matches = Regex.Matches(text, @"\[(\w*)\].\[(\w*)\]\s*LIKE\s*@p__linq__20\s?(?:ESCAPE N?'~')");
            Console.WriteLine(matches.Count);
          
        }
    }
}