
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace Chess2Console
{
   
    public static class Utils
    {

    #region CG and memories

    public static void GCColect()
    {
      Debug.WriteLine($"Memory used before collection: {Utils.SizeSuffix(GC.GetTotalMemory(false))}");
      Console.WriteLine($"Memory used before collection: {Utils.SizeSuffix(GC.GetTotalMemory(false))}");
      GC.Collect();
      Debug.WriteLine($"Memory used before collection: {Utils.SizeSuffix(GC.GetTotalMemory(false))}");
      Console.WriteLine($"Memory used before collection: {Utils.SizeSuffix(GC.GetTotalMemory(false))}");

    }

    static readonly string[] SizeSuffixes =
             { "bytes", "KB", "MB", "GB", "TB", "PB", "EB", "ZB", "YB" };

    public static string SizeSuffix(Int64 value, int decimalPlaces = 1)
    {
      if (value < 0) { return "-" + SizeSuffix(-value, decimalPlaces); }

      int i = 0;
      decimal dValue = (decimal)value;
      while (Math.Round(dValue, decimalPlaces) >= 1000)
      {
        dValue /= 1024;
        i++;
      }

      return string.Format("{0:n" + decimalPlaces + "} {1}", dValue, SizeSuffixes[i]);
    }
    #endregion


    public static DateTime StartedProcessTime { get; set; }
    //Pour T41, on limite le temps de reflection, si le temps depasse le seul, on ne fait plus de verification, in Chess2Utils.TargetColorIsInChess() au niveau 4
    public static double LimitationForT41InMn { get; set; } = 1.5;




    public static bool TargetKingColorIsProteted(Board inBoard, string targetkingColor)
    {
      try
      {
        //   if (!TargetKingIsMenaced(inBoard, targetkingColor))
        //     return false;

        var targetkingindex = inBoard.GetCases().ToList().IndexOf($"K|{targetkingColor}");
        var alliesIndex = inBoard.GetCasesIndexForColor(targetkingColor).ToList();
        alliesIndex.Remove(targetkingindex);
        //var possibleMovesAllies = 
        foreach (var alieFromIndex in alliesIndex)
        {
          var possibleMovesIndex = inBoard.GetPossibleMoves(alieFromIndex, 1, false).Select(x => x.Index);
          //il faut faire un copi du bord original en déplacent le roi vers le possible move
          foreach (var alieToIndex in possibleMovesIndex)
          {
            var copyBord = CloneAndMove(inBoard, alieFromIndex, alieToIndex, 0);
            //  var possibleKingMovesCopy = copyBord.GetKingPossiblesMoveIndex(targetkingColor);
            var isMelaced = TargetIndexIsMenaced(copyBord, targetkingColor, targetkingindex);
            if (!isMelaced)
              return true;

          }
        }







        return false;
      }
      catch (Exception ex)
      {
        return false;
      }

    }

    /// <summary>
    /// tsiry;02-07-2022
    /// </summary>

    public static bool TargetColorIsInChess(Board inBoard, string targetkingColor)
    {
      try
      {
        if (!TargetKingIsMenaced(inBoard, targetkingColor))
          return false;


        var targetkingindex = inBoard.GetCases().ToList().IndexOf($"K|{targetkingColor}");
        var possibleKingMoves = inBoard.GetKingPossiblesMoveIndex(targetkingColor);

        //il faut faire un copi du bord original en déplacent le roi vers le possible move
        foreach (var index in possibleKingMoves)
        {
          var copyBord = CloneAndMove(inBoard, targetkingindex, index, 0);
          //  var possibleKingMovesCopy = copyBord.GetKingPossiblesMoveIndex(targetkingColor);
          var isMelaced = TargetIndexIsMenaced(copyBord, targetkingColor, index);
          if (!isMelaced)
            return false;

        }

        if (TargetKingColorIsProteted(inBoard, targetkingColor))
          return false;




        return true;
      }
      catch (Exception ex)
      {
        return false;
      }

    }


    /// <summary>
    /// tsiry;20-07-2022
    /// </summary>
    public static int GetWeigtOpionionMenacedsByToIndex(Board inBoard, string opinionColorColor, int toIndex)
    {
      try
      {
        var weight = 0;
        var opinionPawnIndex = inBoard.GetCasesIndexForColor(opinionColorColor);
        foreach (var index in opinionPawnIndex)
        {

          if (TargetIndexIsMenacedByToIndex(inBoard, opinionColorColor, index, toIndex))
            weight += inBoard.GetWeightInIndex(index);
        }
        return weight;
      }
      catch (Exception ex)
      {
        return 0;

      }
    }

    /// <summary>
    /// tsiry;20-07-2022
    /// </summary>
    public static bool TargetIndexIsMenacedByToIndex(Board inBoard, string targetColor, int targetIndex, int toIndex)
    {
      try
      {
        var opinionColor = "W";
        if (targetColor == "W")
          opinionColor = "B";
        var copyBoard = new Board(inBoard);
        if (targetIndex != -1)
        {
          if (copyBoard.GetCases()[targetIndex].Contains($"|{opinionColor}"))//si la case contion un pion adverse, on le vide
            copyBoard.GetCases()[targetIndex] = "__";
        }


        var opinionPossibleMoveIndexList = new List<int>();

        opinionPossibleMoveIndexList.AddRange(copyBoard.GetPossibleMoves(toIndex, 1, false).Select(x => x.Index));

        if (opinionPossibleMoveIndexList.Contains(targetIndex))
          return true;

        return false;
      }
      catch (Exception ex)
      {
        return false;

      }
    }


    /// <summary>
    /// tsiry;02-07-2022
    /// </summary>

    public static bool TargetIndexIsMenaced(Board inBoard, string targetColor, int targetIndex)
    {
      try
      {
        var opinionColor = "W";
        if (targetColor == "W")
          opinionColor = "B";
        var index = 0;
        var opibionOfTargetColorIndexList = new List<int>();
        foreach (var item in inBoard.GetCases())
        {
          if (item.Contains($"|{opinionColor}"))
          {
            opibionOfTargetColorIndexList.Add(index);
          }
          index++;
        }
        var opibionPossibleMoveIndexList = new List<int>();
        foreach (var opibionIndex in opibionOfTargetColorIndexList)
        {
          opibionPossibleMoveIndexList.AddRange(inBoard.GetPossibleMoves(opibionIndex, 1, false).Select(x => x.Index));
        }
         ;
        if (opibionPossibleMoveIndexList.Contains(targetIndex))
          return true;

        return false;
      }
      catch (Exception ex)
      {
        return false;

      }
    }


    /// <summary>
    /// tsiry;02-07-2022
    /// </summary>

    public static bool TargetKingIsMenaced(Board inBoard, string targetkingColor)
    {
      try
      {
        var targetkingindex = inBoard.GetCases().ToList().IndexOf($"K|{targetkingColor}");


        return TargetIndexIsMenaced(inBoard, targetkingColor, targetkingindex);


      }
      catch (Exception ex)
      {
        return false;

      }
    }

    public static Board MainBoard { get; set; }
    public static List<NodeChess2> NodeLoseList { get; set; } = new List<NodeChess2>();
    public static string ChangeShortNameToLongName(string shortName)
        {
            var name = "Pawn";
            //Pawn
            //SimplePawn => P
            //Knight => C
            //Bishop => B
            //Rook => T
            //Queen => Q
            //King => K

            //Color
            //Black => B
            //White => W
            switch (shortName)
            {
                case "C":
                    name = "Knight";
                    break;
                case "B":
                    name = "Bishop";
                    break;
                case "T":
                    name = "Rook";
                    break;
                case "Q":
                    name = "Queen";
                    break;
                case "K":
                    name = "King";
                    break;
            }
            return name;
        }

        private static int[] _evolutionPawnIndexBlack =
       {
      56,57,58,59,60,61,62,63
    };
        private static int[] _evolutionPawnIndexWhite =
        {
      0,1,2,3,4,5,6,7
    };
        public static int[] GetEvolutionPawnIndexWhite()
        {
            return _evolutionPawnIndexWhite;
        }
        public static int[] GetEvolutionPawnIndexBlack()
        {
            return _evolutionPawnIndexBlack;
        }


        private static string[] _coord = {
"a8","b8","c8","d8","e8","f8","g8","h8",
"a7","b7","c7","d7","e7","f7","g7","h7",
"a6","b6","c6","d6","e6","f6","g6","h6",
"a5","b5","c5","d5","e5","f5","g5","h5",
"a4","b4","c4","d4","e4","f4","g4","h4",
"a3","b3","c3","d3","e3","f3","g3","h3",
"a2","b2","c2","d2","e2","f2","g2","h2",
"a1","b1","c1","d1","e1","f1","g1","h1"
    };


        public static string ChangeLongNameToShortName(string longName)
        {
            var name = "P";
            //Pawn
            //SimplePawn => P
            //Knight => C
            //Bishop => B
            //Rook => T
            //Queen => Q
            //King => K

            //Color
            //Black => B
            //White => W
            switch (longName)
            {
                case "Knight":
                    name = "C";
                    break;
                case "Bishop":
                    name = "B";
                    break;
                case "Rook":
                    name = "T";
                    break;
                case "Queen":
                    name = "Q";
                    break;
                case "King":
                    name = "K";
                    break;
            }
            return name;
        }
        public static int GetIndexFromLocation(string index)
        {
            return _coord.ToList().IndexOf(index);
        }
        public static Board GenerateBoardFormPawnListString(List<string> pawns)
        {
            var board = new Board();

            //InsertPawn(0, "T", "B");
            // InsertPawn(1, "C", "B");
            // InsertPawn(2, "B", "B");

            foreach (var pawn in pawns)
            {
                //Rook;a1;White;False;False;False;False
                var datasString = pawn.Split(';');
                var location = datasString[1];
                if (String.IsNullOrEmpty(location))
                    continue;
                var index = _coord.ToList().IndexOf(location);
                if (index == -1)
                    continue;
                var color = datasString[2].ToString()[0].ToString();
                var longName = datasString[0];
                var name = "P";

                switch (longName)
                {
                    case "Knight":
                        name = "C";
                        break;
                    case "Bishop":
                        name = "B";
                        break;
                    case "Rook":
                        name = "T";
                        break;
                    case "Queen":
                        name = "Q";
                        break;
                    case "King":
                        name = "K";
                        break;
                }



                board.InsertPawn(index, name, color);
            }
            //  board.CalculeScores();
            board.PrintInDebug();
            return board;

        }
        /*
        public static List<NodeChess2> GetMimWeightChild(NodeChess2 parent)
        {
          //var minW = -9999;

          List<NodeChess2> GrandParentNodeChess2 = new List<NodeChess2>();
          GrandParentNodeChess2 = new List<NodeChess2>();
          foreach (var currentP in parent.ChildList)
          {
            GrandParentNodeChess2.Add(currentP);
            if (currentP.ChildList == null)
              return GrandParentNodeChess2;
           GrandParentNodeChess2.AddRange( GetMimWeightChild(currentP));
          }
          return GrandParentNodeChess2;
        }
        */




        public static List<string> MovingList { get; set; }

        // public static Board MainBord { get; set; }
        public static int GetKing(Board board, string color)
        {
            var kingIndex = board.GetCases().ToList().IndexOf($"K|{color}");
            return kingIndex;
        }
        /*tsiry;07-12-2021
         * */
        public static bool KingIsOut(Board board, string color)
        {
            var kingIndex = board.GetCases().ToList().IndexOf($"K|{color}");
            if (kingIndex == -1)
                return true;
            return false;
        }
        /*07-12-2021
         * */
        public static bool KingIsInChess(Board board, string color)
        {
            //var KingMainBoardIndex = Utils.MainBord.GetCases().ToList().IndexOf($"K|{color}");
            var kingIndex = board.GetCases().ToList().IndexOf($"K|{color}");
            if (kingIndex == -1)
                return true;
            /* if (KingMainBoardIndex == kingIndex)
             {*/
            var kingPossibleMoves = board.GetPossibleMoves(kingIndex, 0).Select(x => x.Index);
            foreach (var possibleIndex in kingPossibleMoves)
            {
                var emulateBord = CloneAndMove(board, kingIndex, possibleIndex, 0);
                if (!KingIsMenaced(emulateBord, color))
                    return false;
            }
            return true;
            /*  }
              else
                return false;*/


        }

        /*04-01-2022
         * */
        public static bool KingIsInChess2(Board board, string color)
        {

            var kingIsInChess = true;
            //on prend tous les index des pion adverse
            var opinionCaseIndex = board.GetCasesIndexForColor(OpinionColor);
            //on prend tous les index menacés par les pions adverses
            var menacedIndexByOpinion = new List<PossibleMove>();
            //on prend tous les possible moves des opinions
            var opinionPossibleMovesIndex = new List<PossibleMove>();
            foreach (var opinionIndex in opinionCaseIndex)
            {
                //si opinionIndex est nenacé, on ne fait rien
                if (Utils.IsMenaced(opinionIndex, board, OpinionColor))
                    continue;

                var opinionPossibleMoves = board.GetPossibleMoves(opinionIndex, 0);
                opinionPossibleMovesIndex.AddRange(opinionPossibleMoves);
                //SI SIMPLE PION,ON AJOUT CES LES DEUX CASE A COTE SI ILS SONT LIBRES

                //var currentCase = board.GetCases()[opinionIndex];
                var pawnName = board.GetPawnShortNameInIndex(opinionIndex);
                if (pawnName == "P")
                {
                    // var t_oIndex = opinionIndex;

                    var caseColor = board.GetPawnColorNameInIndex(opinionIndex);

                    var indexInTab64 = Utils.Tab64[opinionIndex];
                    //si B
                    var toAddList = new List<int>();
                    var sing = -1;
                    if (caseColor == "B")
                        sing = 1;

                    //Diagonal for opinion
                    var toAddOpinionListList = new List<int>();
                    toAddOpinionListList.Add((10 * sing) + 1);
                    toAddOpinionListList.Add((10 * sing) - 1);




                    foreach (var toAdd in toAddOpinionListList)
                    {
                        var destinationIndexInTab64 = indexInTab64 + toAdd;
                        var destinationIndex = Utils.Tab64.ToList().IndexOf(destinationIndexInTab64);

                        if (destinationIndex < 0 || destinationIndex > 63)
                            continue;
                        var isContent = board.GetIsContent(destinationIndex, caseColor);
                        if (isContent == 0)
                        {
                            //results.Add(destinationIndex);
                            opinionPossibleMovesIndex.Add(new PossibleMove { FromIndex = opinionIndex, Index = destinationIndex, IsContainOpinion = false });
                            // opinionPossibleMovesIndex.Add(destinationIndex);
                        }



                    }


                }

                var menacedIndex = opinionPossibleMoves.Where(x => x.IsContainOpinion);
                menacedIndexByOpinion.AddRange(menacedIndex);
                //on prend tous les possible moves des opinions

            }





            //   var t_ds = menacedIndexByOpinion;
            //si le roi est dans les menacedIndexByOpinion
            var kingIndex = Utils.GetKing(board, color);
            var kingIsMenaced = false;
            foreach (var opinionMove in menacedIndexByOpinion)
            {
                if (kingIndex == opinionMove.Index)
                    kingIsMenaced = true;
            }
            if (kingIsMenaced)
            {
                var kingPossiblesMove = board.GetPossibleMoves(kingIndex, 0).Select(x => x.Index);
                var opinionPossibleMovesIndexInList = opinionPossibleMovesIndex.Select(x => x.Index);

                foreach (var kingPossibleIndex in kingPossiblesMove)
                {
                    //si les possible moves ne l'adversaire ne contiennents pas le possible index du roi
                    //le roi n'est pas en echec
                    if (!opinionPossibleMovesIndexInList.Contains(kingPossibleIndex))
                        return false;
                }

            }
            else
                return false;

            return kingIsInChess;


        }

        /*12-11-2021
         * pour T80
         * */
        public static bool KingIsMenaced(Board board, string kingColor)
        {
            if (board == null)
                return false;
            var kingIndex = board.GetCases().ToList().IndexOf($"K|{kingColor}");
            if (IsMenaced(kingIndex, board, ComputerColor))
                return true;
            return false;
        }

        public static bool ComputerKingIsMenaced(Board board)
        {
            return KingIsMenaced(board, ComputerColor);
        }


        /*tsiry;04-01-2022
         * */


        public static bool IsMenaced(int toIndex, Board inBoard, string menacedColor)
        {
            /*if (toIndex == -1)
              return false;*/
            //if faut cloner si non on affecte le inBoard
            //IL FAUT CLONER inBoard POUR NE PAS L'AFFECTER
            var cloneBoard = Clone(inBoard);



            var opinionColor = "W";
            if (menacedColor == "W")
                opinionColor = "B";
            //dans le cas la case de déstination contien un pion adverse, on l'enleve
            if (cloneBoard.GetCases()[toIndex].Contains("|"))
                cloneBoard.GetCases()[toIndex] = "__";
            var opinionIndexs = cloneBoard.GetCasesIndexForColor(opinionColor);
            foreach (var index in opinionIndexs)
            {

                var pawnName = cloneBoard.GetPawnShortNameInIndex(index);
                if (pawnName != "P")
                {
                    var possibleMoves = cloneBoard.GetPossibleMoves(index, 0).Select(x => x.Index);
                    if (possibleMoves.Contains(toIndex))
                        return true;
                }
                else
                {
                    //POUR LE SIMPLE PION,ON ENLEVER LE HORIZONTAL ET ON AJOUTE LES DIAGONAUX
                    if (pawnName == "P")
                    {
                        var possibleMoves = new List<int>();

                        var caseColor = cloneBoard.GetPawnColorNameInIndex(index);

                        var indexInTab64 = Utils.Tab64[index];
                        //si B
                        var toAddList = new List<int>();
                        var sing = -1;
                        if (caseColor == "B")
                            sing = 1;

                        //Diagonal for opinion
                        var toAddOpinionListList = new List<int>();
                        toAddOpinionListList.Add((10 * sing) + 1);
                        toAddOpinionListList.Add((10 * sing) - 1);




                        foreach (var toAdd in toAddOpinionListList)
                        {
                            var destinationIndexInTab64 = indexInTab64 + toAdd;
                            var destinationIndex = Utils.Tab64.ToList().IndexOf(destinationIndexInTab64);

                            if (destinationIndex < 0 || destinationIndex > 63)
                                continue;
                            var isContent = cloneBoard.GetIsContent(destinationIndex, caseColor);
                            if (isContent == 0)
                            {
                                //results.Add(destinationIndex);
                                //opinionPossibleMovesIndex.Add(new PossibleMove { FromIndex = opinionIndex, Index = destinationIndex, IsContainOpinion = false });
                                // opinionPossibleMovesIndex.Add(destinationIndex);
                                possibleMoves.Add(destinationIndex);
                            }
                            if (possibleMoves.Contains(toIndex))
                                return true;



                        }


                    }


                }

            }


            return false;
        }

        public static bool IsMenacedOld(int toIndex, Board board)
        {
            var opinionColor = "W";
            if (Utils.ComputerColor == "W")
                opinionColor = "B";

            var opinionIndexs = board.GetCasesIndexForColor(opinionColor);
            foreach (var item in opinionIndexs)
            {
                var possibleMove = board.GetPossibleMoves(item, 0).Select(x => x.Index);
                if (possibleMove.Contains(toIndex))
                    return true;
            }


            return false;
        }

        private static string _computerColor; // field

        public static string ComputerColor   // property
        {
            get { return _computerColor; }   // get method
            set
            {
                _computerColor = value;

                //  var opinionColor = "W";
                if (value == "W")
                    OpinionColor = "B";
            }  // set method
        }

        public static string OpinionColor { get; set; } = "W";
        /*tsiry;20-05-2022
         * */
        public static Board CloneBoad(Board originalBord)
        {
            return new Board(originalBord);
        }
        // public static string ComputerColor { get; set; }
        public static Board CloneAndMove(Board originalBord, int initialIndex, int destinationIndex, int level)
        {
            var resultBorad = new Board(originalBord);

            resultBorad.Move(initialIndex, destinationIndex, level);

            resultBorad.CalculeScores();


            return resultBorad;
        }

        /*tsiry;24-12-2021
         * */
        public static Board Clone(Board originalBord)
        {
            var resultBorad = new Board(originalBord);
            return resultBorad;
        }

        public static bool IsValideMove(int indexTab120)
        {

            var index120 = Utils.Tab120[indexTab120];
            if (index120 == -1)
                return false;
            return true;
        }

        public static bool IsInFirstTab64(int tab64Content, string color)
        {
            if (color == "W")
            {
                if (SimplePawnFirstWhiteTab64.Contains(tab64Content))
                    return true;
            }
            if (color == "B")
            {
                if (SimplePawnFirstBlackTab64.Contains(tab64Content))
                    return true;
            }
            return false;


        }

        public static int[] SimplePawnFirstBlackTab64 = {
31, 32, 33, 34, 35, 36, 37, 38
    };

        public static int[] SimplePawnFirstWhiteTab64 = {
81, 82, 83, 84, 85, 86, 87, 88
    };

        public static int[] Tab120 = {
-1, -1, -1, -1, -1, -1, -1, -1, -1, -1,
-1, -1, -1, -1, -1, -1, -1, -1, -1, -1,
-1, 0, 1, 2, 3, 4, 5, 6, 7, -1,
-1, 8, 9, 10, 11, 12, 13, 14, 15, -1,
-1, 16, 17, 18, 19, 20, 21, 22, 23, -1,
-1, 24, 25, 26, 27, 28, 29, 30, 31, -1,
-1, 32, 33, 34, 35, 36, 37, 38, 39, -1,
-1, 40, 41, 42, 43, 44, 45, 46, 47, -1,
-1, 48, 49, 50, 51, 52, 53, 54, 55, -1,
-1, 56, 57, 58, 59, 60, 61, 62, 63, -1,
-1, -1, -1, -1, -1, -1, -1, -1, -1, -1,
-1, -1, -1, -1, -1, -1, -1, -1, -1, -1
    };
        public static int[] Tab64 = {
21, 22, 23, 24, 25, 26, 27, 28,
31, 32, 33, 34, 35, 36, 37, 38,
41, 42, 43, 44, 45, 46, 47, 48,
51, 52, 53, 54, 55, 56, 57, 58,
61, 62, 63, 64, 65, 66, 67, 68,
71, 72, 73, 74, 75, 76, 77, 78,
81, 82, 83, 84, 85, 86, 87, 88,
91, 92, 93, 94, 95, 96, 97, 98
    };

    }

}