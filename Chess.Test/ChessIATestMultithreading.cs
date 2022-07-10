using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using Chess;
using Chess.Utils;
using System.Windows.Controls;
using System.Linq;
using System.Collections.Generic;
using Chess.Model;
using System.Threading.Tasks;
using Chess2Console;
using System.IO;

namespace Chess.Test
{
    [TestClass]
    public class ChessIATestMultithreading
    {
        private string testsDirrectory = Path.Combine(Directory.GetParent(Directory.GetParent(Directory.GetParent(Path.Combine(Environment.CurrentDirectory)).ToString()).ToString()).ToString(), "TESTS");

        [TestMethod]
        public void MTT00aLeKnigntBlanchNeDoitPasAttaquer()
        {
            /*La cavalier blanch ne doit pas attaquer*/
            //Positions final du cavalier Blach ne doit pas etre  ni "a7" ni "c7" 


            var mainWindow = new MainWindow(); mainWindow.SetTurnNumberLabel("5");mainWindow.ComputerColore = "White";

            
            var pawnListWhite = new List<Pawn>();
            var pawnListBlack = new List<Pawn>();


            //WHITEList
            var whiteListString = "" +
              "Rook;a1;White;False;False;False;False" +
      "\nSimplePawn;a2;White;True;False;False;False" +
      "\nKnight;b5;White;False;False;False;False" +
      "\nSimplePawn;b2;White;True;False;False;False" +
      "\nBishop;c1;White;False;False;False;False" +
      "\nSimplePawn;c2;White;True;False;False;False" +
      "\nQueen;d1;White;False;False;False;False" +
      "\nSimplePawn;d2;White;True;False;False;False" +
      "\nKing;e1;White;False;True;True;True" +
      "\nSimplePawn;e2;White;True;False;False;False" +
      "\nBishop;f1;White;False;False;False;False" +
      "\nSimplePawn;f2;White;True;False;False;False" +
      "\nKnight;g1;White;False;False;False;False" +
      "\nSimplePawn;g2;White;True;False;False;False" +
      "\nRook;h1;White;False;False;False;False" +
      "\nSimplePawn;h2;White;True;False;False;False";
            var whiteList = whiteListString.Split('\n');
            foreach (var line in whiteList)
            {
                var datas = line.Split(';');
                var newPawn = new Pawn(datas[0], datas[1], new Button(), datas[2], mainWindow);
                //;{pawn.IsFirstMove};{pawn.IsFirstMoveKing};{pawn.IsLeftRookFirstMove};{pawn.IsRightRookFirstMove}
                newPawn.IsFirstMove = bool.Parse(datas[3]);
                newPawn.IsFirstMoveKing = bool.Parse(datas[4]);
                newPawn.IsLeftRookFirstMove = bool.Parse(datas[5]);
                newPawn.IsRightRookFirstMove = bool.Parse(datas[6]);
                pawnListWhite.Add(newPawn);
            }

            //BLACKList
            var blackListString = "" +
            "SimplePawn;a7;Black;True;False;False;False" +
      "\nRook;a8;Black;False;False;False;False" +
      "\nSimplePawn;b7;Black;True;False;False;False" +
      "\nKnight;b8;Black;False;False;False;False" +
      "\nSimplePawn;c7;Black;True;False;False;False" +
      "\nBishop;c8;Black;False;False;False;False" +
      "\nSimplePawn;d7;Black;True;False;False;False" +
      "\nQueen;d8;Black;False;False;False;False" +
      "\nSimplePawn;e6;Black;False;False;False;False" +
      "\nKing;e8;Black;False;True;True;True" +
      "\nSimplePawn;f7;Black;True;False;False;False" +
      "\nBishop;b4;Black;False;False;False;False" +
      "\nSimplePawn;g7;Black;True;False;False;False" +
      "\nKnight;g8;Black;False;False;False;False" +
      "\nSimplePawn;h7;Black;True;False;False;False" +
      "\nRook;h8;Black;False;False;False;False";
            var blackList = blackListString.Split('\n');
            foreach (var line in blackList)
            {
                var datas = line.Split(';');
                var newPawn = new Pawn(datas[0], datas[1], new Button(), datas[2], mainWindow);
                //;{pawn.IsFirstMove};{pawn.IsFirstMoveKing};{pawn.IsLeftRookFirstMove};{pawn.IsRightRookFirstMove}
                newPawn.IsFirstMove = bool.Parse(datas[3]);
                newPawn.IsFirstMoveKing = bool.Parse(datas[4]);
                newPawn.IsLeftRookFirstMove = bool.Parse(datas[5]);
                newPawn.IsRightRookFirstMove = bool.Parse(datas[6]);
                pawnListBlack.Add(newPawn);
            }


            var pawnList = new List<Pawn>();
            pawnList.AddRange(pawnListWhite);
            pawnList.AddRange(pawnListBlack);mainWindow.PawnList = pawnList;

            using (var chess2UtilsNotStatic = new Chess2UtilsNotStatic())
            {
                var nodeResult = mainWindow.GetBestPositionLocalNotTask(mainWindow.ComputerColore);
                //Positions final du cavalier Blach ne doit pas etre  ni "a7" ni "c7"
                Assert.AreNotEqual(nodeResult.BestChildPosition, "a7", "c7");
            }
        }



        [TestMethod]
        public void MTT00aMultithreadingLeKnigntBlanchNeDoitPasAttaquer()
        {
            /*La cavalier blanch ne doit pas attaquer*/
            //Positions final du cavalier Blach ne doit pas etre  ni "a7" ni "c7" 

            
            var mainWindow = new MainWindow(); mainWindow.SetTurnNumberLabel("5");mainWindow.ComputerColore = "White";
            





            var pawnListWhite = new List<Pawn>();
            var pawnListBlack = new List<Pawn>();


            //WHITEList
            var whiteListString = "" +
              "Rook;a1;White;False;False;False;False" +
      "\nSimplePawn;a2;White;True;False;False;False" +
      "\nKnight;b5;White;False;False;False;False" +
      "\nSimplePawn;b2;White;True;False;False;False" +
      "\nBishop;c1;White;False;False;False;False" +
      "\nSimplePawn;c2;White;True;False;False;False" +
      "\nQueen;d1;White;False;False;False;False" +
      "\nSimplePawn;d2;White;True;False;False;False" +
      "\nKing;e1;White;False;True;True;True" +
      "\nSimplePawn;e2;White;True;False;False;False" +
      "\nBishop;f1;White;False;False;False;False" +
      "\nSimplePawn;f2;White;True;False;False;False" +
      "\nKnight;g1;White;False;False;False;False" +
      "\nSimplePawn;g2;White;True;False;False;False" +
      "\nRook;h1;White;False;False;False;False" +
      "\nSimplePawn;h2;White;True;False;False;False";
            var whiteList = whiteListString.Split('\n');
            foreach (var line in whiteList)
            {
                var datas = line.Split(';');
                var newPawn = new Pawn(datas[0], datas[1], new Button(), datas[2], mainWindow);
                //;{pawn.IsFirstMove};{pawn.IsFirstMoveKing};{pawn.IsLeftRookFirstMove};{pawn.IsRightRookFirstMove}
                newPawn.IsFirstMove = bool.Parse(datas[3]);
                newPawn.IsFirstMoveKing = bool.Parse(datas[4]);
                newPawn.IsLeftRookFirstMove = bool.Parse(datas[5]);
                newPawn.IsRightRookFirstMove = bool.Parse(datas[6]);
                pawnListWhite.Add(newPawn);
            }

            //BLACKList
            var blackListString = "" +
            "SimplePawn;a7;Black;True;False;False;False" +
      "\nRook;a8;Black;False;False;False;False" +
      "\nSimplePawn;b7;Black;True;False;False;False" +
      "\nKnight;b8;Black;False;False;False;False" +
      "\nSimplePawn;c7;Black;True;False;False;False" +
      "\nBishop;c8;Black;False;False;False;False" +
      "\nSimplePawn;d7;Black;True;False;False;False" +
      "\nQueen;d8;Black;False;False;False;False" +
      "\nSimplePawn;e6;Black;False;False;False;False" +
      "\nKing;e8;Black;False;True;True;True" +
      "\nSimplePawn;f7;Black;True;False;False;False" +
      "\nBishop;b4;Black;False;False;False;False" +
      "\nSimplePawn;g7;Black;True;False;False;False" +
      "\nKnight;g8;Black;False;False;False;False" +
      "\nSimplePawn;h7;Black;True;False;False;False" +
      "\nRook;h8;Black;False;False;False;False";
            var blackList = blackListString.Split('\n');
            foreach (var line in blackList)
            {
                var datas = line.Split(';');
                var newPawn = new Pawn(datas[0], datas[1], new Button(), datas[2], mainWindow);
                //;{pawn.IsFirstMove};{pawn.IsFirstMoveKing};{pawn.IsLeftRookFirstMove};{pawn.IsRightRookFirstMove}
                newPawn.IsFirstMove = bool.Parse(datas[3]);
                newPawn.IsFirstMoveKing = bool.Parse(datas[4]);
                newPawn.IsLeftRookFirstMove = bool.Parse(datas[5]);
                newPawn.IsRightRookFirstMove = bool.Parse(datas[6]);
                pawnListBlack.Add(newPawn);
            }



            var pawnList = new List<Pawn>();
            pawnList.AddRange(pawnListWhite);
            pawnList.AddRange(pawnListBlack);mainWindow.PawnList = pawnList;
            using (var chess2UtilsNotStatic = new Chess2UtilsNotStatic())
            {
                // var nodeResult = mainWindow.GetBestPositionLocalNotTask(mainWindow.ComputerColore);
                var nodeResult = mainWindow.GetBestPositionLocalNotTask(mainWindow.ComputerColore);

                //Positions final du cavalier Blach ne doit pas etre  ni "a7" ni "c7"
                Assert.AreNotEqual(nodeResult.BestChildPosition, "a7", "c7");
            }
        }


        [TestMethod]
        public void MTT00bLeKnigntNoirNeDoitPasAttaquer()
        {
            /*La cavalier noit ne doit pas attaquer*/
            //Positions final du cavalier noir ne doit pas etre  ni "a2" ni "c2" 

            
            var mainWindow = new MainWindow(); mainWindow.SetTurnNumberLabel("5");mainWindow.ComputerColore = "Black";
          




            var pawnListWhite = new List<Pawn>();
            var pawnListBlack = new List<Pawn>();


            //WHITEList
            var whiteListString = "" +
              "Rook;a1;White;False;False;False;False" +
      "\nSimplePawn;a2;White;True;False;False;False" +
      "\nKnight;b5;White;False;False;False;False" +
      "\nSimplePawn;b2;White;True;False;False;False" +
      "\nBishop;c1;White;False;False;False;False" +
      "\nSimplePawn;c2;White;True;False;False;False" +
      "\nQueen;d1;White;False;False;False;False" +
      "\nSimplePawn;d2;White;True;False;False;False" +
      "\nKing;e1;White;False;True;True;True" +
      "\nSimplePawn;e2;White;True;False;False;False" +
      "\nBishop;f1;White;False;False;False;False" +
      "\nSimplePawn;f2;White;True;False;False;False" +
      "\nKnight;g1;White;False;False;False;False" +
      "\nSimplePawn;g2;White;True;False;False;False" +
      "\nRook;h1;White;False;False;False;False" +
      "\nSimplePawn;h2;White;True;False;False;False";
            var whiteList = whiteListString.Split('\n');
            foreach (var line in whiteList)
            {
                var datas = line.Split(';');
                var newPawn = new Pawn(datas[0], datas[1], new Button(), datas[2], mainWindow);
                //;{pawn.IsFirstMove};{pawn.IsFirstMoveKing};{pawn.IsLeftRookFirstMove};{pawn.IsRightRookFirstMove}
                newPawn.IsFirstMove = bool.Parse(datas[3]);
                newPawn.IsFirstMoveKing = bool.Parse(datas[4]);
                newPawn.IsLeftRookFirstMove = bool.Parse(datas[5]);
                newPawn.IsRightRookFirstMove = bool.Parse(datas[6]);
                pawnListWhite.Add(newPawn);
            }

            //BLACKList
            var blackListString = "" +
            "SimplePawn;a7;Black;True;False;False;False" +
      "\nRook;a8;Black;False;False;False;False" +
      "\nSimplePawn;b7;Black;True;False;False;False" +
      "\nKnight;b8;Black;False;False;False;False" +
      "\nSimplePawn;c7;Black;True;False;False;False" +
      "\nBishop;c8;Black;False;False;False;False" +
      "\nSimplePawn;d7;Black;True;False;False;False" +
      "\nQueen;d8;Black;False;False;False;False" +
      "\nSimplePawn;e6;Black;False;False;False;False" +
      "\nKing;e8;Black;False;True;True;True" +
      "\nSimplePawn;f7;Black;True;False;False;False" +
      "\nBishop;b4;Black;False;False;False;False" +
      "\nSimplePawn;g7;Black;True;False;False;False" +
      "\nKnight;g8;Black;False;False;False;False" +
      "\nSimplePawn;h7;Black;True;False;False;False" +
      "\nRook;h8;Black;False;False;False;False";
            var blackList = blackListString.Split('\n');
            foreach (var line in blackList)
            {
                var datas = line.Split(';');
                var newPawn = new Pawn(datas[0], datas[1], new Button(), datas[2], mainWindow);
                //;{pawn.IsFirstMove};{pawn.IsFirstMoveKing};{pawn.IsLeftRookFirstMove};{pawn.IsRightRookFirstMove}
                newPawn.IsFirstMove = bool.Parse(datas[3]);
                newPawn.IsFirstMoveKing = bool.Parse(datas[4]);
                newPawn.IsLeftRookFirstMove = bool.Parse(datas[5]);
                newPawn.IsRightRookFirstMove = bool.Parse(datas[6]);
                pawnListBlack.Add(newPawn);
            }


            var pawnList = new List<Pawn>();
            pawnList.AddRange(pawnListWhite);
            pawnList.AddRange(pawnListBlack);mainWindow.PawnList = pawnList;

            using (var chess2UtilsNotStatic = new Chess2UtilsNotStatic())
            {

                var nodeResult = mainWindow.GetBestPositionLocalNotTask(mainWindow.ComputerColore);
                //Positions final du cavalier noir ne doit pas etre  ni "a2" ni "c2" 
                Assert.AreNotEqual(nodeResult.BestChildPosition, "a2", "c2");
            }
        }
        [TestMethod]
        public void MTT00bMultithreadingLeKnigntNoirNeDoitPasAttaquer()
        {
            /*La cavalier noit ne doit pas attaquer*/
            //Positions final du cavalier noir ne doit pas etre  ni "a2" ni "c2" 

            
            var mainWindow = new MainWindow(); mainWindow.SetTurnNumberLabel("5");mainWindow.ComputerColore = "Black";
           




            var pawnListWhite = new List<Pawn>();
            var pawnListBlack = new List<Pawn>();


            //WHITEList
            var whiteListString = "" +
              "Rook;a1;White;False;False;False;False" +
      "\nSimplePawn;a2;White;True;False;False;False" +
      "\nKnight;b5;White;False;False;False;False" +
      "\nSimplePawn;b2;White;True;False;False;False" +
      "\nBishop;c1;White;False;False;False;False" +
      "\nSimplePawn;c2;White;True;False;False;False" +
      "\nQueen;d1;White;False;False;False;False" +
      "\nSimplePawn;d2;White;True;False;False;False" +
      "\nKing;e1;White;False;True;True;True" +
      "\nSimplePawn;e2;White;True;False;False;False" +
      "\nBishop;f1;White;False;False;False;False" +
      "\nSimplePawn;f2;White;True;False;False;False" +
      "\nKnight;g1;White;False;False;False;False" +
      "\nSimplePawn;g2;White;True;False;False;False" +
      "\nRook;h1;White;False;False;False;False" +
      "\nSimplePawn;h2;White;True;False;False;False";
            var whiteList = whiteListString.Split('\n');
            foreach (var line in whiteList)
            {
                var datas = line.Split(';');
                var newPawn = new Pawn(datas[0], datas[1], new Button(), datas[2], mainWindow);
                //;{pawn.IsFirstMove};{pawn.IsFirstMoveKing};{pawn.IsLeftRookFirstMove};{pawn.IsRightRookFirstMove}
                newPawn.IsFirstMove = bool.Parse(datas[3]);
                newPawn.IsFirstMoveKing = bool.Parse(datas[4]);
                newPawn.IsLeftRookFirstMove = bool.Parse(datas[5]);
                newPawn.IsRightRookFirstMove = bool.Parse(datas[6]);
                pawnListWhite.Add(newPawn);
            }

            //BLACKList
            var blackListString = "" +
            "SimplePawn;a7;Black;True;False;False;False" +
      "\nRook;a8;Black;False;False;False;False" +
      "\nSimplePawn;b7;Black;True;False;False;False" +
      "\nKnight;b8;Black;False;False;False;False" +
      "\nSimplePawn;c7;Black;True;False;False;False" +
      "\nBishop;c8;Black;False;False;False;False" +
      "\nSimplePawn;d7;Black;True;False;False;False" +
      "\nQueen;d8;Black;False;False;False;False" +
      "\nSimplePawn;e6;Black;False;False;False;False" +
      "\nKing;e8;Black;False;True;True;True" +
      "\nSimplePawn;f7;Black;True;False;False;False" +
      "\nBishop;b4;Black;False;False;False;False" +
      "\nSimplePawn;g7;Black;True;False;False;False" +
      "\nKnight;g8;Black;False;False;False;False" +
      "\nSimplePawn;h7;Black;True;False;False;False" +
      "\nRook;h8;Black;False;False;False;False";
            var blackList = blackListString.Split('\n');
            foreach (var line in blackList)
            {
                var datas = line.Split(';');
                var newPawn = new Pawn(datas[0], datas[1], new Button(), datas[2], mainWindow);
                //;{pawn.IsFirstMove};{pawn.IsFirstMoveKing};{pawn.IsLeftRookFirstMove};{pawn.IsRightRookFirstMove}
                newPawn.IsFirstMove = bool.Parse(datas[3]);
                newPawn.IsFirstMoveKing = bool.Parse(datas[4]);
                newPawn.IsLeftRookFirstMove = bool.Parse(datas[5]);
                newPawn.IsRightRookFirstMove = bool.Parse(datas[6]);
                pawnListBlack.Add(newPawn);
            }



            var pawnList = new List<Pawn>();
            pawnList.AddRange(pawnListWhite);
            pawnList.AddRange(pawnListBlack);mainWindow.PawnList = pawnList;

            using (var chess2UtilsNotStatic = new Chess2UtilsNotStatic())
            {
                var nodeResult = mainWindow.GetBestPositionLocalNotTask(mainWindow.ComputerColore);
                //Positions final du cavalier noir ne doit pas etre  ni "a2" ni "c2" 
                Assert.AreNotEqual(nodeResult.BestChildPosition, "a2", "c2");
            }
        }



        [TestMethod]
        public void MTT01QuenLaReineNoirNeDoitPasPrendreLeCavalier()
        {
            /*La reine noir ne doit pas prendre le cavalier*/
            //Position final de la reine Noir ne doit pas etre "g5"

            
            var mainWindow = new MainWindow(); mainWindow.SetTurnNumberLabel("5");mainWindow.ComputerColore = "Black";
            




            var pawnListWhite = new List<Pawn>();
            var pawnListBlack = new List<Pawn>();


            //WHITEList
            var whiteListString = "" +
              "King;g1;White;False;True;True;True" +
      "\nQueen;f3;White;False;False;False;False" +
      "\nRook;a1;White;False;False;False;False" +
      "\nRook;f1;White;False;False;False;False" +
      "\nKnight;b1;White;False;False;False;False" +
      "\nKnight;g5;White;False;False;False;False" +
      "\nBishop;c1;White;False;False;False;False" +
      "\nBishop;b3;White;False;False;False;False" +
      "\nSimplePawn;a2;White;True;False;False;False" +
      "\nSimplePawn;b2;White;True;False;False;False" +
      "\nSimplePawn;c2;White;True;False;False;False" +
      "\nSimplePawn;d4;White;False;False;False;False" +
      "\nSimplePawn;e5;White;False;False;False;False" +
      "\nSimplePawn;f2;White;True;False;False;False" +
      "\nSimplePawn;g2;White;True;False;False;False" +
      "\nSimplePawn;h2;White;True;False;False;False";
            var whiteList = whiteListString.Split('\n');
            foreach (var line in whiteList)
            {
                var datas = line.Split(';');
                var newPawn = new Pawn(datas[0], datas[1], new Button(), datas[2], mainWindow);
                //;{pawn.IsFirstMove};{pawn.IsFirstMoveKing};{pawn.IsLeftRookFirstMove};{pawn.IsRightRookFirstMove}
                newPawn.IsFirstMove = bool.Parse(datas[3]);
                newPawn.IsFirstMoveKing = bool.Parse(datas[4]);
                newPawn.IsLeftRookFirstMove = bool.Parse(datas[5]);
                newPawn.IsRightRookFirstMove = bool.Parse(datas[6]);
                pawnListWhite.Add(newPawn);
            }

            //BLACKList
            var blackListString = "" +
            "King;e8;Black;False;True;True;True" +
      "\nQueen;d8;Black;False;False;False;False" +
      "\nRook;a8;Black;False;False;False;False" +
      "\nRook;h8;Black;False;False;False;False" +
      "\nKnight;b8;Black;False;False;False;False" +
      "\nBishop;c8;Black;False;False;False;False" +
      "\nBishop;f8;Black;False;False;False;False" +
      "\nKnight;g8;Black;False;False;False;False" +
      "\nSimplePawn;a7;Black;True;False;False;False" +
      "\nSimplePawn;b5;Black;False;False;False;False" +
      "\nSimplePawn;c6;Black;False;False;False;False" +
      "\nSimplePawn;d5;Black;False;False;False;False" +
      "\nSimplePawn;e6;Black;False;False;False;False" +
      "\nSimplePawn;f7;Black;True;False;False;False" +
      "\nSimplePawn;g6;Black;False;False;False;False" +
      "\nSimplePawn;h4;Black;False;False;False;False";
            var blackList = blackListString.Split('\n');
            foreach (var line in blackList)
            {
                var datas = line.Split(';');
                var newPawn = new Pawn(datas[0], datas[1], new Button(), datas[2], mainWindow);
                //;{pawn.IsFirstMove};{pawn.IsFirstMoveKing};{pawn.IsLeftRookFirstMove};{pawn.IsRightRookFirstMove}
                newPawn.IsFirstMove = bool.Parse(datas[3]);
                newPawn.IsFirstMoveKing = bool.Parse(datas[4]);
                newPawn.IsLeftRookFirstMove = bool.Parse(datas[5]);
                newPawn.IsRightRookFirstMove = bool.Parse(datas[6]);
                pawnListBlack.Add(newPawn);
            }


            var pawnList = new List<Pawn>();
            pawnList.AddRange(pawnListWhite);
            pawnList.AddRange(pawnListBlack);mainWindow.PawnList = pawnList;

            using (var chess2UtilsNotStatic = new Chess2UtilsNotStatic())
            {
                var nodeResult = mainWindow.GetBestPositionLocalNotTask(mainWindow.ComputerColore);
                //Position final de la reine Noir ne doit pas etre "g5"
                Assert.AreNotEqual(nodeResult.BestChildPosition, "g5");
            }
        }


        [TestMethod]
        public void MTT02aLeRookBlanchNeDoitPasPrendresLePion()
        {
            /*Le Rook blanc ne doit pas prendre le pion*/
            //Position final du Rook blanch  ne doit pas etre "a7"

            
            var mainWindow = new MainWindow(); mainWindow.SetTurnNumberLabel("5");mainWindow.ComputerColore = "White";
            





            var pawnListWhite = new List<Pawn>();
            var pawnListBlack = new List<Pawn>();


            //WHITEList
            var whiteListString = "" +
              "King;e1;White;False;True;True;True" +
      "\nRook;a1;White;False;False;False;False" +
      "\nKnight;b1;White;False;False;False;False" +
      "\nSimplePawn;b2;White;True;False;False;False" +
      "\nBishop;c1;White;False;False;False;False" +
      "\nSimplePawn;c4;White;False;False;False;False" +
      "\nSimplePawn;d3;White;False;False;False;False" +
      "\nBishop;f1;White;False;False;False;False" +
      "\nSimplePawn;f4;White;False;False;False;False" +
      "\nKnight;g1;White;False;False;False;False" +
      "\nSimplePawn;g2;White;True;False;False;False" +
      "\nQueen;h1;White;False;False;False;False" +
      "\nSimplePawn;h2;White;True;False;False;False";
            var whiteList = whiteListString.Split('\n');
            foreach (var line in whiteList)
            {
                var datas = line.Split(';');
                var newPawn = new Pawn(datas[0], datas[1], new Button(), datas[2], mainWindow);
                //;{pawn.IsFirstMove};{pawn.IsFirstMoveKing};{pawn.IsLeftRookFirstMove};{pawn.IsRightRookFirstMove}
                newPawn.IsFirstMove = bool.Parse(datas[3]);
                newPawn.IsFirstMoveKing = bool.Parse(datas[4]);
                newPawn.IsLeftRookFirstMove = bool.Parse(datas[5]);
                newPawn.IsRightRookFirstMove = bool.Parse(datas[6]);
                pawnListWhite.Add(newPawn);
            }

            //BLACKList
            var blackListString = "" +
             "King;d8;Black;False;True;True;True" +
      "\nRook;h8;Black;False;False;False;False" +
      "\nKnight;b8;Black;False;False;False;False" +
      "\nSimplePawn;g7;Black;True;False;False;False" +
      "\nBishop;c8;Black;False;False;False;False" +
      "\nSimplePawn;f5;Black;False;False;False;False" +
      "\nSimplePawn;e6;Black;False;False;False;False" +
      "\nBishop;f8;Black;False;False;False;False" +
      "\nSimplePawn;c5;Black;False;False;False;False" +
      "\nKnight;g8;Black;False;False;False;False" +
      "\nSimplePawn;b7;Black;True;False;False;False" +
      "\nQueen;a8;Black;False;False;False;False" +
      "\nSimplePawn;a7;Black;True;False;False;False";
            var blackList = blackListString.Split('\n');
            foreach (var line in blackList)
            {
                var datas = line.Split(';');
                var newPawn = new Pawn(datas[0], datas[1], new Button(), datas[2], mainWindow);
                //;{pawn.IsFirstMove};{pawn.IsFirstMoveKing};{pawn.IsLeftRookFirstMove};{pawn.IsRightRookFirstMove}
                newPawn.IsFirstMove = bool.Parse(datas[3]);
                newPawn.IsFirstMoveKing = bool.Parse(datas[4]);
                newPawn.IsLeftRookFirstMove = bool.Parse(datas[5]);
                newPawn.IsRightRookFirstMove = bool.Parse(datas[6]);
                pawnListBlack.Add(newPawn);
            }


            var pawnList = new List<Pawn>();
            pawnList.AddRange(pawnListWhite);
            pawnList.AddRange(pawnListBlack);mainWindow.PawnList = pawnList;

            using (var chess2UtilsNotStatic = new Chess2UtilsNotStatic())
            {
                var nodeResult = mainWindow.GetBestPositionLocalNotTask(mainWindow.ComputerColore);
                //Position final du rook blanch  ne doit pas etre "a7"
                Assert.AreNotEqual(nodeResult.BestChildPosition, "a7");
            }
        }

        [TestMethod]
        public void MTT02aMultithreadingLeRookBlanchNeDoitPasPrendresLePion()
        {
            /*Le Rook blanc ne doit pas prendre le pion*/
            //Position final du Rook blanch  ne doit pas etre "a7"

            
            var mainWindow = new MainWindow(); mainWindow.SetTurnNumberLabel("5");mainWindow.ComputerColore = "White";
            





            var pawnListWhite = new List<Pawn>();
            var pawnListBlack = new List<Pawn>();


            //WHITEList
            var whiteListString = "" +
              "King;e1;White;False;True;True;True" +
      "\nRook;a1;White;False;False;False;False" +
      "\nKnight;b1;White;False;False;False;False" +
      "\nSimplePawn;b2;White;True;False;False;False" +
      "\nBishop;c1;White;False;False;False;False" +
      "\nSimplePawn;c4;White;False;False;False;False" +
      "\nSimplePawn;d3;White;False;False;False;False" +
      "\nBishop;f1;White;False;False;False;False" +
      "\nSimplePawn;f4;White;False;False;False;False" +
      "\nKnight;g1;White;False;False;False;False" +
      "\nSimplePawn;g2;White;True;False;False;False" +
      "\nQueen;h1;White;False;False;False;False" +
      "\nSimplePawn;h2;White;True;False;False;False";
            var whiteList = whiteListString.Split('\n');
            foreach (var line in whiteList)
            {
                var datas = line.Split(';');
                var newPawn = new Pawn(datas[0], datas[1], new Button(), datas[2], mainWindow);
                //;{pawn.IsFirstMove};{pawn.IsFirstMoveKing};{pawn.IsLeftRookFirstMove};{pawn.IsRightRookFirstMove}
                newPawn.IsFirstMove = bool.Parse(datas[3]);
                newPawn.IsFirstMoveKing = bool.Parse(datas[4]);
                newPawn.IsLeftRookFirstMove = bool.Parse(datas[5]);
                newPawn.IsRightRookFirstMove = bool.Parse(datas[6]);
                pawnListWhite.Add(newPawn);
            }

            //BLACKList
            var blackListString = "" +
             "King;d8;Black;False;True;True;True" +
      "\nRook;h8;Black;False;False;False;False" +
      "\nKnight;b8;Black;False;False;False;False" +
      "\nSimplePawn;g7;Black;True;False;False;False" +
      "\nBishop;c8;Black;False;False;False;False" +
      "\nSimplePawn;f5;Black;False;False;False;False" +
      "\nSimplePawn;e6;Black;False;False;False;False" +
      "\nBishop;f8;Black;False;False;False;False" +
      "\nSimplePawn;c5;Black;False;False;False;False" +
      "\nKnight;g8;Black;False;False;False;False" +
      "\nSimplePawn;b7;Black;True;False;False;False" +
      "\nQueen;a8;Black;False;False;False;False" +
      "\nSimplePawn;a7;Black;True;False;False;False";
            var blackList = blackListString.Split('\n');
            foreach (var line in blackList)
            {
                var datas = line.Split(';');
                var newPawn = new Pawn(datas[0], datas[1], new Button(), datas[2], mainWindow);
                //;{pawn.IsFirstMove};{pawn.IsFirstMoveKing};{pawn.IsLeftRookFirstMove};{pawn.IsRightRookFirstMove}
                newPawn.IsFirstMove = bool.Parse(datas[3]);
                newPawn.IsFirstMoveKing = bool.Parse(datas[4]);
                newPawn.IsLeftRookFirstMove = bool.Parse(datas[5]);
                newPawn.IsRightRookFirstMove = bool.Parse(datas[6]);
                pawnListBlack.Add(newPawn);
            }


            var pawnList = new List<Pawn>();
            pawnList.AddRange(pawnListWhite);
            pawnList.AddRange(pawnListBlack);mainWindow.PawnList = pawnList;

            using (var chess2UtilsNotStatic = new Chess2UtilsNotStatic())
            {
                var nodeResult = mainWindow.GetBestPositionLocalNotTask(mainWindow.ComputerColore);
                //Position final du rook blanch  ne doit pas etre "a7"
                Assert.AreNotEqual(nodeResult.BestChildPosition, "a7");
            }
        }

        [TestMethod]
        public void MTT02bMultithreadingLeRookNoirNeDoitPasPrendresLePion()
        {
            /*Le Rook noir ne doit pas prendre le pion*/
            //Position final du Rook blanch  ne doit pas etre "h2"

            
            var mainWindow = new MainWindow(); mainWindow.SetTurnNumberLabel("5");mainWindow.ComputerColore = "Black";
            




            var pawnListWhite = new List<Pawn>();
            var pawnListBlack = new List<Pawn>();


            //WHITEList
            var whiteListString = "" +
              "King;e1;White;False;True;True;True" +
      "\nRook;a1;White;False;False;False;False" +
      "\nKnight;b1;White;False;False;False;False" +
      "\nSimplePawn;b2;White;True;False;False;False" +
      "\nBishop;c1;White;False;False;False;False" +
      "\nSimplePawn;c4;White;False;False;False;False" +
      "\nSimplePawn;d3;White;False;False;False;False" +
      "\nBishop;f1;White;False;False;False;False" +
      "\nSimplePawn;f4;White;False;False;False;False" +
      "\nKnight;g1;White;False;False;False;False" +
      "\nSimplePawn;g2;White;True;False;False;False" +
      "\nQueen;h1;White;False;False;False;False" +
      "\nSimplePawn;h2;White;True;False;False;False";
            var whiteList = whiteListString.Split('\n');
            foreach (var line in whiteList)
            {
                var datas = line.Split(';');
                var newPawn = new Pawn(datas[0], datas[1], new Button(), datas[2], mainWindow);
                //;{pawn.IsFirstMove};{pawn.IsFirstMoveKing};{pawn.IsLeftRookFirstMove};{pawn.IsRightRookFirstMove}
                newPawn.IsFirstMove = bool.Parse(datas[3]);
                newPawn.IsFirstMoveKing = bool.Parse(datas[4]);
                newPawn.IsLeftRookFirstMove = bool.Parse(datas[5]);
                newPawn.IsRightRookFirstMove = bool.Parse(datas[6]);
                pawnListWhite.Add(newPawn);
            }

            //BLACKList
            var blackListString = "" +
             "King;d8;Black;False;True;True;True" +
      "\nRook;h8;Black;False;False;False;False" +
      "\nKnight;b8;Black;False;False;False;False" +
      "\nSimplePawn;g7;Black;True;False;False;False" +
      "\nBishop;c8;Black;False;False;False;False" +
      "\nSimplePawn;f5;Black;False;False;False;False" +
      "\nSimplePawn;e6;Black;False;False;False;False" +
      "\nBishop;f8;Black;False;False;False;False" +
      "\nSimplePawn;c5;Black;False;False;False;False" +
      "\nKnight;g8;Black;False;False;False;False" +
      "\nSimplePawn;b7;Black;True;False;False;False" +
      "\nQueen;a8;Black;False;False;False;False" +
      "\nSimplePawn;a7;Black;True;False;False;False";
            var blackList = blackListString.Split('\n');
            foreach (var line in blackList)
            {
                var datas = line.Split(';');
                var newPawn = new Pawn(datas[0], datas[1], new Button(), datas[2], mainWindow);
                //;{pawn.IsFirstMove};{pawn.IsFirstMoveKing};{pawn.IsLeftRookFirstMove};{pawn.IsRightRookFirstMove}
                newPawn.IsFirstMove = bool.Parse(datas[3]);
                newPawn.IsFirstMoveKing = bool.Parse(datas[4]);
                newPawn.IsLeftRookFirstMove = bool.Parse(datas[5]);
                newPawn.IsRightRookFirstMove = bool.Parse(datas[6]);
                pawnListBlack.Add(newPawn);
            }


            var pawnList = new List<Pawn>();
            pawnList.AddRange(pawnListWhite);
            pawnList.AddRange(pawnListBlack);mainWindow.PawnList = pawnList;

            using (var chess2UtilsNotStatic = new Chess2UtilsNotStatic())
            {
                var nodeResult = mainWindow.GetBestPositionLocalNotTask(mainWindow.ComputerColore);
                //Position final du rook blanch  ne doit pas etre "a7"
                Assert.AreNotEqual(nodeResult.BestChildPosition, "h2");
            }
        }

        [TestMethod]
        public void MTT05LeFousBlacheDoitSeSaccrifierPourProtegerLeRook()
        {
            /*Le Fous blanc doit attaquer le pion noir
             * les noirs*/
            //Position final du Fous blanch  doit etre "a7"




            
            var mainWindow = new MainWindow(); mainWindow.SetTurnNumberLabel("5");mainWindow.ComputerColore = "White";
            





            var pawnListWhite = new List<Pawn>();
            var pawnListBlack = new List<Pawn>();


            //WHITEList
            var whiteListString = "Rook;a1;White;False;False;False;False" +
      "\nSimplePawn;a4;White;False;False;False;False" +
      "\nKnight;b1;White;False;False;False;False" +
      "\nBishop;e3;White;False;False;False;False" +
      "\nSimplePawn;c2;White;True;False;False;False" +
      "\nQueen;d1;White;False;False;False;False" +
      "\nSimplePawn;d3;White;False;False;False;False" +
      "\nKing;e1;White;False;True;True;True" +
      "\nSimplePawn;e2;White;True;False;False;False" +
      "\nBishop;f1;White;False;False;False;False" +
      "\nSimplePawn;f2;White;True;False;False;False" +
      "\nKnight;g1;White;False;False;False;False" +
      "\nSimplePawn;g2;White;True;False;False;False" +
      "\nRook;h1;White;False;False;False;False" +
      "\nSimplePawn;h2;White;True;False;False;False";
            var whiteList = whiteListString.Split('\n');
            foreach (var line in whiteList)
            {
                var datas = line.Split(';');
                var newPawn = new Pawn(datas[0], datas[1], new Button(), datas[2], mainWindow);
                //;{pawn.IsFirstMove};{pawn.IsFirstMoveKing};{pawn.IsLeftRookFirstMove};{pawn.IsRightRookFirstMove}
                newPawn.IsFirstMove = bool.Parse(datas[3]);
                newPawn.IsFirstMoveKing = bool.Parse(datas[4]);
                newPawn.IsLeftRookFirstMove = bool.Parse(datas[5]);
                newPawn.IsRightRookFirstMove = bool.Parse(datas[6]);
                pawnListWhite.Add(newPawn);
            }

            //BLACKList
            var blackListString = "" +
             "SimplePawn;a7;Black;True;False;False;False" +
      "\nRook;a8;Black;False;False;False;False" +
      "\nSimplePawn;b7;Black;True;False;False;False" +
      "\nKnight;b8;Black;False;False;False;False" +
      "\nSimplePawn;c7;Black;True;False;False;False" +
      "\nBishop;c8;Black;False;False;False;False" +
      "\nSimplePawn;d7;Black;True;False;False;False" +
      "\nQueen;b2;Black;False;False;False;False" +
      "\nSimplePawn;e6;Black;False;False;False;False" +
      "\nKing;e8;Black;False;True;True;True" +
      "\nSimplePawn;f7;Black;True;False;False;False" +
      "\nBishop;d6;Black;False;False;False;False" +
      "\nSimplePawn;g7;Black;True;False;False;False" +
      "\nKnight;g8;Black;False;False;False;False" +
      "\nSimplePawn;h7;Black;True;False;False;False" +
      "\nRook;h8;Black;False;False;False;False";
            var blackList = blackListString.Split('\n');
            foreach (var line in blackList)
            {
                var datas = line.Split(';');
                var newPawn = new Pawn(datas[0], datas[1], new Button(), datas[2], mainWindow);
                //;{pawn.IsFirstMove};{pawn.IsFirstMoveKing};{pawn.IsLeftRookFirstMove};{pawn.IsRightRookFirstMove}
                newPawn.IsFirstMove = bool.Parse(datas[3]);
                newPawn.IsFirstMoveKing = bool.Parse(datas[4]);
                newPawn.IsLeftRookFirstMove = bool.Parse(datas[5]);
                newPawn.IsRightRookFirstMove = bool.Parse(datas[6]);
                pawnListBlack.Add(newPawn);
            }


            var pawnList = new List<Pawn>();
            pawnList.AddRange(pawnListWhite);
            pawnList.AddRange(pawnListBlack);mainWindow.PawnList = pawnList;

            using (var chess2UtilsNotStatic = new Chess2UtilsNotStatic())
            {
                var nodeResult = mainWindow.GetBestPositionLocalNotTask(mainWindow.ComputerColore);
                Assert.AreNotEqual(nodeResult.BestChildPosition, "c4");
            }
        }



        [TestMethod]
        public void MTT07aEchecRookBlancDoitAttaquerLeRoiNoir()
        {
            /*Le Rook blanc doit attaquer le roir noir pout  MTTout de suite mettre en echec 
             * les noirs*/
            //Position final du rook blanch  doit etre "d8"


            var mainWindow = new MainWindow(); mainWindow.SetTurnNumberLabel("5"); mainWindow.ComputerColore = "White";
            var testName = "T07aEchecRookBlancDoitAttaquerLeRoiNoir";
            var testPath = Path.Combine(testsDirrectory, testName);
            mainWindow.LoadFromDirectorie(testPath);
            using (var chess2UtilsNotStatic = new Chess2UtilsNotStatic())
            {

                var nodeResult = mainWindow.GetBestPositionLocalNotTask(mainWindow.ComputerColore);





                Assert.AreEqual(nodeResult.BestChildPosition, "d8");
            }
           /* var nodeResult = mainWindow.GetBestPositionLocalNotTask(mainWindow.ComputerColore);
                Assert.AreEqual(nodeResult.AsssociateNodeChess2.RandomEquivalentList.Count, 0);
                //rook blanch  doit etre "d8"
                // Assert.AreEqual(nodeResult.AssociatePawn.Name, "Rook");
                Assert.AreEqual(nodeResult.BestChildPosition, "d8");
            }*/
        }


        [TestMethod]
        public void MTT07bEchecRookOuReineBlancDoitAttaquerLeRoiNoir()
        {
            /*Le Rook ou la reinne blanc doit attaquer le roir noir pout  MTTout de suite mettre en echec 
             * les noirs*/
            //Position final  blanche  doit etre "d8" ou "e8"


            var mainWindow = new MainWindow(); mainWindow.SetTurnNumberLabel("5"); mainWindow.ComputerColore = "White";
            var testName = "T07bEchecRookOuReineBlancDoitAttaquerLeRoiNoir";
            var testPath = Path.Combine(testsDirrectory, testName);
            mainWindow.LoadFromDirectorie(testPath);
            using (var chess2UtilsNotStatic = new Chess2UtilsNotStatic())
            {

                var nodeResult = mainWindow.GetBestPositionLocalNotTask(mainWindow.ComputerColore);





                Assert.AreEqual(nodeResult.AsssociateNodeChess2.RandomEquivalentList.Count, 0);

                var isSucces = false;
                if (nodeResult.BestChildPosition == "d8" || nodeResult.BestChildPosition == "e8")
                    isSucces = true;
                Assert.IsTrue(isSucces);
            }

           
        }


        [TestMethod]
        public void MTT11LaReineBlancNeDoitPasAttaqueLePion()
        {
            /*La reine blanc ne doit pas attaquer le pion noir en g6*/
            //la reine blanche ne doit se mettre sur "g6"




            
            var mainWindow = new MainWindow(); mainWindow.SetTurnNumberLabel("5");mainWindow.ComputerColore = "White";
            






            var pawnListWhite = new List<Pawn>();
            var pawnListBlack = new List<Pawn>();



            //WHITEList
            var whiteListString = "Rook;a1;White;False;False;False;False" +
      "\nSimplePawn;a2;White;True;False;False;False" +
      "\nKnight;b1;White;False;False;False;False" +
      "\nSimplePawn;b2;White;True;False;False;False" +
      "\nBishop;c1;White;False;False;False;False" +
      "\nSimplePawn;c3;White;False;False;False;False" +
      "\nQueen;c2;White;False;False;False;False" +
      "\nSimplePawn;d2;White;True;False;False;False" +
      "\nKing;e1;White;False;True;True;True" +
      "\nSimplePawn;e2;White;True;False;False;False" +
      "\nBishop;f1;White;False;False;False;False" +
      "\nSimplePawn;f2;White;True;False;False;False" +
      "\nKnight;g1;White;False;False;False;False" +
      "\nSimplePawn;g2;White;True;False;False;False" +
      "\nRook;h1;White;False;False;False;False" +
      "\nSimplePawn; h2; White;  true; False; False; False";
            var whiteList = whiteListString.Split('\n');
            foreach (var line in whiteList)
            {
                var datas = line.Split(';');
                var newPawn = new Pawn(datas[0], datas[1], new Button(), datas[2], mainWindow);
                //;{pawn.IsFirstMove};{pawn.IsFirstMoveKing};{pawn.IsLeftRookFirstMove};{pawn.IsRightRookFirstMove}
                newPawn.IsFirstMove = bool.Parse(datas[3]);
                newPawn.IsFirstMoveKing = bool.Parse(datas[4]);
                newPawn.IsLeftRookFirstMove = bool.Parse(datas[5]);
                newPawn.IsRightRookFirstMove = bool.Parse(datas[6]);
                pawnListWhite.Add(newPawn);
            }

            //BLACKList
            var blackListString = "SimplePawn;a7;Black;True;False;False;False" +
      "\nRook;a8;Black;False;False;False;False" +
      "\nSimplePawn;b7;Black;True;False;False;False" +
      "\nKnight;b8;Black;False;False;False;False" +
      "\nSimplePawn;c7;Black;True;False;False;False" +
      "\nBishop;c8;Black;False;False;False;False" +
      "\nSimplePawn;d7;Black;True;False;False;False" +
      "\nQueen;d8;Black;False;False;False;False" +
      "\nSimplePawn;e6;Black;False;False;False;False" +
      "\nKing;e8;Black;False;True;True;True" +
      "\nSimplePawn;f7;Black;True;False;False;False" +
      "\nBishop;f8;Black;False;False;False;False" +
      "\nSimplePawn;g6;Black;False;False;False;False" +
      "\nKnight;g8;Black;False;False;False;False" +
      "\nSimplePawn;h7;Black;True;False;False;False" +
      "\nRook;h8;Black;False;False;False;False";
            var blackList = blackListString.Split('\n');
            foreach (var line in blackList)
            {
                var datas = line.Split(';');
                var newPawn = new Pawn(datas[0], datas[1], new Button(), datas[2], mainWindow);
                //;{pawn.IsFirstMove};{pawn.IsFirstMoveKing};{pawn.IsLeftRookFirstMove};{pawn.IsRightRookFirstMove}
                newPawn.IsFirstMove = bool.Parse(datas[3]);
                newPawn.IsFirstMoveKing = bool.Parse(datas[4]);
                newPawn.IsLeftRookFirstMove = bool.Parse(datas[5]);
                newPawn.IsRightRookFirstMove = bool.Parse(datas[6]);
                pawnListBlack.Add(newPawn);
            }



            var pawnList = new List<Pawn>();
            pawnList.AddRange(pawnListWhite);
            pawnList.AddRange(pawnListBlack);mainWindow.PawnList = pawnList;

            using (var chess2UtilsNotStatic = new Chess2UtilsNotStatic())
            {
                var nodeResult = mainWindow.GetBestPositionLocalNotTask(mainWindow.ComputerColore);
                //la reine blanche ne doit se mettre sur "g6"
                Assert.AreNotEqual(nodeResult.BestChildPosition, "g6");
            }
        }


        [TestMethod]
        public void MTT15LaReineBlanchNeDoitPasPrendreLePion()
        {
            /*La reine blanc ne doit pas attaquer le pion noir en a6*/
            ////la reine blanche ne doit se mettre sur "a6"




            
            var mainWindow = new MainWindow(); mainWindow.SetTurnNumberLabel("5");mainWindow.ComputerColore = "White";





            
            var pawnListWhite = new List<Pawn>();
            var pawnListBlack = new List<Pawn>();



            //WHITEList
            var whiteListString = "" +
              "SimplePawn;a2;White;True;False;False;False" +
              "\nSimplePawn;a3;White;False;False;False;False" +
      "\nSimplePawn;c3;White;False;False;False;False" +
      "\nSimplePawn;d3;White;False;False;False;False" +
      "\nSimplePawn;e3;White;False;False;False;False" +
      "\nSimplePawn;f2;White;True;False;False;False" +
      "\nSimplePawn;g2;White;True;False;False;False" +
      "\nSimplePawn;h2;White;True;False;False;False" +
      "\nKnight;g1;White;False;False;False;False" +
      "\nBishop;b2;White;False;False;False;False" +
      "\nBishop;f1;White;False;False;False;False" +
      "\nRook;a1;White;False;False;False;False" +
      "\nRook;h1;White;False;False;False;False" +
      "\nQueen;a4;White;False;False;False;False" +
      "\nKing;e2;White;False;False;True;True";
            var whiteList = whiteListString.Split('\n');
            foreach (var line in whiteList)
            {
                var datas = line.Split(';');
                var newPawn = new Pawn(datas[0], datas[1], new Button(), datas[2], mainWindow);
                //;{pawn.IsFirstMove};{pawn.IsFirstMoveKing};{pawn.IsLeftRookFirstMove};{pawn.IsRightRookFirstMove}
                newPawn.IsFirstMove = bool.Parse(datas[3]);
                newPawn.IsFirstMoveKing = bool.Parse(datas[4]);
                newPawn.IsLeftRookFirstMove = bool.Parse(datas[5]);
                newPawn.IsRightRookFirstMove = bool.Parse(datas[6]);
                pawnListWhite.Add(newPawn);
            }

            //BLACKList
            var blackListString = "" +
              "SimplePawn;a6;Black;False;False;False;False" +
              "\nSimplePawn;b7;Black;True;False;False;False" +
      "\nSimplePawn;c7;Black;True;False;False;False" +
      "\nSimplePawn;d5;Black;False;False;False;False" +
      "\nSimplePawn;e6;Black;False;False;False;False" +
      "\nSimplePawn;f7;Black;True;False;False;False" +
      "\nSimplePawn;g7;Black;True;False;False;False" +
      "\nSimplePawn;h7;Black;True;False;False;False" +
      "\nKnight;b8;Black;False;False;False;False" +
      "\nKnight;f6;Black;False;False;False;False" +
      "\nRook;a8;Black;False;False;False;False" +
      "\nRook;f8;Black;False;False;False;False" +
      "\nQueen;d8;Black;False;False;False;False" +
      "\nKing;g8;Black;False;True;True;True";
            var blackList = blackListString.Split('\n');
            foreach (var line in blackList)
            {
                var datas = line.Split(';');
                var newPawn = new Pawn(datas[0], datas[1], new Button(), datas[2], mainWindow);
                //;{pawn.IsFirstMove};{pawn.IsFirstMoveKing};{pawn.IsLeftRookFirstMove};{pawn.IsRightRookFirstMove}
                newPawn.IsFirstMove = bool.Parse(datas[3]);
                newPawn.IsFirstMoveKing = bool.Parse(datas[4]);
                newPawn.IsLeftRookFirstMove = bool.Parse(datas[5]);
                newPawn.IsRightRookFirstMove = bool.Parse(datas[6]);
                pawnListBlack.Add(newPawn);
            }


            var pawnList = new List<Pawn>();
            pawnList.AddRange(pawnListWhite);
            pawnList.AddRange(pawnListBlack);mainWindow.PawnList = pawnList;


            using (var chess2UtilsNotStatic = new Chess2UtilsNotStatic())
            {
                var nodeResult = mainWindow.GetBestPositionLocalNotTask(mainWindow.ComputerColore);
                //la reine blanche ne doit se mettre sur "a6"
                Assert.AreNotEqual(nodeResult.BestChildPosition, "a6");
            }
        }

        [TestMethod]
        public void MTT16SeulLePionDoitProtegerLeRoiNoir()
        {
            /*seul le poin doit prot�ger le roi noir*/
            ////le poin noir doit se mettre sur "f6"




            
            var mainWindow = new MainWindow(); mainWindow.SetTurnNumberLabel("5");mainWindow.ComputerColore = "Black";



            
            var pawnListWhite = new List<Pawn>();
            var pawnListBlack = new List<Pawn>();



            //WHITEList
            var whiteListString = "" +
              "King;e1;White;False;True;True;True" +
      "\nQueen;f3;White;False;False;False;False" +
      "\nRook;a1;White;False;False;False;False" +
      "\nRook;h1;White;False;False;False;False" +
      "\nBishop;g5;White;False;False;False;False" +
      "\nBishop;c4;White;False;False;False;False" +
      "\nKnight;b1;White;False;False;False;False" +
      "\nKnight;g1;White;False;False;False;False" +
      "\nSimplePawn;a2;White;True;False;False;False" +
      "\nSimplePawn;b2;White;True;False;False;False" +
      "\nSimplePawn;d4;White;False;False;False;False" +
      "\nSimplePawn;e4;White;False;False;False;False" +
      "\nSimplePawn;f2;White;True;False;False;False" +
      "\nSimplePawn;g2;White;True;False;False;False" +
      "\nSimplePawn;h2;White;True;False;False;False";
            var whiteList = whiteListString.Split('\n');
            foreach (var line in whiteList)
            {
                var datas = line.Split(';');
                var newPawn = new Pawn(datas[0], datas[1], new Button(), datas[2], mainWindow);
                //;{pawn.IsFirstMove};{pawn.IsFirstMoveKing};{pawn.IsLeftRookFirstMove};{pawn.IsRightRookFirstMove}
                newPawn.IsFirstMove = bool.Parse(datas[3]);
                newPawn.IsFirstMoveKing = bool.Parse(datas[4]);
                newPawn.IsLeftRookFirstMove = bool.Parse(datas[5]);
                newPawn.IsRightRookFirstMove = bool.Parse(datas[6]);
                pawnListWhite.Add(newPawn);
            }

            //BLACKList
            var blackListString = "" +
              "King;e7;Black;False;False;True;True" +
      "\nQueen;d8;Black;False;False;False;False" +
      "\nRook;a8;Black;False;False;False;False" +
      "\nRook;h8;Black;False;False;False;False" +
      "\nBishop;c8;Black;False;False;False;False" +
      "\nBishop;f8;Black;False;False;False;False" +
      "\nKnight;b8;Black;False;False;False;False" +
      "\nKnight;g8;Black;False;False;False;False" +
      "\nSimplePawn;a7;Black;True;False;False;False" +
      "\nSimplePawn;b6;Black;False;False;False;False" +
      "\nSimplePawn;c7;Black;True;False;False;False" +
      "\nSimplePawn;d7;Black;True;False;False;False" +
      "\nSimplePawn;f7;Black;True;False;False;False" +
      "\nSimplePawn;g6;Black;False;False;False;False" +
      "\nSimplePawn;h7;Black;True;False;False;False";
            var blackList = blackListString.Split('\n');
            foreach (var line in blackList)
            {
                var datas = line.Split(';');
                var newPawn = new Pawn(datas[0], datas[1], new Button(), datas[2], mainWindow);
                //;{pawn.IsFirstMove};{pawn.IsFirstMoveKing};{pawn.IsLeftRookFirstMove};{pawn.IsRightRookFirstMove}
                newPawn.IsFirstMove = bool.Parse(datas[3]);
                newPawn.IsFirstMoveKing = bool.Parse(datas[4]);
                newPawn.IsLeftRookFirstMove = bool.Parse(datas[5]);
                newPawn.IsRightRookFirstMove = bool.Parse(datas[6]);
                pawnListBlack.Add(newPawn);
            }



            var pawnList = new List<Pawn>();
            pawnList.AddRange(pawnListWhite);
            pawnList.AddRange(pawnListBlack);mainWindow.PawnList = pawnList;
           
            using (var chess2UtilsNotStatic = new Chess2UtilsNotStatic())
            {
                var nodeResult = mainWindow.GetBestPositionLocalNotTask(mainWindow.ComputerColore);
                ////le poin noir  doit se mettre sur "f6"
                //Assert.AreEqual(nodeResult.AssociatePawn.Name, "SimplePawn");
                Assert.AreEqual(nodeResult.BestChildPosition, "f6");
            }
        }


        [TestMethod]
        public void MTT17LeRoirNoirNeDoitPasAttaquer()
        {
            /*le roi noir ne doit pas attaquer */
            ////le roi noir ne doit pas se mettre sur "f6"




            
            var mainWindow = new MainWindow(); mainWindow.SetTurnNumberLabel("5");mainWindow.ComputerColore = "Black";



            
            var pawnListWhite = new List<Pawn>();
            var pawnListBlack = new List<Pawn>();



            //WHITEList
            var whiteListString = "" +
              "King;e1;White;False;True;True;True" +
      "\nQueen;f3;White;False;False;False;False" +
      "\nRook;a1;White;False;False;False;False" +
      "\nRook;h1;White;False;False;False;False" +
      "\nBishop;f6;White;False;False;False;False" +
      "\nBishop;c4;White;False;False;False;False" +
      "\nKnight;b1;White;False;False;False;False" +
      "\nKnight;g1;White;False;False;False;False" +
      "\nSimplePawn;a2;White;True;False;False;False" +
      "\nSimplePawn;b2;White;True;False;False;False" +
      "\nSimplePawn;d4;White;False;False;False;False" +
      "\nSimplePawn;e4;White;False;False;False;False" +
      "\nSimplePawn;f2;White;True;False;False;False" +
      "\nSimplePawn;g2;White;True;False;False;False" +
      "\nSimplePawn;h2;White;True;False;False;False";
            var whiteList = whiteListString.Split('\n');
            foreach (var line in whiteList)
            {
                var datas = line.Split(';');
                var newPawn = new Pawn(datas[0], datas[1], new Button(), datas[2], mainWindow);
                //;{pawn.IsFirstMove};{pawn.IsFirstMoveKing};{pawn.IsLeftRookFirstMove};{pawn.IsRightRookFirstMove}
                newPawn.IsFirstMove = bool.Parse(datas[3]);
                newPawn.IsFirstMoveKing = bool.Parse(datas[4]);
                newPawn.IsLeftRookFirstMove = bool.Parse(datas[5]);
                newPawn.IsRightRookFirstMove = bool.Parse(datas[6]);
                pawnListWhite.Add(newPawn);
            }

            //BLACKList
            var blackListString = "" +
              "King;e7;Black;False;False;True;True" +
      "\nQueen;d8;Black;False;False;False;False" +
      "\nRook;a8;Black;False;False;False;False" +
      "\nRook;h8;Black;False;False;False;False" +
      "\nBishop;c8;Black;False;False;False;False" +
      "\nBishop;f8;Black;False;False;False;False" +
      "\nKnight;b8;Black;False;False;False;False" +
      "\nSimplePawn;a7;Black;True;False;False;False" +
      "\nSimplePawn;b6;Black;False;False;False;False" +
      "\nSimplePawn;c7;Black;True;False;False;False" +
      "\nSimplePawn;d7;Black;True;False;False;False" +
      "\nSimplePawn;f7;Black;True;False;False;False" +
      "\nSimplePawn;g6;Black;False;False;False;False" +
      "\nSimplePawn;h7;Black;True;False;False;False";
            var blackList = blackListString.Split('\n');
            foreach (var line in blackList)
            {
                var datas = line.Split(';');
                var newPawn = new Pawn(datas[0], datas[1], new Button(), datas[2], mainWindow);
                //;{pawn.IsFirstMove};{pawn.IsFirstMoveKing};{pawn.IsLeftRookFirstMove};{pawn.IsRightRookFirstMove}
                newPawn.IsFirstMove = bool.Parse(datas[3]);
                newPawn.IsFirstMoveKing = bool.Parse(datas[4]);
                newPawn.IsLeftRookFirstMove = bool.Parse(datas[5]);
                newPawn.IsRightRookFirstMove = bool.Parse(datas[6]);
                pawnListBlack.Add(newPawn);
            }


            var pawnList = new List<Pawn>();
            pawnList.AddRange(pawnListWhite);
            pawnList.AddRange(pawnListBlack);mainWindow.PawnList = pawnList;


            using (var chess2UtilsNotStatic = new Chess2UtilsNotStatic())
            {
                var nodeResult = mainWindow.GetBestPositionLocalNotTask(mainWindow.ComputerColore);
                ////le roi noir ne doit pas se mettre sur "f6"
                //Assert.AreNotEqual(nodeResult.AssociatePawn.Name, "King");
                Assert.AreNotEqual(nodeResult.BestChildPosition, "f6");
            }
        }

        [TestMethod]
        public void MTT18suiteDe16LeCavalierNoirDoitPrendreLeFouBlanc()
        {
            /*le cavalier noir  doit  attaquer */
            ////le cavalier noir  doit se mettre sur "f6"




            
            var mainWindow = new MainWindow(); mainWindow.SetTurnNumberLabel("5");mainWindow.ComputerColore = "Black";



            
            var pawnListWhite = new List<Pawn>();
            var pawnListBlack = new List<Pawn>();



            //WHITEList
            var whiteListString = "" +
              "King;e1;White;False;True;True;True" +
      "\nQueen;f3;White;False;False;False;False" +
      "\nRook;a1;White;False;False;False;False" +
      "\nRook;h1;White;False;False;False;False" +
      "\nBishop;f6;White;False;False;False;False" +
      "\nBishop;c4;White;False;False;False;False" +
      "\nKnight;b1;White;False;False;False;False" +
      "\nKnight;g1;White;False;False;False;False" +
      "\nSimplePawn;a2;White;True;False;False;False" +
      "\nSimplePawn;b2;White;True;False;False;False" +
      "\nSimplePawn;d4;White;False;False;False;False" +
      "\nSimplePawn;e4;White;False;False;False;False" +
      "\nSimplePawn;f2;White;True;False;False;False" +
      "\nSimplePawn;g2;White;True;False;False;False" +
      "\nSimplePawn;h2;White;True;False;False;False";
            var whiteList = whiteListString.Split('\n');
            foreach (var line in whiteList)
            {
                var datas = line.Split(';');
                var newPawn = new Pawn(datas[0], datas[1], new Button(), datas[2], mainWindow);
                //;{pawn.IsFirstMove};{pawn.IsFirstMoveKing};{pawn.IsLeftRookFirstMove};{pawn.IsRightRookFirstMove}
                newPawn.IsFirstMove = bool.Parse(datas[3]);
                newPawn.IsFirstMoveKing = bool.Parse(datas[4]);
                newPawn.IsLeftRookFirstMove = bool.Parse(datas[5]);
                newPawn.IsRightRookFirstMove = bool.Parse(datas[6]);
                pawnListWhite.Add(newPawn);
            }

            //BLACKList
            var blackListString = "" +
              "King;e7;Black;False;False;True;True" +
      "\nQueen;d8;Black;False;False;False;False" +
      "\nRook;a8;Black;False;False;False;False" +
      "\nRook;h8;Black;False;False;False;False" +
      "\nBishop;c8;Black;False;False;False;False" +
      "\nBishop;f8;Black;False;False;False;False" +
      "\nKnight;b8;Black;False;False;False;False" +
      "\nKnight;g8;Black;False;False;False;False" +
      "\nSimplePawn;a7;Black;True;False;False;False" +
      "\nSimplePawn;b6;Black;False;False;False;False" +
      "\nSimplePawn;c7;Black;True;False;False;False" +
      "\nSimplePawn;d7;Black;True;False;False;False" +
      "\nSimplePawn;g6;Black;False;False;False;False" +
      "\nSimplePawn;h7;Black;True;False;False;False";
            var blackList = blackListString.Split('\n');
            foreach (var line in blackList)
            {
                var datas = line.Split(';');
                var newPawn = new Pawn(datas[0], datas[1], new Button(), datas[2], mainWindow);
                //;{pawn.IsFirstMove};{pawn.IsFirstMoveKing};{pawn.IsLeftRookFirstMove};{pawn.IsRightRookFirstMove}
                newPawn.IsFirstMove = bool.Parse(datas[3]);
                newPawn.IsFirstMoveKing = bool.Parse(datas[4]);
                newPawn.IsLeftRookFirstMove = bool.Parse(datas[5]);
                newPawn.IsRightRookFirstMove = bool.Parse(datas[6]);
                pawnListBlack.Add(newPawn);
            }


            var pawnList = new List<Pawn>();pawnList.AddRange(pawnListWhite);pawnList.AddRange(pawnListBlack);mainWindow.PawnList = pawnList;


            using (var chess2UtilsNotStatic = new Chess2UtilsNotStatic())
            {
                var nodeResult = mainWindow.GetBestPositionLocalNotTask(mainWindow.ComputerColore);
                ////le cavalier noir  doit se mettre sur "f6"
                //Assert.AreEqual(nodeResult.AssociatePawn.Name, "Knight");
                Assert.AreEqual(nodeResult.BestChildPosition, "f6");
            }
        }


        [TestMethod]
        public void MTT19bLeFouBlanchDoitnenacerLaReineOulePionDoitProtegerLeTour()
        {
            ////////le poin blanch doit se mettre sur ""




            
            var mainWindow = new MainWindow(); mainWindow.SetTurnNumberLabel("5");mainWindow.ComputerColore = "White";





            
            var pawnListWhite = new List<Pawn>();
            var pawnListBlack = new List<Pawn>();



            //WHITEList
            var whiteListString = "" +
      "King;e1;White;False;True;True;True" +
      "\nQueen;d1;White;False;False;False;False" +
      "\nRook;a1;White;False;False;False;False" +
      "\nRook;h1;White;False;False;False;False" +
      "\nBishop;c1;White;False;False;False;False" +
      "\nKnight;b1;White;False;False;False;False" +
      "\nKnight;g1;White;False;False;False;False" +
      "\nSimplePawn;a2;White;True;False;False;False" +
      "\nSimplePawn;b3;White;False;False;False;False" +
      "\nSimplePawn;c2;White;True;False;False;False" +
      "\nSimplePawn;d2;White;True;False;False;False" +
      "\nSimplePawn;e3;White;False;False;False;False" +
      "\nSimplePawn;f3;White;False;False;False;False" +
      "\nSimplePawn;g2;White;True;False;False;False" +
      "\nSimplePawn;h3;White;False;False;False;False";
            var whiteList = whiteListString.Split('\n');
            foreach (var line in whiteList)
            {
                var datas = line.Split(';');
                var newPawn = new Pawn(datas[0], datas[1], new Button(), datas[2], mainWindow);
                //;{pawn.IsFirstMove};{pawn.IsFirstMoveKing};{pawn.IsLeftRookFirstMove};{pawn.IsRightRookFirstMove}
                newPawn.IsFirstMove = bool.Parse(datas[3]);
                newPawn.IsFirstMoveKing = bool.Parse(datas[4]);
                newPawn.IsLeftRookFirstMove = bool.Parse(datas[5]);
                newPawn.IsRightRookFirstMove = bool.Parse(datas[6]);
                pawnListWhite.Add(newPawn);
            }

            //BLACKList
            var blackListString = "" +
              "King;e8;Black;False;True;True;True" +
      "\nQueen;d6;Black;False;False;False;False" +
      "\nRook;a8;Black;False;False;False;False" +
      "\nRook;h8;Black;False;False;False;False" +
      "\nBishop;c8;Black;False;False;False;False" +
      "\nBishop;g7;Black;False;False;False;False" +
      "\nKnight;b8;Black;False;False;False;False" +
      "\nKnight;g8;Black;False;False;False;False" +
      "\nSimplePawn;a7;Black;True;False;False;False" +
      "\nSimplePawn;b7;Black;True;False;False;False" +
      "\nSimplePawn;c7;Black;True;False;False;False" +
      "\nSimplePawn;d5;Black;False;False;False;False" +
      "\nSimplePawn;e7;Black;True;False;False;False" +
      "\nSimplePawn;f7;Black;True;False;False;False" +
      "\nSimplePawn;g5;Black;False;False;False;False" +
      "\nSimplePawn;h7;Black;True;False;False;False";
            var blackList = blackListString.Split('\n');
            foreach (var line in blackList)
            {
                var datas = line.Split(';');
                var newPawn = new Pawn(datas[0], datas[1], new Button(), datas[2], mainWindow);
                //;{pawn.IsFirstMove};{pawn.IsFirstMoveKing};{pawn.IsLeftRookFirstMove};{pawn.IsRightRookFirstMove}
                newPawn.IsFirstMove = bool.Parse(datas[3]);
                newPawn.IsFirstMoveKing = bool.Parse(datas[4]);
                newPawn.IsLeftRookFirstMove = bool.Parse(datas[5]);
                newPawn.IsRightRookFirstMove = bool.Parse(datas[6]);
                pawnListBlack.Add(newPawn);
            }



            var pawnList = new List<Pawn>();pawnList.AddRange(pawnListWhite);pawnList.AddRange(pawnListBlack);mainWindow.PawnList = pawnList;

            using (var chess2UtilsNotStatic = new Chess2UtilsNotStatic())
            {
                var nodeResult = mainWindow.GetBestPositionLocalNotTask(mainWindow.ComputerColore);

                var randomList = nodeResult.AsssociateNodeChess2.RandomEquivalentList;
                //Assert.IsNull(randomList);
                ////////le poin blanch doit se mettre sur "c3"
                var isSucces = false;
                if (nodeResult.BestChildPosition == "d4" || nodeResult.BestChildPosition == "c3" || nodeResult.BestChildPosition == "a3")
                    isSucces = true;
                Assert.IsTrue(isSucces);
            }
        }



        [TestMethod]
        public void MTT20LePionDoitPrendreLeCavalier()
        {
            /*le pion blanch doit prendre le cavalier */
            ////le pion blanch doit se mettre sur "d3"




            
            var mainWindow = new MainWindow(); mainWindow.SetTurnNumberLabel("5");mainWindow.ComputerColore = "White";





            
            var pawnListWhite = new List<Pawn>();
            var pawnListBlack = new List<Pawn>();



            //WHITEList
            var whiteListString = "" +
              "King;e1;White;False;True;True;True" +
      "\nQueen;d1;White;False;False;False;False" +
      "\nRook;a1;White;False;False;False;False" +
      "\nRook;h1;White;False;False;False;False" +
      "\nBishop;d2;White;False;False;False;False" +
      "\nBishop;f1;White;False;False;False;False" +
      "\nKnight;b1;White;False;False;False;False" +
      "\nKnight;g1;White;False;False;False;False" +
      "\nSimplePawn;b3;White;False;False;False;False" +
      "\nSimplePawn;c3;White;False;False;False;False" +
      "\nSimplePawn;e2;White;True;False;False;False" +
      "\nSimplePawn;h4;White;False;False;False;False";
            var whiteList = whiteListString.Split('\n');
            foreach (var line in whiteList)
            {
                var datas = line.Split(';');
                var newPawn = new Pawn(datas[0], datas[1], new Button(), datas[2], mainWindow);
                //;{pawn.IsFirstMove};{pawn.IsFirstMoveKing};{pawn.IsLeftRookFirstMove};{pawn.IsRightRookFirstMove}
                newPawn.IsFirstMove = bool.Parse(datas[3]);
                newPawn.IsFirstMoveKing = bool.Parse(datas[4]);
                newPawn.IsLeftRookFirstMove = bool.Parse(datas[5]);
                newPawn.IsRightRookFirstMove = bool.Parse(datas[6]);
                pawnListWhite.Add(newPawn);
            }

            //BLACKList
            var blackListString = "" +
              "King;e8;Black;False;True;True;True" +
      "\nQueen;d8;Black;False;False;False;False" +
      "\nRook;a8;Black;False;False;False;False" +
      "\nRook;h8;Black;False;False;False;False" +
      "\nBishop;g4;Black;False;False;False;False" +
      "\nKnight;d3;Black;False;False;False;False" +
      "\nKnight;e4;Black;False;False;False;False" +
      "\nSimplePawn;a7;Black;True;False;False;False" +
      "\nSimplePawn;b7;Black;True;False;False;False" +
      "\nSimplePawn;c7;Black;True;False;False;False" +
      "\nSimplePawn;f7;Black;True;False;False;False" +
      "\nSimplePawn;g7;Black;True;False;False;False" +
      "\nSimplePawn;h7;Black;True;False;False;False";
            var blackList = blackListString.Split('\n');
            foreach (var line in blackList)
            {
                var datas = line.Split(';');
                var newPawn = new Pawn(datas[0], datas[1], new Button(), datas[2], mainWindow);
                //;{pawn.IsFirstMove};{pawn.IsFirstMoveKing};{pawn.IsLeftRookFirstMove};{pawn.IsRightRookFirstMove}
                newPawn.IsFirstMove = bool.Parse(datas[3]);
                newPawn.IsFirstMoveKing = bool.Parse(datas[4]);
                newPawn.IsLeftRookFirstMove = bool.Parse(datas[5]);
                newPawn.IsRightRookFirstMove = bool.Parse(datas[6]);
                pawnListBlack.Add(newPawn);
            }



            var pawnList = new List<Pawn>();pawnList.AddRange(pawnListWhite);pawnList.AddRange(pawnListBlack);mainWindow.PawnList = pawnList;

            using (var chess2UtilsNotStatic = new Chess2UtilsNotStatic())
            {
                var nodeResult = mainWindow.GetBestPositionLocalNotTask(mainWindow.ComputerColore);
                ////le pion blanch doit se mettre sur "d3"
                // Assert.AreEqual(nodeResult.AssociatePawn.Name, "SimplePawn");
                Assert.AreEqual(nodeResult.BestChildPosition, "d3");
            }
        }


        [TestMethod]
        public void MTT21LeRoiBlanchDoitSeMettreEnd3()
        {
            /*La roi blanch doit se mettre en d3*/
            //Positions final du roi blanch doit etre d3 

            
            var mainWindow = new MainWindow(); mainWindow.SetTurnNumberLabel("5");mainWindow.ComputerColore = "White";





            
            var pawnListWhite = new List<Pawn>();
            var pawnListBlack = new List<Pawn>();


            //WHITEList
            var whiteListString = "" +
              "King;e2;White;False;False;True;False" +
      "\nQueen;d1;White;False;False;False;False" +
      "\nRook;a1;White;False;False;False;False" +
      "\nRook;h5;White;False;False;False;False" +
      "\nBishop;c4;White;False;False;False;False" +
      "\nKnight;b1;White;False;False;False;False" +
      "\nKnight;g1;White;False;False;False;False" +
      "\nSimplePawn;a4;White;False;False;False;False" +
      "\nSimplePawn;b5;White;False;False;False;False" +
      "\nSimplePawn;c3;White;False;False;False;False" +
      "\nSimplePawn;d5;White;False;False;False;False";
            var whiteList = whiteListString.Split('\n');
            foreach (var line in whiteList)
            {
                var datas = line.Split(';');
                var newPawn = new Pawn(datas[0], datas[1], new Button(), datas[2], mainWindow);
                //;{pawn.IsFirstMove};{pawn.IsFirstMoveKing};{pawn.IsLeftRookFirstMove};{pawn.IsRightRookFirstMove}
                newPawn.IsFirstMove = bool.Parse(datas[3]);
                newPawn.IsFirstMoveKing = bool.Parse(datas[4]);
                newPawn.IsLeftRookFirstMove = bool.Parse(datas[5]);
                newPawn.IsRightRookFirstMove = bool.Parse(datas[6]);
                pawnListWhite.Add(newPawn);
            }

            //BLACKList
            var blackListString = "" +
            "King;e8;Black;False;True;True;False" +
      "\nQueen;g2;Black;False;False;False;False" +
      "\nRook;a8;Black;False;False;False;False" +
      "\nBishop;c8;Black;False;False;False;False" +
      "\nBishop;h6;Black;False;False;False;False" +
      "\nSimplePawn;a5;Black;False;False;False;False" +
      "\nSimplePawn;b7;Black;True;False;False;False" +
      "\nSimplePawn;c7;Black;True;False;False;False" +
      "\nSimplePawn;e3;Black;False;False;False;False" +
      "\nSimplePawn;e7;Black;True;False;False;False" +
      "\nSimplePawn;f7;Black;True;False;False;False" +
      "\nSimplePawn;g4;Black;False;False;False;False";
            var blackList = blackListString.Split('\n');
            foreach (var line in blackList)
            {
                var datas = line.Split(';');
                var newPawn = new Pawn(datas[0], datas[1], new Button(), datas[2], mainWindow);
                //;{pawn.IsFirstMove};{pawn.IsFirstMoveKing};{pawn.IsLeftRookFirstMove};{pawn.IsRightRookFirstMove}
                newPawn.IsFirstMove = bool.Parse(datas[3]);
                newPawn.IsFirstMoveKing = bool.Parse(datas[4]);
                newPawn.IsLeftRookFirstMove = bool.Parse(datas[5]);
                newPawn.IsRightRookFirstMove = bool.Parse(datas[6]);
                pawnListBlack.Add(newPawn);
            }


            var pawnList = new List<Pawn>();pawnList.AddRange(pawnListWhite);pawnList.AddRange(pawnListBlack);mainWindow.PawnList = pawnList;

            using (var chess2UtilsNotStatic = new Chess2UtilsNotStatic())
            {
                var nodeResult = mainWindow.GetBestPositionLocalNotTask(mainWindow.ComputerColore);
                //Positions final du cavalier Blach ne doit pas etre  ni "a7" ni "c7"
                //Assert.AreNotEqual(nodeResult.BestChildPosition, "a7", "c7");
                // Assert.AreEqual(nodeResult.AssociatePawn.Name, "King");
                Assert.AreEqual(nodeResult.BestChildPosition, "d3");
            }
        }

        [TestMethod]
        public void MTT22LeBishopOuLeRoiNoirDoitPrendreLePion()
        {
            /*Le Bishop Noir Doit Prendre le pion */
            ////le Bishop noir  doit se mettre sur "e7"




            
            var mainWindow = new MainWindow(); mainWindow.SetTurnNumberLabel("5");mainWindow.ComputerColore = "Black";



            
            var pawnListWhite = new List<Pawn>();
            var pawnListBlack = new List<Pawn>();



            //WHITEList
            var whiteListString = "" +
              "King;f1;White;False;False;True;True" +
      "\nQueen;d1;White;False;False;False;False" +
      "\nRook;a1;White;False;False;False;False" +
      "\nRook;h1;White;False;False;False;False" +
      "\nBishop;c1;White;False;False;False;False" +
      "\nKnight;e2;White;False;False;False;False" +
      "\nSimplePawn;a4;White;False;False;False;False" +
      "\nSimplePawn;b2;White;True;False;False;False" +
      "\nSimplePawn;c3;White;False;False;False;False" +
      "\nSimplePawn;e7;White;False;False;False;False" +
      "\nSimplePawn;e4;White;False;False;False;False" +
      "\nSimplePawn;f3;White;False;False;False;False" +
      "\nSimplePawn;g2;White;True;False;False;False" +
      "\nSimplePawn;h2;White;True;False;False;False";
            var whiteList = whiteListString.Split('\n');
            foreach (var line in whiteList)
            {
                var datas = line.Split(';');
                var newPawn = new Pawn(datas[0], datas[1], new Button(), datas[2], mainWindow);
                //;{pawn.IsFirstMove};{pawn.IsFirstMoveKing};{pawn.IsLeftRookFirstMove};{pawn.IsRightRookFirstMove}
                newPawn.IsFirstMove = bool.Parse(datas[3]);
                newPawn.IsFirstMoveKing = bool.Parse(datas[4]);
                newPawn.IsLeftRookFirstMove = bool.Parse(datas[5]);
                newPawn.IsRightRookFirstMove = bool.Parse(datas[6]);
                pawnListWhite.Add(newPawn);
            }

            //BLACKList
            var blackListString = "" +
              "King;e8;Black;False;True;True;True" +
              "\nQueen;c4;Black;False;False;False;False" +
      "\nRook;a8;Black;False;False;False;False" +
      "\nRook;h8;Black;False;False;False;False" +
      "\nBishop;f8;Black;False;False;False;False" +
      "\nSimplePawn;a7;Black;True;False;False;False" +
      "\nSimplePawn;b6;Black;False;False;False;False" +
      "\nSimplePawn;c7;Black;True;False;False;False" +
      "\nSimplePawn;d7;Black;True;False;False;False" +
      "\nSimplePawn;f7;Black;True;False;False;False" +
      "\nSimplePawn;g6;Black;False;False;False;False" +
      "\nSimplePawn;h6;Black;False;False;False;False";
            var blackList = blackListString.Split('\n');
            foreach (var line in blackList)
            {
                var datas = line.Split(';');
                var newPawn = new Pawn(datas[0], datas[1], new Button(), datas[2], mainWindow);
                //;{pawn.IsFirstMove};{pawn.IsFirstMoveKing};{pawn.IsLeftRookFirstMove};{pawn.IsRightRookFirstMove}
                newPawn.IsFirstMove = bool.Parse(datas[3]);
                newPawn.IsFirstMoveKing = bool.Parse(datas[4]);
                newPawn.IsLeftRookFirstMove = bool.Parse(datas[5]);
                newPawn.IsRightRookFirstMove = bool.Parse(datas[6]);
                pawnListBlack.Add(newPawn);
            }



            var pawnList = new List<Pawn>();pawnList.AddRange(pawnListWhite);pawnList.AddRange(pawnListBlack);mainWindow.PawnList = pawnList;

            using (var chess2UtilsNotStatic = new Chess2UtilsNotStatic())
            {
                var nodeResult = mainWindow.GetBestPositionLocalNotTask(mainWindow.ComputerColore);
                var randomList = nodeResult.AsssociateNodeChess2.RandomEquivalentList;
                //  Assert.IsNull(randomList);
                Assert.AreEqual(nodeResult.BestChildPosition, "e7");
            }
        }


        [TestMethod]
        public void MTT23LeCavalierNoirNeDoitPasMenacerLeRoiBlanch()
        {
            /*Le Cavalier noir ne doit pas menacer le roi blanc*/
            ////le Cavalier noir ne doit pas se mettre sur "b3"




            
            var mainWindow = new MainWindow(); mainWindow.SetTurnNumberLabel("5");mainWindow.ComputerColore = "Black";



            
            var pawnListWhite = new List<Pawn>();
            var pawnListBlack = new List<Pawn>();



            //WHITEList
            var whiteListString = "" +
              "King;d2;White;False;False;True;True" +
      "\nQueen;f3;White;False;False;False;False" +
      "\nRook;h1;White;False;False;False;False" +
      "\nBishop;c1;White;False;False;False;False" +
      "\nBishop;c4;White;False;False;False;False" +
      "\nKnight;b1;White;False;False;False;False" +
      "\nKnight;g1;White;False;False;False;False" +
      "\nSimplePawn;a2;White;True;False;False;False" +
      "\nSimplePawn;b2;White;True;False;False;False" +
      "\nSimplePawn;d4;White;False;False;False;False" +
      "\nSimplePawn;e3;White;False;False;False;False" +
      "\nSimplePawn;f2;White;True;False;False;False" +
      "\nSimplePawn;h2;White;True;False;False;False" +
      "\nSimplePawn;g2;White;True;False;False;False";
            var whiteList = whiteListString.Split('\n');
            foreach (var line in whiteList)
            {
                var datas = line.Split(';');
                var newPawn = new Pawn(datas[0], datas[1], new Button(), datas[2], mainWindow);
                //;{pawn.IsFirstMove};{pawn.IsFirstMoveKing};{pawn.IsLeftRookFirstMove};{pawn.IsRightRookFirstMove}
                newPawn.IsFirstMove = bool.Parse(datas[3]);
                newPawn.IsFirstMoveKing = bool.Parse(datas[4]);
                newPawn.IsLeftRookFirstMove = bool.Parse(datas[5]);
                newPawn.IsRightRookFirstMove = bool.Parse(datas[6]);
                pawnListWhite.Add(newPawn);
            }

            //BLACKList
            var blackListString = "" +
              "King;e8;Black;False;True;True;True" +
      "\nQueen;d8;Black;False;False;False;False" +
      "\nRook;a8;Black;False;False;False;False" +
      "\nRook;h8;Black;False;False;False;False" +
      "\nBishop;c8;Black;False;False;False;False" +
      "\nBishop;f8;Black;False;False;False;False" +
      "\nKnight;a1;Black;False;False;False;False" +
      "\nKnight;g8;Black;False;False;False;False" +
      "\nSimplePawn;a7;Black;True;False;False;False" +
      "\nSimplePawn;b7;Black;True;False;False;False" +
      "\nSimplePawn;c7;Black;True;False;False;False" +
      "\nSimplePawn;d7;Black;True;False;False;False" +
      "\nSimplePawn;e7;Black;True;False;False;False" +
      "\nSimplePawn;f7;Black;True;False;False;False" +
      "\nSimplePawn;h7;Black;True;False;False;False" +
      "\nSimplePawn;g7;Black;True;False;False;False";
            var blackList = blackListString.Split('\n');
            foreach (var line in blackList)
            {
                var datas = line.Split(';');
                var newPawn = new Pawn(datas[0], datas[1], new Button(), datas[2], mainWindow);
                //;{pawn.IsFirstMove};{pawn.IsFirstMoveKing};{pawn.IsLeftRookFirstMove};{pawn.IsRightRookFirstMove}
                newPawn.IsFirstMove = bool.Parse(datas[3]);
                newPawn.IsFirstMoveKing = bool.Parse(datas[4]);
                newPawn.IsLeftRookFirstMove = bool.Parse(datas[5]);
                newPawn.IsRightRookFirstMove = bool.Parse(datas[6]);
                pawnListBlack.Add(newPawn);
            }



            var pawnList = new List<Pawn>();pawnList.AddRange(pawnListWhite);pawnList.AddRange(pawnListBlack);mainWindow.PawnList = pawnList;

            using (var chess2UtilsNotStatic = new Chess2UtilsNotStatic())
            {
                var nodeResult = mainWindow.GetBestPositionLocalNotTask(mainWindow.ComputerColore);
                ////le Cavalier noir ne doit pas se mettre sur "b3"
                //Assert.AreEqual(nodeResult.AssociatePawn.Name, "Bishop");
                Assert.AreNotEqual(nodeResult.BestChildPosition, "b3");
            }
        }


        [TestMethod]
        public void MTT24LeCavalierNoirNeDoitPasBouger()
        {
            /*Le Cavalier noir ne doit pas bouger*/




            
            var mainWindow = new MainWindow(); mainWindow.SetTurnNumberLabel("5");mainWindow.ComputerColore = "Black";



            
            var pawnListWhite = new List<Pawn>();
            var pawnListBlack = new List<Pawn>();



            //WHITEList
            var whiteListString = "" +
              "King;d2;White;False;False;True;True" +
      "\nQueen;f3;White;False;False;False;False" +
      "\nRook;h1;White;False;False;False;False" +
      "\nBishop;c1;White;False;False;False;False" +
      "\nKnight;b1;White;False;False;False;False" +
      "\nKnight;g1;White;False;False;False;False" +
      "\nSimplePawn;a2;White;True;False;False;False" +
      "\nSimplePawn;b2;White;True;False;False;False" +
      "\nSimplePawn;d4;White;False;False;False;False" +
      "\nSimplePawn;e3;White;False;False;False;False" +
      "\nSimplePawn;f2;White;True;False;False;False" +
      "\nSimplePawn;g2;White;True;False;False;False" +
      "\nSimplePawn;h2;White;True;False;False;False";
            var whiteList = whiteListString.Split('\n');
            foreach (var line in whiteList)
            {
                var datas = line.Split(';');
                var newPawn = new Pawn(datas[0], datas[1], new Button(), datas[2], mainWindow);
                //;{pawn.IsFirstMove};{pawn.IsFirstMoveKing};{pawn.IsLeftRookFirstMove};{pawn.IsRightRookFirstMove}
                newPawn.IsFirstMove = bool.Parse(datas[3]);
                newPawn.IsFirstMoveKing = bool.Parse(datas[4]);
                newPawn.IsLeftRookFirstMove = bool.Parse(datas[5]);
                newPawn.IsRightRookFirstMove = bool.Parse(datas[6]);
                pawnListWhite.Add(newPawn);
            }

            //BLACKList
            var blackListString = "" +
              "King;e8;Black;False;True;True;True" +
      "\nQueen;d8;Black;False;False;False;False" +
      "\nRook;a8;Black;False;False;False;False" +
      "\nRook;h8;Black;False;False;False;False" +
      "\nBishop;c8;Black;False;False;False;False" +
      "\nBishop;f8;Black;False;False;False;False" +
      "\nKnight;a1;Black;False;False;False;False" +
      "\nKnight;g8;Black;False;False;False;False" +
      "\nSimplePawn;a7;Black;True;False;False;False" +
      "\nSimplePawn;b7;Black;True;False;False;False" +
      "\nSimplePawn;c7;Black;True;False;False;False" +
      "\nSimplePawn;d7;Black;True;False;False;False" +
      "\nSimplePawn;e7;Black;True;False;False;False" +
      "\nSimplePawn;f7;Black;True;False;False;False" +
      "\nSimplePawn;g7;Black;True;False;False;False" +
      "\nSimplePawn;h7;Black;True;False;False;False";
            var blackList = blackListString.Split('\n');
            foreach (var line in blackList)
            {
                var datas = line.Split(';');
                var newPawn = new Pawn(datas[0], datas[1], new Button(), datas[2], mainWindow);
                //;{pawn.IsFirstMove};{pawn.IsFirstMoveKing};{pawn.IsLeftRookFirstMove};{pawn.IsRightRookFirstMove}
                newPawn.IsFirstMove = bool.Parse(datas[3]);
                newPawn.IsFirstMoveKing = bool.Parse(datas[4]);
                newPawn.IsLeftRookFirstMove = bool.Parse(datas[5]);
                newPawn.IsRightRookFirstMove = bool.Parse(datas[6]);
                pawnListBlack.Add(newPawn);
            }



            var pawnList = new List<Pawn>();pawnList.AddRange(pawnListWhite);pawnList.AddRange(pawnListBlack);mainWindow.PawnList = pawnList;
            using (var chess2UtilsNotStatic = new Chess2UtilsNotStatic())
            {

                var nodeResult = mainWindow.GetBestPositionLocalNotTask(mainWindow.ComputerColore);

                Assert.AreNotEqual(nodeResult.Location, "a1");
            }

        }

        [TestMethod]
        public void MTT25LeCavalierNoirDoitMenacerLeRoiBlanch()
        {
            /*Le Cavalier noir doit mencer le roi blanc*/




            
            var mainWindow = new MainWindow(); mainWindow.SetTurnNumberLabel("5");mainWindow.ComputerColore = "Black";
      var testName = "T25LeCavalierNoirDoitMenacerLeRoiBlanch";
      var testPath = Path.Combine(testsDirrectory, testName);
      mainWindow.LoadFromDirectorie(testPath);
      using (var chess2UtilsNotStatic = new Chess2UtilsNotStatic())
      {

        var nodeResult = mainWindow.GetBestPositionLocalNotTask(mainWindow.ComputerColore);
        //var nodeResult = chess2UtilsNotStatic.GetBestPositionLocalUsingMiltiThreading(computerColore, Chess2Utils.GenerateBoardFormPawnList(pawnList), true, null);

        //Assert.AreEqual(nodeResult.Location, "g4");

        var isSuccess = false;
        string[] accepdedArray = { "a5", "h6", "d6", "g6", "f6" };

        if (accepdedArray.Contains(nodeResult.BestChildPosition))
          isSuccess = true;
        Assert.IsTrue(isSuccess);
        //  Assert.AreEqual(nodeResult.BestChildPosition, "b3");
      }



    }

    [TestMethod]
        public void MTT26LeCavalierNoirDoitBouger()
        {
            /*Le Cavalier noir en f6 doit se deplacer*/




            
            var mainWindow = new MainWindow(); mainWindow.SetTurnNumberLabel("5");mainWindow.ComputerColore = "Black";



            
            var pawnListWhite = new List<Pawn>();
            var pawnListBlack = new List<Pawn>();



            //WHITEList
            var whiteListString = "" +
              "King;e1;White;False;True;True;True" +
      "\nQueen;d1;White;False;False;False;False" +
      "\nRook;a1;White;False;False;False;False" +
      "\nRook;h1;White;False;False;False;False" +
      "\nBishop;c1;White;False;False;False;False" +
      "\nBishop;d3;White;False;False;False;False" +
      "\nKnight;c3;White;False;False;False;False" +
      "\nKnight;g1;White;False;False;False;False" +
      "\nSimplePawn;a2;White;True;False;False;False" +
      "\nSimplePawn;b2;White;True;False;False;False" +
      "\nSimplePawn;c2;White;True;False;False;False" +
      "\nSimplePawn;d2;White;True;False;False;False" +
      "\nSimplePawn;e5;White;False;False;False;False" +
      "\nSimplePawn;f2;White;True;False;False;False" +
      "\nSimplePawn;g2;White;True;False;False;False" +
      "\nSimplePawn;h2;White;True;False;False;False";
            var whiteList = whiteListString.Split('\n');
            foreach (var line in whiteList)
            {
                var datas = line.Split(';');
                var newPawn = new Pawn(datas[0], datas[1], new Button(), datas[2], mainWindow);
                //;{pawn.IsFirstMove};{pawn.IsFirstMoveKing};{pawn.IsLeftRookFirstMove};{pawn.IsRightRookFirstMove}
                newPawn.IsFirstMove = bool.Parse(datas[3]);
                newPawn.IsFirstMoveKing = bool.Parse(datas[4]);
                newPawn.IsLeftRookFirstMove = bool.Parse(datas[5]);
                newPawn.IsRightRookFirstMove = bool.Parse(datas[6]);
                pawnListWhite.Add(newPawn);
            }

            //BLACKList
            var blackListString = "" +
      "King;e8;Black;False;True;True;True" +
      "\nQueen;d8;Black;False;False;False;False" +
      "\nRook;a8;Black;False;False;False;False" +
      "\nRook;h8;Black;False;False;False;False" +
      "\nBishop;c8;Black;False;False;False;False" +
      "\nBishop;h6;Black;False;False;False;False" +
      "\nKnight;b8;Black;False;False;False;False" +
      "\nKnight;f6;Black;False;False;False;False" +
      "\nSimplePawn;a7;Black;True;False;False;False" +
      "\nSimplePawn;b7;Black;True;False;False;False" +
      "\nSimplePawn;c7;Black;True;False;False;False" +
      "\nSimplePawn;d7;Black;True;False;False;False" +
      "\nSimplePawn;e7;Black;True;False;False;False" +
      "\nSimplePawn;f7;Black;True;False;False;False" +
      "\nSimplePawn;g6;Black;False;False;False;False" +
      "\nSimplePawn;h7;Black;True;False;False;False";
            var blackList = blackListString.Split('\n');
            foreach (var line in blackList)
            {
                var datas = line.Split(';');
                var newPawn = new Pawn(datas[0], datas[1], new Button(), datas[2], mainWindow);
                //;{pawn.IsFirstMove};{pawn.IsFirstMoveKing};{pawn.IsLeftRookFirstMove};{pawn.IsRightRookFirstMove}
                newPawn.IsFirstMove = bool.Parse(datas[3]);
                newPawn.IsFirstMoveKing = bool.Parse(datas[4]);
                newPawn.IsLeftRookFirstMove = bool.Parse(datas[5]);
                newPawn.IsRightRookFirstMove = bool.Parse(datas[6]);
                pawnListBlack.Add(newPawn);
            }



            var pawnList = new List<Pawn>();pawnList.AddRange(pawnListWhite);pawnList.AddRange(pawnListBlack);mainWindow.PawnList = pawnList;

            using (var chess2UtilsNotStatic = new Chess2UtilsNotStatic())
            {
                var nodeResult = mainWindow.GetBestPositionLocalNotTask(mainWindow.ComputerColore);
                /*Le Cavalier noir en f6 doit se deplacer*/
                // Assert.AreEqual(nodeResult.AssociatePawn.Name, "Knight");
                Assert.AreEqual(nodeResult.Location, "f6");
            }

        }
        [TestMethod]
        public void MTT01MultiThreadCPUsPawn()
        {
            
            var mainWindow = new MainWindow(); mainWindow.SetTurnNumberLabel("5");mainWindow.ComputerColore = "White";
            var testName = "T01QuenLaReineNoirNeDoitPasPrendreLeCavalier";
            var testPath = Path.Combine(testsDirrectory, testName);
            mainWindow.LoadFromDirectorie(testPath);
            using (var chess2UtilsNotStatic = new Chess2UtilsNotStatic())
            {
                
                var nodeResult = mainWindow.GetBestPositionLocalNotTask(mainWindow.ComputerColore);





                Assert.AreNotEqual(nodeResult.BestChildPosition, "g5");
            }

        }



        [TestMethod]
        public void MTT27LeBishopBlancDoitSeMettreEnA8()
        {
            /*Le Bishop blanc doit attaque le rook en a8 et non pas le cavalier*/
            // Le Bishop blanc doit se mettre en a8



            
            var mainWindow = new MainWindow(); mainWindow.SetTurnNumberLabel("5");
      mainWindow.ComputerColore = "White";
      var testName = "T27LeBishopBlancDoitSeMettreEnA8";
      var testPath = Path.Combine(testsDirrectory, testName);
      mainWindow.LoadFromDirectorie(testPath);
      using (var chess2UtilsNotStatic = new Chess2UtilsNotStatic())
      {

        var nodeResult = mainWindow.GetBestPositionLocalNotTask(mainWindow.ComputerColore);
        //var nodeResult = chess2UtilsNotStatic.GetBestPositionLocalUsingMiltiThreading(computerColore, Chess2Utils.GenerateBoardFormPawnList(pawnList), true, null);
        Assert.AreEqual("a8", nodeResult.BestChildPosition);
      }


    }

    [TestMethod]
        public void MTT28LePionNoirDoitPrendreLeCavalier()
        {
            /*Le pion noir doit attaque le cavavier en d6*/
            // Le pion noir doit se mettre en d6



            
            var mainWindow = new MainWindow(); mainWindow.SetTurnNumberLabel("5");mainWindow.ComputerColore = "Black";



            
            var pawnListWhite = new List<Pawn>();
            var pawnListBlack = new List<Pawn>();



            //WHITEList
            var whiteListString = "" +
              "King;e1;White;False;True;True;True" +
      "\nQueen;d1;White;False;False;False;False" +
      "\nRook;a1;White;False;False;False;False" +
      "\nRook;h1;White;False;False;False;False" +
      "\nBishop;c1;White;False;False;False;False" +
      "\nBishop;f1;White;False;False;False;False" +
      "\nKnight;d6;White;False;False;False;False" +
      "\nKnight;f3;White;False;False;False;False" +
      "\nSimplePawn;a2;White;True;False;False;False" +
      "\nSimplePawn;b2;White;True;False;False;False" +
      "\nSimplePawn;c3;White;False;False;False;False" +
      "\nSimplePawn;d4;White;False;False;False;False" +
      "\nSimplePawn;e2;White;True;False;False;False" +
      "\nSimplePawn;f2;White;True;False;False;False" +
      "\nSimplePawn;g2;White;True;False;False;False" +
      "\nSimplePawn;h2;White;True;False;False;False";
            var whiteList = whiteListString.Split('\n');
            foreach (var line in whiteList)
            {
                var datas = line.Split(';');
                var newPawn = new Pawn(datas[0], datas[1], new Button(), datas[2], mainWindow);
                //;{pawn.IsFirstMove};{pawn.IsFirstMoveKing};{pawn.IsLeftRookFirstMove};{pawn.IsRightRookFirstMove}
                newPawn.IsFirstMove = bool.Parse(datas[3]);
                newPawn.IsFirstMoveKing = bool.Parse(datas[4]);
                newPawn.IsLeftRookFirstMove = bool.Parse(datas[5]);
                newPawn.IsRightRookFirstMove = bool.Parse(datas[6]);
                pawnListWhite.Add(newPawn);
            }

            //BLACKList
            var blackListString = "" +
      "King;e8;Black;False;True;True;True" +
      "\nQueen;d8;Black;False;False;False;False" +
      "\nRook;a8;Black;False;False;False;False" +
      "\nRook;h8;Black;False;False;False;False" +
      "\nBishop;c8;Black;False;False;False;False" +
      "\nKnight;b8;Black;False;False;False;False" +
      "\nKnight;g8;Black;False;False;False;False" +
      "\nSimplePawn;a6;Black;False;False;False;False" +
      "\nSimplePawn;b7;Black;True;False;False;False" +
      "\nSimplePawn;c7;Black;True;False;False;False" +
      "\nSimplePawn;d7;Black;True;False;False;False" +
      "\nSimplePawn;e6;Black;False;False;False;False" +
      "\nSimplePawn;f7;Black;True;False;False;False" +
      "\nSimplePawn;g6;Black;False;False;False;False" +
      "\nSimplePawn;h7;Black;True;False;False;False";
            var blackList = blackListString.Split('\n');
            foreach (var line in blackList)
            {
                var datas = line.Split(';');
                var newPawn = new Pawn(datas[0], datas[1], new Button(), datas[2], mainWindow);
                //;{pawn.IsFirstMove};{pawn.IsFirstMoveKing};{pawn.IsLeftRookFirstMove};{pawn.IsRightRookFirstMove}
                newPawn.IsFirstMove = bool.Parse(datas[3]);
                newPawn.IsFirstMoveKing = bool.Parse(datas[4]);
                newPawn.IsLeftRookFirstMove = bool.Parse(datas[5]);
                newPawn.IsRightRookFirstMove = bool.Parse(datas[6]);
                pawnListBlack.Add(newPawn);
            }



            var pawnList = new List<Pawn>();pawnList.AddRange(pawnListWhite);pawnList.AddRange(pawnListBlack);mainWindow.PawnList = pawnList;

            using (var chess2UtilsNotStatic = new Chess2UtilsNotStatic())
            {
                var nodeResult = mainWindow.GetBestPositionLocalNotTask(mainWindow.ComputerColore);
                // // Le pion noir doit se mettre en d6
                Assert.AreEqual(nodeResult.BestChildPosition, "d6");
            }


        }

        [TestMethod]
        public void MTT29PourProtegerDEchec()
        {
            /*Le pion blanch doit se mettre en h4 ou le Bishop doit se mettre en g2 ou reine en c2  pour proder de l'check*/
            // Le pion blanc doit se mettre en h4 ou le Bishop doit se mettre en g2 ou ou reine en c2



            
            var mainWindow = new MainWindow(); mainWindow.SetTurnNumberLabel("5");mainWindow.ComputerColore = "White";





            
            var pawnListWhite = new List<Pawn>();
            var pawnListBlack = new List<Pawn>();



            //WHITEList
            var whiteListString = "" +
              "King;e1;White;False;True;True;True" +
      "\nQueen;d1;White;False;False;False;False" +
      "\nRook;a1;White;False;False;False;False" +
      "\nRook;h1;White;False;False;False;False" +
      "\nBishop;f1;White;False;False;False;False" +
      "\nKnight;b1;White;False;False;False;False" +
      "\nKnight;g1;White;False;False;False;False" +
      "\nSimplePawn;a4;White;False;False;False;False" +
      "\nSimplePawn;b3;White;False;False;False;False" +
      "\nSimplePawn;c3;White;False;False;False;False" +
      "\nSimplePawn;e2;White;True;False;False;False" +
      "\nSimplePawn;f4;White;False;False;False;False" +
      "\nSimplePawn;g4;White;False;False;False;False" +
      "\nSimplePawn;h3;White;False;False;False;False";
            var whiteList = whiteListString.Split('\n');
            foreach (var line in whiteList)
            {
                var datas = line.Split(';');
                var newPawn = new Pawn(datas[0], datas[1], new Button(), datas[2], mainWindow);
                //;{pawn.IsFirstMove};{pawn.IsFirstMoveKing};{pawn.IsLeftRookFirstMove};{pawn.IsRightRookFirstMove}
                newPawn.IsFirstMove = bool.Parse(datas[3]);
                newPawn.IsFirstMoveKing = bool.Parse(datas[4]);
                newPawn.IsLeftRookFirstMove = bool.Parse(datas[5]);
                newPawn.IsRightRookFirstMove = bool.Parse(datas[6]);
                pawnListWhite.Add(newPawn);
            }

            //BLACKList
            var blackListString = "" +
      "King;e8;Black;False;True;True;True" +
      "\nQueen;f6;Black;False;False;False;False" +
      "\nRook;a8;Black;False;False;False;False" +
      "\nRook;h8;Black;False;False;False;False" +
      "\nBishop;c8;Black;False;False;False;False" +
      "\nBishop;f8;Black;False;False;False;False" +
      "\nKnight;g8;Black;False;False;False;False" +
      "\nSimplePawn;a7;Black;True;False;False;False" +
      "\nSimplePawn;b7;Black;True;False;False;False" +
      "\nSimplePawn;c7;Black;True;False;False;False" +
      "\nSimplePawn;e3;Black;False;False;False;False" +
      "\nSimplePawn;e4;Black;False;False;False;False" +
      "\nSimplePawn;f7;Black;True;False;False;False" +
      "\nSimplePawn;g7;Black;True;False;False;False" +
      "\nSimplePawn;h7;Black;True;False;False;False";
            var blackList = blackListString.Split('\n');
            foreach (var line in blackList)
            {
                var datas = line.Split(';');
                var newPawn = new Pawn(datas[0], datas[1], new Button(), datas[2], mainWindow);
                //;{pawn.IsFirstMove};{pawn.IsFirstMoveKing};{pawn.IsLeftRookFirstMove};{pawn.IsRightRookFirstMove}
                newPawn.IsFirstMove = bool.Parse(datas[3]);
                newPawn.IsFirstMoveKing = bool.Parse(datas[4]);
                newPawn.IsLeftRookFirstMove = bool.Parse(datas[5]);
                newPawn.IsRightRookFirstMove = bool.Parse(datas[6]);
                pawnListBlack.Add(newPawn);
            }



            var pawnList = new List<Pawn>();pawnList.AddRange(pawnListWhite);pawnList.AddRange(pawnListBlack);mainWindow.PawnList = pawnList;

            using (var chess2UtilsNotStatic = new Chess2UtilsNotStatic())
            {
                var nodeResult = mainWindow.GetBestPositionLocalNotTask(mainWindow.ComputerColore);
                // Le pion blanc doit se mettre en h4 ou le Bishop doit se mettre en g2 ou reine en c2
                var isSuccess = false;
                string[] accepdedArray = { "g5", "c2", "h4", "h2", "g2", "d5", "d4", "c1" };

                if (accepdedArray.Contains(nodeResult.BestChildPosition))
                    isSuccess = true;
                Assert.IsTrue(isSuccess);
            }


        }

        [TestMethod]
        public void MTT30LaReineNoirNeDoitPasPrendreLeFouEnG4()
        {
            /*La reinne noir ne doit pas se mettre en g4*/
            // La reinne noir ne doit pas se mettre en g4



            
            var mainWindow = new MainWindow(); mainWindow.SetTurnNumberLabel("5");mainWindow.ComputerColore = "Black";



            
            var pawnListWhite = new List<Pawn>();
            var pawnListBlack = new List<Pawn>();



            //WHITEList
            var whiteListString = "" +
              "King;g1;White;False;False;True;True" +
      "\nQueen;h8;White;False;False;False;False" +
      "\nRook;a1;White;False;False;False;False" +
      "\nRook;h1;White;False;False;False;False" +
      "\nBishop;e3;White;False;False;False;False" +
      "\nBishop;g4;White;False;False;False;False" +
      "\nKnight;e4;White;False;False;False;False" +
      "\nKnight;f2;White;False;False;False;False" +
      "\nSimplePawn;a2;White;True;False;False;False" +
      "\nSimplePawn;b2;White;True;False;False;False" +
      "\nSimplePawn;c3;White;False;False;False;False" +
      "\nSimplePawn;h2;White;True;False;False;False";
            var whiteList = whiteListString.Split('\n');
            foreach (var line in whiteList)
            {
                var datas = line.Split(';');
                var newPawn = new Pawn(datas[0], datas[1], new Button(), datas[2], mainWindow);
                //;{pawn.IsFirstMove};{pawn.IsFirstMoveKing};{pawn.IsLeftRookFirstMove};{pawn.IsRightRookFirstMove}
                newPawn.IsFirstMove = bool.Parse(datas[3]);
                newPawn.IsFirstMoveKing = bool.Parse(datas[4]);
                newPawn.IsLeftRookFirstMove = bool.Parse(datas[5]);
                newPawn.IsRightRookFirstMove = bool.Parse(datas[6]);
                pawnListWhite.Add(newPawn);
            }

            //BLACKList
            var blackListString = "" +
      "King;f8;Black;False;False;False;True" +
      "\nQueen;g6;Black;False;False;False;False" +
      "\nRook;a6;Black;False;False;False;False" +
      "\nBishop;c8;Black;False;False;False;False" +
      "\nKnight;b8;Black;False;False;False;False" +
      "\nKnight;g8;Black;False;False;False;False" +
      "\nSimplePawn;a5;Black;False;False;False;False" +
      "\nSimplePawn;b6;Black;False;False;False;False" +
      "\nSimplePawn;d7;Black;True;False;False;False" +
      "\nSimplePawn;e6;Black;False;False;False;False" +
      "\nSimplePawn;h6;Black;False;False;False;False";
            var blackList = blackListString.Split('\n');
            foreach (var line in blackList)
            {
                var datas = line.Split(';');
                var newPawn = new Pawn(datas[0], datas[1], new Button(), datas[2], mainWindow);
                //;{pawn.IsFirstMove};{pawn.IsFirstMoveKing};{pawn.IsLeftRookFirstMove};{pawn.IsRightRookFirstMove}
                newPawn.IsFirstMove = bool.Parse(datas[3]);
                newPawn.IsFirstMoveKing = bool.Parse(datas[4]);
                newPawn.IsLeftRookFirstMove = bool.Parse(datas[5]);
                newPawn.IsRightRookFirstMove = bool.Parse(datas[6]);
                pawnListBlack.Add(newPawn);
            }



            var pawnList = new List<Pawn>();pawnList.AddRange(pawnListWhite);pawnList.AddRange(pawnListBlack);mainWindow.PawnList = pawnList;

            using (var chess2UtilsNotStatic = new Chess2UtilsNotStatic())
            {
                var nodeResult = mainWindow.GetBestPositionLocalNotTask(mainWindow.ComputerColore);
                //La reinne noir ne doit pas se mettre en g4
                Assert.AreNotEqual(nodeResult.BestChildPosition, "g4");
            }


        }


        [TestMethod]
        public void MTT31LaReineNoirDoitPrendreLaReineBlanch()
        {
            /*La reinne noir ne doit pas se mettre en a8*/



            
            var mainWindow = new MainWindow(); mainWindow.SetTurnNumberLabel("5");mainWindow.ComputerColore = "Black";



            
            var pawnListWhite = new List<Pawn>();
            var pawnListBlack = new List<Pawn>();



            //WHITEList
            var whiteListString = "" +
              "King;g1;White;False;True;True;True" +
      "\nQueen;a8;White;False;False;False;False" +
      "\nRook;a1;White;False;False;False;False" +
      "\nRook;h1;White;False;False;False;False" +
      "\nKnight;a3;White;False;False;False;False" +
      "\nKnight;f3;White;False;False;False;False" +
      "\nSimplePawn;a4;White;False;False;False;False" +
      "\nSimplePawn;b2;White;True;False;False;False" +
      "\nSimplePawn;c2;White;True;False;False;False" +
      "\nSimplePawn;d4;White;False;False;False;False" +
      "\nSimplePawn;f2;White;True;False;False;False" +
      "\nSimplePawn;g4;White;False;False;False;False" +
      "\nSimplePawn;h4;White;False;False;False;False";
            var whiteList = whiteListString.Split('\n');
            foreach (var line in whiteList)
            {
                var datas = line.Split(';');
                var newPawn = new Pawn(datas[0], datas[1], new Button(), datas[2], mainWindow);
                //;{pawn.IsFirstMove};{pawn.IsFirstMoveKing};{pawn.IsLeftRookFirstMove};{pawn.IsRightRookFirstMove}
                newPawn.IsFirstMove = bool.Parse(datas[3]);
                newPawn.IsFirstMoveKing = bool.Parse(datas[4]);
                newPawn.IsLeftRookFirstMove = bool.Parse(datas[5]);
                newPawn.IsRightRookFirstMove = bool.Parse(datas[6]);
                pawnListWhite.Add(newPawn);
            }

            //BLACKList
            var blackListString = "" +
      "King;e8;Black;False;True;True;True" +
      "\nQueen;d8;Black;False;False;False;False" +
      "\nRook;h8;Black;False;False;False;False" +
      "\nBishop;d7;Black;False;False;False;False" +
      "\nBishop;f8;Black;False;False;False;False" +
      "\nKnight;g8;Black;False;False;False;False" +
      "\nSimplePawn;a5;Black;False;False;False;False" +
      "\nSimplePawn;b6;Black;False;False;False;False" +
      "\nSimplePawn;e6;Black;False;False;False;False" +
      "\nSimplePawn;f5;Black;False;False;False;False" +
      "\nSimplePawn;f4;Black;False;False;False;False" +
      "\nSimplePawn;h6;Black;False;False;False;False";
            var blackList = blackListString.Split('\n');
            foreach (var line in blackList)
            {
                var datas = line.Split(';');
                var newPawn = new Pawn(datas[0], datas[1], new Button(), datas[2], mainWindow);
                //;{pawn.IsFirstMove};{pawn.IsFirstMoveKing};{pawn.IsLeftRookFirstMove};{pawn.IsRightRookFirstMove}
                newPawn.IsFirstMove = bool.Parse(datas[3]);
                newPawn.IsFirstMoveKing = bool.Parse(datas[4]);
                newPawn.IsLeftRookFirstMove = bool.Parse(datas[5]);
                newPawn.IsRightRookFirstMove = bool.Parse(datas[6]);
                pawnListBlack.Add(newPawn);
            }



            var pawnList = new List<Pawn>();pawnList.AddRange(pawnListWhite);pawnList.AddRange(pawnListBlack);mainWindow.PawnList = pawnList;
            using (var chess2UtilsNotStatic = new Chess2UtilsNotStatic())
            {

                var nodeResult = mainWindow.GetBestPositionLocalNotTask(mainWindow.ComputerColore);
                //La reinne noir ne doit pas se mettre en g4
                Assert.AreEqual(nodeResult.BestChildPosition, "a8");
            }


        }

        [TestMethod]
        public void MTT32LaReineBlanchDoitAttaquerEnB7()
        {




            
            var mainWindow = new MainWindow(); mainWindow.SetTurnNumberLabel("5");mainWindow.ComputerColore = "White";





            
            var pawnListWhite = new List<Pawn>();
            var pawnListBlack = new List<Pawn>();



            //WHITEList
            var whiteListString = "" +
              "King;e1;White;False;True;True;True" +
      "\nQueen;f3;White;False;False;False;False" +
      "\nRook;a1;White;False;False;False;False" +
      "\nRook;h1;White;False;False;False;False" +
      "\nBishop;c1;White;False;False;False;False" +
      "\nBishop;b5;White;False;False;False;False" +
      "\nKnight;b1;White;False;False;False;False" +
      "\nKnight;g1;White;False;False;False;False" +
      "\nSimplePawn;a2;White;True;False;False;False" +
      "\nSimplePawn;b2;White;True;False;False;False" +
      "\nSimplePawn;c3;White;False;False;False;False" +
      "\nSimplePawn;d2;White;True;False;False;False" +
      "\nSimplePawn;e3;White;False;False;False;False" +
      "\nSimplePawn;f2;White;True;False;False;False" +
      "\nSimplePawn;g2;White;True;False;False;False" +
      "\nSimplePawn;h2;White;True;False;False;False";
            var whiteList = whiteListString.Split('\n');
            foreach (var line in whiteList)
            {
                var datas = line.Split(';');
                var newPawn = new Pawn(datas[0], datas[1], new Button(), datas[2], mainWindow);
                //;{pawn.IsFirstMove};{pawn.IsFirstMoveKing};{pawn.IsLeftRookFirstMove};{pawn.IsRightRookFirstMove}
                newPawn.IsFirstMove = bool.Parse(datas[3]);
                newPawn.IsFirstMoveKing = bool.Parse(datas[4]);
                newPawn.IsLeftRookFirstMove = bool.Parse(datas[5]);
                newPawn.IsRightRookFirstMove = bool.Parse(datas[6]);
                pawnListWhite.Add(newPawn);
            }

            //BLACKList
            var blackListString = "" +
      "King;e8;Black;False;True;True;True" +
      "\nRook;a8;Black;False;False;False;False" +
      "\nRook;h8;Black;False;False;False;False" +
      "\nBishop;d7;Black;False;False;False;False" +
      "\nBishop;f6;Black;False;False;False;False" +
      "\nKnight;b8;Black;False;False;False;False" +
      "\nKnight;h6;Black;False;False;False;False" +
      "\nSimplePawn;a7;Black;True;False;False;False" +
      "\nSimplePawn;b7;Black;True;False;False;False" +
      "\nSimplePawn;c7;Black;True;False;False;False" +
      "\nSimplePawn;d6;Black;False;False;False;False" +
      "\nSimplePawn;e7;Black;True;False;False;False" +
      "\nSimplePawn;g5;Black;False;False;False;False" +
      "\nSimplePawn;h7;Black;True;False;False;False";
            var blackList = blackListString.Split('\n');
            foreach (var line in blackList)
            {
                var datas = line.Split(';');
                var newPawn = new Pawn(datas[0], datas[1], new Button(), datas[2], mainWindow);
                //;{pawn.IsFirstMove};{pawn.IsFirstMoveKing};{pawn.IsLeftRookFirstMove};{pawn.IsRightRookFirstMove}
                newPawn.IsFirstMove = bool.Parse(datas[3]);
                newPawn.IsFirstMoveKing = bool.Parse(datas[4]);
                newPawn.IsLeftRookFirstMove = bool.Parse(datas[5]);
                newPawn.IsRightRookFirstMove = bool.Parse(datas[6]);
                pawnListBlack.Add(newPawn);
            }



            var pawnList = new List<Pawn>();pawnList.AddRange(pawnListWhite);pawnList.AddRange(pawnListBlack);mainWindow.PawnList = pawnList;

            using (var chess2UtilsNotStatic = new Chess2UtilsNotStatic())
            {
                var nodeResult = mainWindow.GetBestPositionLocalNotTask(mainWindow.ComputerColore);


                //La reinne noir  doit se mettre en b7
                Assert.AreEqual(nodeResult.BestChildPosition, "b7");
            }


        }
        [TestMethod]
        public void MTT33LaReineBlanchDoitAttaquerEnB7()
        {




            
            var mainWindow = new MainWindow(); mainWindow.SetTurnNumberLabel("5");mainWindow.ComputerColore = "White";





            
            var pawnListWhite = new List<Pawn>();
            var pawnListBlack = new List<Pawn>();



            //WHITEList
            var whiteListString = "" +
              "King;e1;White;False;True;True;True" +
      "\nQueen;f3;White;False;False;False;False" +
      "\nRook;a1;White;False;False;False;False" +
      "\nRook;h1;White;False;False;False;False" +
      "\nBishop;c1;White;False;False;False;False" +
      "\nBishop;b5;White;False;False;False;False" +
      "\nKnight;b1;White;False;False;False;False" +
      "\nKnight;g1;White;False;False;False;False" +
      "\nSimplePawn;a2;White;True;False;False;False" +
      "\nSimplePawn;b2;White;True;False;False;False" +
      "\nSimplePawn;c3;White;False;False;False;False" +
      "\nSimplePawn;d2;White;True;False;False;False" +
      "\nSimplePawn;e3;White;False;False;False;False" +
      "\nSimplePawn;f2;White;True;False;False;False" +
      "\nSimplePawn;g2;White;True;False;False;False" +
      "\nSimplePawn;h2;White;True;False;False;False";
            var whiteList = whiteListString.Split('\n');
            foreach (var line in whiteList)
            {
                var datas = line.Split(';');
                var newPawn = new Pawn(datas[0], datas[1], new Button(), datas[2], mainWindow);
                //;{pawn.IsFirstMove};{pawn.IsFirstMoveKing};{pawn.IsLeftRookFirstMove};{pawn.IsRightRookFirstMove}
                newPawn.IsFirstMove = bool.Parse(datas[3]);
                newPawn.IsFirstMoveKing = bool.Parse(datas[4]);
                newPawn.IsLeftRookFirstMove = bool.Parse(datas[5]);
                newPawn.IsRightRookFirstMove = bool.Parse(datas[6]);
                pawnListWhite.Add(newPawn);
            }

            //BLACKList
            var blackListString = "" +
      "King;e8;Black;False;True;True;True" +
      "\nQueen;d8;Black;False;False;False;False" +
      "\nRook;a8;Black;False;False;False;False" +
      "\nRook;h8;Black;False;False;False;False" +
      "\nBishop;d7;Black;False;False;False;False" +
      "\nBishop;f6;Black;False;False;False;False" +
      "\nKnight;b8;Black;False;False;False;False" +
      "\nKnight;h6;Black;False;False;False;False" +
      "\nSimplePawn;a7;Black;True;False;False;False" +
      "\nSimplePawn;b7;Black;True;False;False;False" +
      "\nSimplePawn;c7;Black;True;False;False;False" +
      "\nSimplePawn;d6;Black;False;False;False;False" +
      "\nSimplePawn;e7;Black;True;False;False;False" +
      "\nSimplePawn;g5;Black;False;False;False;False" +
      "\nSimplePawn;h7;Black;True;False;False;False";
            var blackList = blackListString.Split('\n');
            foreach (var line in blackList)
            {
                var datas = line.Split(';');
                var newPawn = new Pawn(datas[0], datas[1], new Button(), datas[2], mainWindow);
                //;{pawn.IsFirstMove};{pawn.IsFirstMoveKing};{pawn.IsLeftRookFirstMove};{pawn.IsRightRookFirstMove}
                newPawn.IsFirstMove = bool.Parse(datas[3]);
                newPawn.IsFirstMoveKing = bool.Parse(datas[4]);
                newPawn.IsLeftRookFirstMove = bool.Parse(datas[5]);
                newPawn.IsRightRookFirstMove = bool.Parse(datas[6]);
                pawnListBlack.Add(newPawn);
            }



            var pawnList = new List<Pawn>();pawnList.AddRange(pawnListWhite);pawnList.AddRange(pawnListBlack);mainWindow.PawnList = pawnList;

            using (var chess2UtilsNotStatic = new Chess2UtilsNotStatic())
            {
                var nodeResult = mainWindow.GetBestPositionLocalNotTask(mainWindow.ComputerColore);

                var randomList = nodeResult.AsssociateNodeChess2.RandomEquivalentList;
                // Assert.IsNull(randomList);
                //La reinne noir  doit se mettre en b7
                Assert.AreEqual(nodeResult.BestChildPosition, "b7");
            }


        }

        [TestMethod]
        public void MTT35LePoinNoirNeDoitPasSeMettreEnG5()
        {




            
            var mainWindow = new MainWindow(); mainWindow.SetTurnNumberLabel("5");mainWindow.ComputerColore = "Black";




            
            var pawnListWhite = new List<Pawn>();
            var pawnListBlack = new List<Pawn>();



            //WHITEList
            var whiteListString = "" +
              "King;e1;White;False;True;True;True" +
              "\nQueen;d1;White;False;False;False;False" +
      "\nRook;a1;White;False;False;False;False" +
      "\nRook;h1;White;False;False;False;False" +
      "\nBishop;f4;White;False;False;False;False" +
      "\nBishop;c4;White;False;False;False;False" +
      "\nKnight;c3;White;False;False;False;False" +
      "\nKnight;g1;White;False;False;False;False" +
      "\nSimplePawn;a2;White;True;False;False;False" +
      "\nSimplePawn;b2;White;True;False;False;False" +
      "\nSimplePawn;c2;White;True;False;False;False" +
      "\nSimplePawn;d4;White;False;False;False;False" +
      "\nSimplePawn;e5;White;False;False;False;False" +
      "\nSimplePawn;f2;White;True;False;False;False" +
      "\nSimplePawn;g2;White;True;False;False;False" +
      "\nSimplePawn;h2;White;True;False;False;False";
            var whiteList = whiteListString.Split('\n');
            foreach (var line in whiteList)
            {
                var datas = line.Split(';');
                var newPawn = new Pawn(datas[0], datas[1], new Button(), datas[2], mainWindow);
                //;{pawn.IsFirstMove};{pawn.IsFirstMoveKing};{pawn.IsLeftRookFirstMove};{pawn.IsRightRookFirstMove}
                newPawn.IsFirstMove = bool.Parse(datas[3]);
                newPawn.IsFirstMoveKing = bool.Parse(datas[4]);
                newPawn.IsLeftRookFirstMove = bool.Parse(datas[5]);
                newPawn.IsRightRookFirstMove = bool.Parse(datas[6]);
                pawnListWhite.Add(newPawn);
            }

            //BLACKList
            var blackListString = "" +
      "King;e8;Black;False;True;True;True" +
      "\nQueen;a5;Black;False;False;False;False" +
      "\nRook;a8;Black;False;False;False;False" +
      "\nRook;h8;Black;False;False;False;False" +
      "\nBishop;c8;Black;False;False;False;False" +
      "\nBishop;g7;Black;False;False;False;False" +
      "\nKnight;b8;Black;False;False;False;False" +
      "\nKnight;g8;Black;False;False;False;False" +
      "\nSimplePawn;a7;Black;True;False;False;False" +
      "\nSimplePawn;b6;Black;False;False;False;False" +
      "\nSimplePawn;c6;Black;False;False;False;False" +
      "\nSimplePawn;d7;Black;True;False;False;False" +
      "\nSimplePawn;e6;Black;False;False;False;False" +
      "\nSimplePawn;f7;Black;True;False;False;False" +
      "\nSimplePawn;g6;Black;False;False;False;False" +
      "\nSimplePawn;h7;Black;True;False;False;False";
            var blackList = blackListString.Split('\n');
            foreach (var line in blackList)
            {
                var datas = line.Split(';');
                var newPawn = new Pawn(datas[0], datas[1], new Button(), datas[2], mainWindow);
                //;{pawn.IsFirstMove};{pawn.IsFirstMoveKing};{pawn.IsLeftRookFirstMove};{pawn.IsRightRookFirstMove}
                newPawn.IsFirstMove = bool.Parse(datas[3]);
                newPawn.IsFirstMoveKing = bool.Parse(datas[4]);
                newPawn.IsLeftRookFirstMove = bool.Parse(datas[5]);
                newPawn.IsRightRookFirstMove = bool.Parse(datas[6]);
                pawnListBlack.Add(newPawn);
            }



            var pawnList = new List<Pawn>();pawnList.AddRange(pawnListWhite);pawnList.AddRange(pawnListBlack);mainWindow.PawnList = pawnList;



            using (var chess2UtilsNotStatic = new Chess2UtilsNotStatic())
            {
                var nodeResult = mainWindow.GetBestPositionLocalNotTask(mainWindow.ComputerColore);
                var randomList = nodeResult.AsssociateNodeChess2.RandomEquivalentList;





                //  Assert.IsNull(randomList.FirstOrDefault(x => x.ToIndex == 30));
                Assert.AreNotEqual(nodeResult.BestChildPosition, "g5");
            }



        }


        [TestMethod]
        public void MTT36LePoinNoirNeDoitPasSeMettreEnD6()
        {




            
            var mainWindow = new MainWindow(); mainWindow.SetTurnNumberLabel("5");mainWindow.ComputerColore = "Black";




            
            var pawnListWhite = new List<Pawn>();
            var pawnListBlack = new List<Pawn>();



            //WHITEList
            var whiteListString = "" +
      "King;g1;White;False;True;True;True" +
      "\nQueen;d1;White;False;False;False;False" +
      "\nRook;a1;White;False;False;False;False" +
      "\nRook;f2;White;False;False;False;False" +
      "\nBishop;a8;White;False;False;False;False" +
      "\nKnight;c3;White;False;False;False;False" +
      "\nKnight;e2;White;False;False;False;False" +
      "\nSimplePawn;a2;White;True;False;False;False" +
      "\nSimplePawn;b2;White;True;False;False;False" +
      "\nSimplePawn;c2;White;True;False;False;False" +
      "\nSimplePawn;f4;White;False;False;False;False" +
      "\nSimplePawn;g3;White;False;False;False;False" +
      "\nSimplePawn;h2;White;True;False;False;False";
            var whiteList = whiteListString.Split('\n');
            foreach (var line in whiteList)
            {
                var datas = line.Split(';');
                var newPawn = new Pawn(datas[0], datas[1], new Button(), datas[2], mainWindow);
                //;{pawn.IsFirstMove};{pawn.IsFirstMoveKing};{pawn.IsLeftRookFirstMove};{pawn.IsRightRookFirstMove}
                newPawn.IsFirstMove = bool.Parse(datas[3]);
                newPawn.IsFirstMoveKing = bool.Parse(datas[4]);
                newPawn.IsLeftRookFirstMove = bool.Parse(datas[5]);
                newPawn.IsRightRookFirstMove = bool.Parse(datas[6]);
                pawnListWhite.Add(newPawn);
            }

            //BLACKList
            var blackListString = "" +
      "King;e8;Black;False;True;True;True" +
      "\nQueen;e3;Black;False;False;False;False" +
      "\nRook;h8;Black;False;False;False;False" +
      "\nBishop;c8;Black;False;False;False;False" +
      "\nBishop;g7;Black;False;False;False;False" +
      "\nKnight;b8;Black;False;False;False;False" +
      "\nKnight;g8;Black;False;False;False;False" +
      "\nSimplePawn;a6;Black;False;False;False;False" +
      "\nSimplePawn;b6;Black;False;False;False;False" +
      "\nSimplePawn;c5;Black;False;False;False;False" +
      "\nSimplePawn;d7;Black;True;False;False;False" +
      "\nSimplePawn;f6;Black;False;False;False;False" +
      "\nSimplePawn;h6;Black;False;False;False;False";
            var blackList = blackListString.Split('\n');
            foreach (var line in blackList)
            {
                var datas = line.Split(';');
                var newPawn = new Pawn(datas[0], datas[1], new Button(), datas[2], mainWindow);
                //;{pawn.IsFirstMove};{pawn.IsFirstMoveKing};{pawn.IsLeftRookFirstMove};{pawn.IsRightRookFirstMove}
                newPawn.IsFirstMove = bool.Parse(datas[3]);
                newPawn.IsFirstMoveKing = bool.Parse(datas[4]);
                newPawn.IsLeftRookFirstMove = bool.Parse(datas[5]);
                newPawn.IsRightRookFirstMove = bool.Parse(datas[6]);
                pawnListBlack.Add(newPawn);
            }



            var pawnList = new List<Pawn>();pawnList.AddRange(pawnListWhite);pawnList.AddRange(pawnListBlack);mainWindow.PawnList = pawnList;

            using (var chess2UtilsNotStatic = new Chess2UtilsNotStatic())
            {
                var nodeResult = mainWindow.GetBestPositionLocalNotTask(mainWindow.ComputerColore);



                Assert.AreNotEqual(nodeResult.BestChildPosition, "d6");
            }


        }


        [TestMethod]
        public void MTT37LaTourDoitEtreProtegE()
        {




            
            var mainWindow = new MainWindow(); mainWindow.SetTurnNumberLabel("5");mainWindow.ComputerColore = "Black";




            
            var pawnListWhite = new List<Pawn>();
            var pawnListBlack = new List<Pawn>();



            //WHITEList
            var whiteListString = "" +
      "King;e1;White;False;True;True;True" +
      "\nQueen;d1;White;False;False;False;False" +
      "\nRook;a1;White;False;False;False;False" +
      "\nRook;h1;White;False;False;False;False" +
      "\nBishop;f4;White;False;False;False;False" +
      "\nBishop;d5;White;False;False;False;False" +
      "\nKnight;c3;White;False;False;False;False" +
      "\nKnight;g1;White;False;False;False;False" +
      "\nSimplePawn;a2;White;True;False;False;False" +
      "\nSimplePawn;b2;White;True;False;False;False" +
      "\nSimplePawn;c2;White;True;False;False;False" +
      "\nSimplePawn;e5;White;False;False;False;False" +
      "\nSimplePawn;f2;White;True;False;False;False" +
      "\nSimplePawn;g2;White;True;False;False;False" +
      "\nSimplePawn;h2;White;True;False;False;False";
            var whiteList = whiteListString.Split('\n');
            foreach (var line in whiteList)
            {
                var datas = line.Split(';');
                var newPawn = new Pawn(datas[0], datas[1], new Button(), datas[2], mainWindow);
                //;{pawn.IsFirstMove};{pawn.IsFirstMoveKing};{pawn.IsLeftRookFirstMove};{pawn.IsRightRookFirstMove}
                newPawn.IsFirstMove = bool.Parse(datas[3]);
                newPawn.IsFirstMoveKing = bool.Parse(datas[4]);
                newPawn.IsLeftRookFirstMove = bool.Parse(datas[5]);
                newPawn.IsRightRookFirstMove = bool.Parse(datas[6]);
                pawnListWhite.Add(newPawn);
            }

            //BLACKList
            var blackListString = "" +
      "King;e8;Black;False;True;True;True" +
      "\nRook;a8;Black;False;False;False;False" +
      "\nRook;h8;Black;False;False;False;False" +
      "\nBishop;c8;Black;False;False;False;False" +
      "\nBishop;g7;Black;False;False;False;False" +
      "\nKnight;b8;Black;False;False;False;False" +
      "\nKnight;g8;Black;False;False;False;False" +
      "\nSimplePawn;a7;Black;True;False;False;False" +
      "\nSimplePawn;b6;Black;False;False;False;False" +
      "\nSimplePawn;c5;Black;False;False;False;False" +
      "\nSimplePawn;d7;Black;True;False;False;False" +
      "\nSimplePawn;f7;Black;True;False;False;False" +
      "\nSimplePawn;h6;Black;False;False;False;False";
            var blackList = blackListString.Split('\n');
            foreach (var line in blackList)
            {
                var datas = line.Split(';');
                var newPawn = new Pawn(datas[0], datas[1], new Button(), datas[2], mainWindow);
                //;{pawn.IsFirstMove};{pawn.IsFirstMoveKing};{pawn.IsLeftRookFirstMove};{pawn.IsRightRookFirstMove}
                newPawn.IsFirstMove = bool.Parse(datas[3]);
                newPawn.IsFirstMoveKing = bool.Parse(datas[4]);
                newPawn.IsLeftRookFirstMove = bool.Parse(datas[5]);
                newPawn.IsRightRookFirstMove = bool.Parse(datas[6]);
                pawnListBlack.Add(newPawn);
            }



            var pawnList = new List<Pawn>();pawnList.AddRange(pawnListWhite);pawnList.AddRange(pawnListBlack);mainWindow.PawnList = pawnList;

            using (var chess2UtilsNotStatic = new Chess2UtilsNotStatic())
            {
                var nodeResult = mainWindow.GetBestPositionLocalNotTask(mainWindow.ComputerColore);

                Assert.AreEqual(nodeResult.BestChildPosition, "c6");
            }


        }

        [TestMethod]
        public void MTT38LePionNoirNeDoitPasSeMettreSurA3()
        {
            
            var mainWindow = new MainWindow(); mainWindow.SetTurnNumberLabel("5");mainWindow.ComputerColore = "Black";




            
            var pawnListWhite = new List<Pawn>();
            var pawnListBlack = new List<Pawn>();



            //WHITEList
            var whiteListString = "" +
      "King;e1;White;False;True;True;True" +
      "\nRook;a1;White;False;False;False;False" +
      "\nRook;h1;White;False;False;False;False" +
      "\nBishop;c3;White;False;False;False;False" +
      "\nKnight;b1;White;False;False;False;False" +
      "\nKnight;f5;White;False;False;False;False" +
      "\nSimplePawn;a2;White;True;False;False;False" +
      "\nSimplePawn;b2;White;True;False;False;False" +
      "\nSimplePawn;b5;White;False;False;False;False" +
      "\nSimplePawn;e4;White;False;False;False;False" +
      "\nSimplePawn;d6;White;False;False;False;False" +
      "\nSimplePawn;g3;White;False;False;False;False" +
      "\nSimplePawn;h2;White;True;False;False;False";
            var whiteList = whiteListString.Split('\n');
            foreach (var line in whiteList)
            {
                var datas = line.Split(';');
                var newPawn = new Pawn(datas[0], datas[1], new Button(), datas[2], mainWindow);
                //;{pawn.IsFirstMove};{pawn.IsFirstMoveKing};{pawn.IsLeftRookFirstMove};{pawn.IsRightRookFirstMove}
                newPawn.IsFirstMove = bool.Parse(datas[3]);
                newPawn.IsFirstMoveKing = bool.Parse(datas[4]);
                newPawn.IsLeftRookFirstMove = bool.Parse(datas[5]);
                newPawn.IsRightRookFirstMove = bool.Parse(datas[6]);
                pawnListWhite.Add(newPawn);
            }

            //BLACKList
            var blackListString = "" +
      "King;e8;Black;False;True;False;False" +
      "\nQueen;d8;Black;False;False;False;False" +
      "\nRook;a7;Black;False;False;False;False" +
      "\nRook;h7;Black;False;False;False;False" +
      "\nBishop;c8;Black;False;False;False;False" +
      "\nKnight;h5;Black;False;False;False;False" +
      "\nSimplePawn;a4;Black;False;False;False;False" +
      "\nSimplePawn;h6;Black;False;False;False;False";
            var blackList = blackListString.Split('\n');
            foreach (var line in blackList)
            {
                var datas = line.Split(';');
                var newPawn = new Pawn(datas[0], datas[1], new Button(), datas[2], mainWindow);
                //;{pawn.IsFirstMove};{pawn.IsFirstMoveKing};{pawn.IsLeftRookFirstMove};{pawn.IsRightRookFirstMove}
                newPawn.IsFirstMove = bool.Parse(datas[3]);
                newPawn.IsFirstMoveKing = bool.Parse(datas[4]);
                newPawn.IsLeftRookFirstMove = bool.Parse(datas[5]);
                newPawn.IsRightRookFirstMove = bool.Parse(datas[6]);
                pawnListBlack.Add(newPawn);
            }



            var pawnList = new List<Pawn>();pawnList.AddRange(pawnListWhite);pawnList.AddRange(pawnListBlack);mainWindow.PawnList = pawnList;

            using (var chess2UtilsNotStatic = new Chess2UtilsNotStatic())
            {
                var nodeResult = mainWindow.GetBestPositionLocalNotTask(mainWindow.ComputerColore);


                Assert.AreNotEqual(nodeResult.BestChildPosition, "a3");
            }
        }

        [TestMethod]
        public void MTT39LePionNoirNeDoitPasSeMettreSurC3()
        {
            
            var mainWindow = new MainWindow(); mainWindow.SetTurnNumberLabel("5");mainWindow.ComputerColore = "Black";




            
            var pawnListWhite = new List<Pawn>();
            var pawnListBlack = new List<Pawn>();



            //WHITEList
            var whiteListString = "" +
      "King;g2;White;False;False;True;True" +
      "\nQueen;f3;White;False;False;False;False" +
      "\nRook;f2;White;False;False;False;False" +
      "\nBishop;h8;White;False;False;False;False" +
      "\nKnight;a2;White;False;False;False;False" +
      "\nSimplePawn;f5;White;False;False;False;False" +
      "\nSimplePawn;h4;White;False;False;False;False";
            var whiteList = whiteListString.Split('\n');
            foreach (var line in whiteList)
            {
                var datas = line.Split(';');
                var newPawn = new Pawn(datas[0], datas[1], new Button(), datas[2], mainWindow);
                //;{pawn.IsFirstMove};{pawn.IsFirstMoveKing};{pawn.IsLeftRookFirstMove};{pawn.IsRightRookFirstMove}
                newPawn.IsFirstMove = bool.Parse(datas[3]);
                newPawn.IsFirstMoveKing = bool.Parse(datas[4]);
                newPawn.IsLeftRookFirstMove = bool.Parse(datas[5]);
                newPawn.IsRightRookFirstMove = bool.Parse(datas[6]);
                pawnListWhite.Add(newPawn);
            }

            //BLACKList
            var blackListString = "" +
      "King;e7;Black;False;False;True;True" +
      "\nQueen;a5;Black;False;False;False;False" +
      "\nRook;a8;Black;False;False;False;False" +
      "\nBishop;c8;Black;False;False;False;False" +
      "\nBishop;d6;Black;False;False;False;False" +
      "\nKnight;b8;Black;False;False;False;False" +
      "\nSimplePawn;b5;Black;False;False;False;False" +
      "\nSimplePawn;c4;Black;False;False;False;False" +
      "\nSimplePawn;d7;Black;True;False;False;False" +
      "\nSimplePawn;e5;Black;False;False;False;False";
            var blackList = blackListString.Split('\n');
            foreach (var line in blackList)
            {
                var datas = line.Split(';');
                var newPawn = new Pawn(datas[0], datas[1], new Button(), datas[2], mainWindow);
                //;{pawn.IsFirstMove};{pawn.IsFirstMoveKing};{pawn.IsLeftRookFirstMove};{pawn.IsRightRookFirstMove}
                newPawn.IsFirstMove = bool.Parse(datas[3]);
                newPawn.IsFirstMoveKing = bool.Parse(datas[4]);
                newPawn.IsLeftRookFirstMove = bool.Parse(datas[5]);
                newPawn.IsRightRookFirstMove = bool.Parse(datas[6]);
                pawnListBlack.Add(newPawn);
            }



            var pawnList = new List<Pawn>();pawnList.AddRange(pawnListWhite);pawnList.AddRange(pawnListBlack);mainWindow.PawnList = pawnList;

            using (var chess2UtilsNotStatic = new Chess2UtilsNotStatic())
            {
                var nodeResult = mainWindow.GetBestPositionLocalNotTask(mainWindow.ComputerColore);

                Assert.AreNotEqual(nodeResult.BestChildPosition, "c3");
            }
        }


        [TestMethod]
        public void MTT40LePionNoirNeDoitPasSeMettreSurA2()
        {
            
            var mainWindow = new MainWindow(); mainWindow.SetTurnNumberLabel("5");mainWindow.ComputerColore = "Black";




            
            var pawnListWhite = new List<Pawn>();
            var pawnListBlack = new List<Pawn>();



            //WHITEList
            var whiteListString = "" +
      "King;g2;White;False;False;True;True" +
      "\nQueen;f3;White;False;False;False;False" +
      "\nRook;f2;White;False;False;False;False" +
      "\nBishop;h8;White;False;False;False;False" +
      "\nKnight;c1;White;False;False;False;False" +
      "\nSimplePawn;f4;White;False;False;False;False" +
      "\nSimplePawn;h4;White;False;False;False;False";
            var whiteList = whiteListString.Split('\n');
            foreach (var line in whiteList)
            {
                var datas = line.Split(';');
                var newPawn = new Pawn(datas[0], datas[1], new Button(), datas[2], mainWindow);
                //;{pawn.IsFirstMove};{pawn.IsFirstMoveKing};{pawn.IsLeftRookFirstMove};{pawn.IsRightRookFirstMove}
                newPawn.IsFirstMove = bool.Parse(datas[3]);
                newPawn.IsFirstMoveKing = bool.Parse(datas[4]);
                newPawn.IsLeftRookFirstMove = bool.Parse(datas[5]);
                newPawn.IsRightRookFirstMove = bool.Parse(datas[6]);
                pawnListWhite.Add(newPawn);
            }

            //BLACKList
            var blackListString = "" +
      "King;e7;Black;False;False;True;True" +
      "\nQueen;a5;Black;False;False;False;False" +
      "\nRook;a8;Black;False;False;False;False" +
      "\nBishop;c8;Black;False;False;False;False" +
      "\nBishop;d6;Black;False;False;False;False" +
      "\nKnight;b8;Black;False;False;False;False" +
      "\nSimplePawn;a3;Black;False;False;False;False" +
      "\nSimplePawn;b5;Black;False;False;False;False" +
      "\nSimplePawn;c4;Black;False;False;False;False" +
      "\nSimplePawn;d7;Black;True;False;False;False" +
      "\nSimplePawn;e6;Black;False;False;False;False";
            var blackList = blackListString.Split('\n');
            foreach (var line in blackList)
            {
                var datas = line.Split(';');
                var newPawn = new Pawn(datas[0], datas[1], new Button(), datas[2], mainWindow);
                //;{pawn.IsFirstMove};{pawn.IsFirstMoveKing};{pawn.IsLeftRookFirstMove};{pawn.IsRightRookFirstMove}
                newPawn.IsFirstMove = bool.Parse(datas[3]);
                newPawn.IsFirstMoveKing = bool.Parse(datas[4]);
                newPawn.IsLeftRookFirstMove = bool.Parse(datas[5]);
                newPawn.IsRightRookFirstMove = bool.Parse(datas[6]);
                pawnListBlack.Add(newPawn);
            }



            var pawnList = new List<Pawn>();pawnList.AddRange(pawnListWhite);pawnList.AddRange(pawnListBlack);mainWindow.PawnList = pawnList;

            using (var chess2UtilsNotStatic = new Chess2UtilsNotStatic())
            {
                var nodeResult = mainWindow.GetBestPositionLocalNotTask(mainWindow.ComputerColore);

                Assert.AreNotEqual(nodeResult, "a2");
            }
        }


        [TestMethod]
        public void MTT41LaReineBlancheDoitMenacerLeRoiEnH5OuPrendreLaReineD6()
        {
            
            var mainWindow = new MainWindow(); mainWindow.SetTurnNumberLabel("5");mainWindow.ComputerColore = "White";




            
            var pawnListWhite = new List<Pawn>();
            var pawnListBlack = new List<Pawn>();



            //WHITEList
            var whiteListString = "" +
      "King;f2;White;False;False;True;False" +
      "\nQueen;h7;White;False;False;False;False" +
      "\nRook;a1;White;False;False;False;False" +
      "\nRook;g6;White;False;False;False;False" +
      "\nBishop;c1;White;False;False;False;False" +
      "\nBishop;c2;White;False;False;False;False" +
      "\nKnight;b1;White;False;False;False;False" +
      "\nSimplePawn;a2;White;True;False;False;False" +
      "\nSimplePawn;b3;White;False;False;False;False" +
      "\nSimplePawn;c3;White;False;False;False;False" +
      "\nSimplePawn;f4;White;False;False;False;False" +
      "\nSimplePawn;h4;White;False;False;False;False";
            var whiteList = whiteListString.Split('\n');
            foreach (var line in whiteList)
            {
                var datas = line.Split(';');
                var newPawn = new Pawn(datas[0], datas[1], new Button(), datas[2], mainWindow);
                //;{pawn.IsFirstMove};{pawn.IsFirstMoveKing};{pawn.IsLeftRookFirstMove};{pawn.IsRightRookFirstMove}
                newPawn.IsFirstMove = bool.Parse(datas[3]);
                newPawn.IsFirstMoveKing = bool.Parse(datas[4]);
                newPawn.IsLeftRookFirstMove = bool.Parse(datas[5]);
                newPawn.IsRightRookFirstMove = bool.Parse(datas[6]);
                pawnListWhite.Add(newPawn);
            }

            //BLACKList
            var blackListString = "" +
      "King;d5;Black;False;False;True;True" +
      "\nQueen;d6;Black;False;False;False;False" +
      "\nRook;a8;Black;False;False;False;False" +
      "\nBishop;b7;Black;False;False;False;False" +
      "\nSimplePawn;a7;Black;True;False;False;False" +
      "\nSimplePawn;b5;Black;False;False;False;False" +
      "\nSimplePawn;c7;Black;True;False;False;False" +
      "\nSimplePawn;d4;Black;False;False;False;False" +
      "\nSimplePawn;e7;Black;True;False;False;False";
            var blackList = blackListString.Split('\n');
            foreach (var line in blackList)
            {
                var datas = line.Split(';');
                var newPawn = new Pawn(datas[0], datas[1], new Button(), datas[2], mainWindow);
                //;{pawn.IsFirstMove};{pawn.IsFirstMoveKing};{pawn.IsLeftRookFirstMove};{pawn.IsRightRookFirstMove}
                newPawn.IsFirstMove = bool.Parse(datas[3]);
                newPawn.IsFirstMoveKing = bool.Parse(datas[4]);
                newPawn.IsLeftRookFirstMove = bool.Parse(datas[5]);
                newPawn.IsRightRookFirstMove = bool.Parse(datas[6]);
                pawnListBlack.Add(newPawn);
            }



            var pawnList = new List<Pawn>();pawnList.AddRange(pawnListWhite);pawnList.AddRange(pawnListBlack);mainWindow.PawnList = pawnList;

            using (var chess2UtilsNotStatic = new Chess2UtilsNotStatic())
            {
                var nodeResult = mainWindow.GetBestPositionLocalNotTask(mainWindow.ComputerColore);


                // var result = nodeResult.NodeRandomList.FirstOrDefault(x => x.BestChildPosition == "a2");

                var isSucces = false;
                if (nodeResult.BestChildPosition == "h5" || nodeResult.BestChildPosition == "d6")
                    isSucces = true;
                Assert.IsTrue(isSucces);
            }
        }


        [TestMethod]
        public void MTT44LePionNoirPasRamdumeB5()
        {
            
            var mainWindow = new MainWindow(); mainWindow.SetTurnNumberLabel("5");mainWindow.ComputerColore = "Black";




            
            var pawnListWhite = new List<Pawn>();
            var pawnListBlack = new List<Pawn>();



            //WHITEList
            var whiteListString = "" +
      "King;e1;White;False;True;True;True" +
      "\nQueen;e2;White;False;False;False;False" +
      "\nRook;a1;White;False;False;False;False" +
      "\nRook;h1;White;False;False;False;False" +
      "\nBishop;c1;White;False;False;False;False" +
      "\nBishop;c4;White;False;False;False;False" +
      "\nKnight;b1;White;False;False;False;False" +
      "\nKnight;f2;White;False;False;False;False" +
      "\nSimplePawn;a2;White;True;False;False;False" +
      "\nSimplePawn;b2;White;True;False;False;False" +
      "\nSimplePawn;c2;White;True;False;False;False" +
      "\nSimplePawn;d2;White;True;False;False;False" +
      "\nSimplePawn;e5;White;False;False;False;False" +
      "\nSimplePawn;g2;White;True;False;False;False" +
      "\nSimplePawn;h2;White;True;False;False;False";
            var whiteList = whiteListString.Split('\n');
            foreach (var line in whiteList)
            {
                var datas = line.Split(';');
                var newPawn = new Pawn(datas[0], datas[1], new Button(), datas[2], mainWindow);
                //;{pawn.IsFirstMove};{pawn.IsFirstMoveKing};{pawn.IsLeftRookFirstMove};{pawn.IsRightRookFirstMove}
                newPawn.IsFirstMove = bool.Parse(datas[3]);
                newPawn.IsFirstMoveKing = bool.Parse(datas[4]);
                newPawn.IsLeftRookFirstMove = bool.Parse(datas[5]);
                newPawn.IsRightRookFirstMove = bool.Parse(datas[6]);
                pawnListWhite.Add(newPawn);
            }

            //BLACKList
            var blackListString = "" +
      "King;e8;Black;False;True;True;True" +
      "\nQueen;d8;Black;False;False;False;False" +
      "\nRook;a8;Black;False;False;False;False" +
      "\nRook;h8;Black;False;False;False;False" +
      "\nBishop;c8;Black;False;False;False;False" +
      "\nBishop;c5;Black;False;False;False;False" +
      "\nKnight;b8;Black;False;False;False;False" +
      "\nSimplePawn;a7;Black;True;False;False;False" +
      "\nSimplePawn;b7;Black;True;False;False;False" +
      "\nSimplePawn;c7;Black;True;False;False;False" +
      "\nSimplePawn;d7;Black;True;False;False;False" +
      "\nSimplePawn;e6;Black;False;False;False;False" +
      "\nSimplePawn;f7;Black;True;False;False;False" +
      "\nSimplePawn;g7;Black;True;False;False;False" +
      "\nSimplePawn;h7;Black;True;False;False;False";
            var blackList = blackListString.Split('\n');
            foreach (var line in blackList)
            {
                var datas = line.Split(';');
                var newPawn = new Pawn(datas[0], datas[1], new Button(), datas[2], mainWindow);
                //;{pawn.IsFirstMove};{pawn.IsFirstMoveKing};{pawn.IsLeftRookFirstMove};{pawn.IsRightRookFirstMove}
                newPawn.IsFirstMove = bool.Parse(datas[3]);
                newPawn.IsFirstMoveKing = bool.Parse(datas[4]);
                newPawn.IsLeftRookFirstMove = bool.Parse(datas[5]);
                newPawn.IsRightRookFirstMove = bool.Parse(datas[6]);
                pawnListBlack.Add(newPawn);
            }



            var pawnList = new List<Pawn>();pawnList.AddRange(pawnListWhite);pawnList.AddRange(pawnListBlack);mainWindow.PawnList = pawnList;

            using (var chess2UtilsNotStatic = new Chess2UtilsNotStatic())
            {
                var nodeResult = mainWindow.GetBestPositionLocalNotTask(mainWindow.ComputerColore);

                // var  MTT_value = nodeResult.Weight;
                //var result = nodeResult.NodeRandomList.FirstOrDefault(x => x.BestChildPosition == "b5");
                Assert.AreNotEqual(nodeResult.BestChildPosition, "b5");
            }
        }

        #region TODO SpecificPosition

        /*
        
          [TestMethod]
        public void MTT51aLeFouBlanchDoiSeMettreSurH5SecificPosition1()
        {
            //Pour les SpecificPositions il faut se connecter � la base
            
            //Pour les SpecificPositions il faut se connecter � la base
            //mainWindow.SetIsConnectedDB(true);
            var mainWindow = new MainWindow(); mainWindow.SetTurnNumberLabel("5");mainWindow.ComputerColore = "White";




            
            var pawnListWhite = new List<Pawn>();
            var pawnListBlack = new List<Pawn>();



            //WHITEList
            var whiteListString = "" +
      "King;g1;White;False;True;True;True" +
      "\nQueen;d1;White;False;False;False;False" +
      "\nRook;a1;White;False;False;False;False" +
      "\nRook;f1;White;False;False;False;False" +
      "\nKnight;b1;White;False;False;False;False" +
      "\nBishop;c1;White;False;False;False;False" +
      "\nBishop;e2;White;False;False;False;False" +
      "\nKnight;h4;White;False;False;False;False" +
      "\nSimplePawn;a2;White;True;False;False;False" +
      "\nSimplePawn;b2;White;True;False;False;False" +
      "\nSimplePawn;c4;White;False;False;False;False" +
      "\nSimplePawn;e4;White;False;False;False;False" +
      "\nSimplePawn;f2;White;True;False;False;False" +
      "\nSimplePawn;g2;White;True;False;False;False" +
      "\nSimplePawn;h2;White;True;False;False;False";
            var whiteList = whiteListString.Split('\n');
            foreach (var line in whiteList)
            {
                var datas = line.Split(';');
                var newPawn = new Pawn(datas[0], datas[1], new Button(), datas[2], mainWindow);
                //;{pawn.IsFirstMove};{pawn.IsFirstMoveKing};{pawn.IsLeftRookFirstMove};{pawn.IsRightRookFirstMove}
                newPawn.IsFirstMove = bool.Parse(datas[3]);
                newPawn.IsFirstMoveKing = bool.Parse(datas[4]);
                newPawn.IsLeftRookFirstMove = bool.Parse(datas[5]);
                newPawn.IsRightRookFirstMove = bool.Parse(datas[6]);
                pawnListWhite.Add(newPawn);
            }

            //BLACKList
            var blackListString = "" +
      "King;e8;Black;False;True;True;True" +
      "\nQueen;d8;Black;False;False;False;False" +
      "\nRook;a8;Black;False;False;False;False" +
      "\nRook;h8;Black;False;False;False;False" +
      "\nKnight;b8;Black;False;False;False;False" +
      "\nBishop;b7;Black;False;False;False;False" +
      "\nBishop;f8;Black;False;False;False;False" +
      "\nKnight;g8;Black;False;False;False;False" +
      "\nSimplePawn;a5;Black;False;False;False;False" +
      "\nSimplePawn;b6;Black;False;False;False;False" +
      "\nSimplePawn;c5;Black;False;False;False;False" +
      "\nSimplePawn;d7;Black;True;False;False;False" +
      "\nSimplePawn;d5;Black;False;False;False;False" +
      "\nSimplePawn;f6;Black;False;False;False;False" +
      "\nSimplePawn;g7;Black;True;False;False;False" +
      "\nSimplePawn;h5;Black;False;False;False;False";
            var blackList = blackListString.Split('\n');
            foreach (var line in blackList)
            {
                var datas = line.Split(';');
                var newPawn = new Pawn(datas[0], datas[1], new Button(), datas[2], mainWindow);
                //;{pawn.IsFirstMove};{pawn.IsFirstMoveKing};{pawn.IsLeftRookFirstMove};{pawn.IsRightRookFirstMove}
                newPawn.IsFirstMove = bool.Parse(datas[3]);
                newPawn.IsFirstMoveKing = bool.Parse(datas[4]);
                newPawn.IsLeftRookFirstMove = bool.Parse(datas[5]);
                newPawn.IsRightRookFirstMove = bool.Parse(datas[6]);
                pawnListBlack.Add(newPawn);
            }



            var pawnList = new List<Pawn>();pawnList.AddRange(pawnListWhite);pawnList.AddRange(pawnListBlack);mainWindow.PawnList = pawnList;

            using (var chess2UtilsNotStatic = new Chess2UtilsNotStatic())
            {
                var nodeResult = mainWindow.GetBestPositionLocalNotTask(mainWindow.ComputerColore);


                Assert.AreEqual(nodeResult.BestChildPosition, "h5");
            }
        }


        [TestMethod]
        public void MTT51bLeFouNoirDoitSeMettreSurH4SecificPosition1Symetri()
        {
            //Pour les SpecificPositions il faut se connecter � la base
            
            //Pour les SpecificPositions il faut se connecter � la base
            //mainWindow.SetIsConnectedDB(true);
            var mainWindow = new MainWindow(); mainWindow.SetTurnNumberLabel("5");mainWindow.ComputerColore = "Black";





            
            var pawnListWhite = new List<Pawn>();
            var pawnListBlack = new List<Pawn>();



            //WHITEList
            var whiteListString = "" +
      "King;e1;White;False;True;True;True" +
      "\nQueen;d1;White;False;False;False;False" +
      "\nRook;a1;White;False;False;False;False" +
      "\nRook;h1;White;False;False;False;False" +
      "\nKnight;b1;White;False;False;False;False" +
      "\nBishop;b2;White;False;False;False;False" +
      "\nBishop;f1;White;False;False;False;False" +
      "\nKnight;g1;White;False;False;False;False" +
      "\nSimplePawn;a4;White;False;False;False;False" +
      "\nSimplePawn;b3;White;False;False;False;False" +
      "\nSimplePawn;c4;White;False;False;False;False" +
      "\nSimplePawn;d2;White;True;False;False;False" +
      "\nSimplePawn;d4;White;False;False;False;False" +
      "\nSimplePawn;f3;White;False;False;False;False" +
      "\nSimplePawn;g2;White;True;False;False;False" +
      "\nSimplePawn;h4;White;False;False;False;False";
            var whiteList = whiteListString.Split('\n');
            foreach (var line in whiteList)
            {
                var datas = line.Split(';');
                var newPawn = new Pawn(datas[0], datas[1], new Button(), datas[2], mainWindow);
                //;{pawn.IsFirstMove};{pawn.IsFirstMoveKing};{pawn.IsLeftRookFirstMove};{pawn.IsRightRookFirstMove}
                newPawn.IsFirstMove = bool.Parse(datas[3]);
                newPawn.IsFirstMoveKing = bool.Parse(datas[4]);
                newPawn.IsLeftRookFirstMove = bool.Parse(datas[5]);
                newPawn.IsRightRookFirstMove = bool.Parse(datas[6]);
                pawnListWhite.Add(newPawn);
            }

            //BLACKList
            var blackListString = "" +
      "King;g8;Black;False;True;True;True" +
      "\nQueen;d8;Black;False;False;False;False" +
      "\nRook;a8;Black;False;False;False;False" +
      "\nRook;f8;Black;False;False;False;False" +
      "\nKnight;b8;Black;False;False;False;False" +
      "\nBishop;c8;Black;False;False;False;False" +
      "\nBishop;e7;Black;False;False;False;False" +
      "\nKnight;h5;Black;False;False;False;False" +
      "\nSimplePawn;a7;Black;True;False;False;False" +
      "\nSimplePawn;b7;Black;True;False;False;False" +
      "\nSimplePawn;c5;Black;False;False;False;False" +
      "\nSimplePawn;e5;Black;False;False;False;False" +
      "\nSimplePawn;f7;Black;True;False;False;False" +
      "\nSimplePawn;g7;Black;True;False;False;False" +
      "\nSimplePawn;h7;Black;True;False;False;False";
            var blackList = blackListString.Split('\n');
            foreach (var line in blackList)
            {
                var datas = line.Split(';');
                var newPawn = new Pawn(datas[0], datas[1], new Button(), datas[2], mainWindow);
                //;{pawn.IsFirstMove};{pawn.IsFirstMoveKing};{pawn.IsLeftRookFirstMove};{pawn.IsRightRookFirstMove}
                newPawn.IsFirstMove = bool.Parse(datas[3]);
                newPawn.IsFirstMoveKing = bool.Parse(datas[4]);
                newPawn.IsLeftRookFirstMove = bool.Parse(datas[5]);
                newPawn.IsRightRookFirstMove = bool.Parse(datas[6]);
                pawnListBlack.Add(newPawn);
            }



            var pawnList = new List<Pawn>();pawnList.AddRange(pawnListWhite);pawnList.AddRange(pawnListBlack);mainWindow.PawnList = pawnList;

            using (var chess2UtilsNotStatic = new Chess2UtilsNotStatic())
            {
                var nodeResult = mainWindow.GetBestPositionLocalNotTask(mainWindow.ComputerColore);


                Assert.AreEqual(nodeResult.BestChildPosition, "h4");
            }
        }

        [TestMethod]
        public void MTT45LeChevalierBlacnDoitSeNettreEnG5SpecificPosition0()
        {

            
            //Pour les SpecificPositions il faut se connecter � la base
           // //mainWindow.SetIsConnectedDB(true);


            var mainWindow = new MainWindow(); mainWindow.SetTurnNumberLabel("5");mainWindow.ComputerColore = "White";





            
            var pawnListWhite = new List<Pawn>();
            var pawnListBlack = new List<Pawn>();



            //WHITEList
            var whiteListString = "" +
      "King;e1;White;False;True;True;True" +
      "\nQueen;d1;White;False;False;False;False" +
      "\nRook;a1;White;False;False;False;False" +
      "\nRook;h1;White;False;False;False;False" +
      "\nBishop;c1;White;False;False;False;False" +
      "\nBishop;c4;White;False;False;False;False" +
      "\nKnight;c3;White;False;False;False;False" +
      "\nKnight;f3;White;False;False;False;False" +
      "\nSimplePawn;a2;White;True;False;False;False" +
      "\nSimplePawn;b2;White;True;False;False;False" +
      "\nSimplePawn;c2;White;True;False;False;False" +
      "\nSimplePawn;d4;White;False;False;False;False" +
      "\nSimplePawn;e4;White;False;False;False;False" +
      "\nSimplePawn;f2;White;True;False;False;False" +
      "\nSimplePawn;g2;White;True;False;False;False" +
      "\nSimplePawn;h2;White;True;False;False;False";
            var whiteList = whiteListString.Split('\n');
            foreach (var line in whiteList)
            {
                var datas = line.Split(';');
                var newPawn = new Pawn(datas[0], datas[1], new Button(), datas[2], mainWindow);
                //;{pawn.IsFirstMove};{pawn.IsFirstMoveKing};{pawn.IsLeftRookFirstMove};{pawn.IsRightRookFirstMove}
                newPawn.IsFirstMove = bool.Parse(datas[3]);
                newPawn.IsFirstMoveKing = bool.Parse(datas[4]);
                newPawn.IsLeftRookFirstMove = bool.Parse(datas[5]);
                newPawn.IsRightRookFirstMove = bool.Parse(datas[6]);
                pawnListWhite.Add(newPawn);
            }

            //BLACKList
            var blackListString = "" +
      "King;e8;Black;False;True;True;True" +
      "\nQueen;d8;Black;False;False;False;False" +
      "\nRook;a8;Black;False;False;False;False" +
      "\nRook;h8;Black;False;False;False;False" +
      "\nBishop;c8;Black;False;False;False;False" +
      "\nBishop;f8;Black;False;False;False;False" +
      "\nKnight;b8;Black;False;False;False;False" +
      "\nKnight;f6;Black;False;False;False;False" +
      "\nSimplePawn;a5;Black;False;False;False;False" +
      "\nSimplePawn;b6;Black;False;False;False;False" +
      "\nSimplePawn;c6;Black;False;False;False;False" +
      "\nSimplePawn;d6;Black;False;False;False;False" +
      "\nSimplePawn;e7;Black;True;False;False;False" +
      "\nSimplePawn;f7;Black;True;False;False;False" +
      "\nSimplePawn;g7;Black;True;False;False;False" +
      "\nSimplePawn;h7;Black;True;False;False;False";
            var blackList = blackListString.Split('\n');
            foreach (var line in blackList)
            {
                var datas = line.Split(';');
                var newPawn = new Pawn(datas[0], datas[1], new Button(), datas[2], mainWindow);
                //;{pawn.IsFirstMove};{pawn.IsFirstMoveKing};{pawn.IsLeftRookFirstMove};{pawn.IsRightRookFirstMove}
                newPawn.IsFirstMove = bool.Parse(datas[3]);
                newPawn.IsFirstMoveKing = bool.Parse(datas[4]);
                newPawn.IsLeftRookFirstMove = bool.Parse(datas[5]);
                newPawn.IsRightRookFirstMove = bool.Parse(datas[6]);
                pawnListBlack.Add(newPawn);
            }



            var pawnList = new List<Pawn>();pawnList.AddRange(pawnListWhite);pawnList.AddRange(pawnListBlack);mainWindow.PawnList = pawnList;

            using (var chess2UtilsNotStatic = new Chess2UtilsNotStatic())
            {
                var nodeResult = mainWindow.GetBestPositionLocalNotTask(mainWindow.ComputerColore);

                // var  MTT_value = nodeResult.Weight;
                //var result = nodeResult.NodeRandomList.FirstOrDefault(x => x.BestChildPosition == "b5");
                Assert.AreEqual(nodeResult.BestChildPosition, "g5");
            }
        }



        [TestMethod]
        public void MTT46LeFouBlacnDoitSeNettreEncC4SpecificPosition0()
        {
            //Pour les SpecificPositions il faut se connecter � la base
            
            //Pour les SpecificPositions il faut se connecter � la base
            ////mainWindow.SetIsConnectedDB(true);


            var mainWindow = new MainWindow(); mainWindow.SetTurnNumberLabel("5");mainWindow.ComputerColore = "White";




            
            var pawnListWhite = new List<Pawn>();
            var pawnListBlack = new List<Pawn>();



            //WHITEList
            var whiteListString = "" +
      "King;e1;White;False;True;True;True" +
      "\nQueen;d1;White;False;False;False;False" +
      "\nRook;a1;White;False;False;False;False" +
      "\nRook;h1;White;False;False;False;False" +
      "\nBishop;c1;White;False;False;False;False" +
      "\nBishop;f1;White;False;False;False;False" +
      "\nKnight;c3;White;False;False;False;False" +
      "\nKnight;g5;White;False;False;False;False" +
      "\nSimplePawn;a2;White;True;False;False;False" +
      "\nSimplePawn;b2;White;True;False;False;False" +
      "\nSimplePawn;c2;White;True;False;False;False" +
      "\nSimplePawn;d4;White;False;False;False;False" +
      "\nSimplePawn;e4;White;False;False;False;False" +
      "\nSimplePawn;f2;White;True;False;False;False" +
      "\nSimplePawn;g2;White;True;False;False;False" +
      "\nSimplePawn;h2;White;True;False;False;False";
            var whiteList = whiteListString.Split('\n');
            foreach (var line in whiteList)
            {
                var datas = line.Split(';');
                var newPawn = new Pawn(datas[0], datas[1], new Button(), datas[2], mainWindow);
                //;{pawn.IsFirstMove};{pawn.IsFirstMoveKing};{pawn.IsLeftRookFirstMove};{pawn.IsRightRookFirstMove}
                newPawn.IsFirstMove = bool.Parse(datas[3]);
                newPawn.IsFirstMoveKing = bool.Parse(datas[4]);
                newPawn.IsLeftRookFirstMove = bool.Parse(datas[5]);
                newPawn.IsRightRookFirstMove = bool.Parse(datas[6]);
                pawnListWhite.Add(newPawn);
            }

            //BLACKList
            var blackListString = "" +
      "King;e8;Black;False;True;True;True" +
      "\nQueen;d8;Black;False;False;False;False" +
      "\nRook;a8;Black;False;False;False;False" +
      "\nRook;h8;Black;False;False;False;False" +
      "\nBishop;c8;Black;False;False;False;False" +
      "\nBishop;f8;Black;False;False;False;False" +
      "\nKnight;b8;Black;False;False;False;False" +
      "\nKnight;f6;Black;False;False;False;False" +
      "\nSimplePawn;a5;Black;False;False;False;False" +
      "\nSimplePawn;b6;Black;False;False;False;False" +
      "\nSimplePawn;c6;Black;False;False;False;False" +
      "\nSimplePawn;d6;Black;False;False;False;False" +
      "\nSimplePawn;e7;Black;True;False;False;False" +
      "\nSimplePawn;f7;Black;True;False;False;False" +
      "\nSimplePawn;g7;Black;True;False;False;False" +
      "\nSimplePawn;h7;Black;True;False;False;False";
            var blackList = blackListString.Split('\n');
            foreach (var line in blackList)
            {
                var datas = line.Split(';');
                var newPawn = new Pawn(datas[0], datas[1], new Button(), datas[2], mainWindow);
                //;{pawn.IsFirstMove};{pawn.IsFirstMoveKing};{pawn.IsLeftRookFirstMove};{pawn.IsRightRookFirstMove}
                newPawn.IsFirstMove = bool.Parse(datas[3]);
                newPawn.IsFirstMoveKing = bool.Parse(datas[4]);
                newPawn.IsLeftRookFirstMove = bool.Parse(datas[5]);
                newPawn.IsRightRookFirstMove = bool.Parse(datas[6]);
                pawnListBlack.Add(newPawn);
            }



            var pawnList = new List<Pawn>();pawnList.AddRange(pawnListWhite);pawnList.AddRange(pawnListBlack);mainWindow.PawnList = pawnList;

            using (var chess2UtilsNotStatic = new Chess2UtilsNotStatic())
            {
                var nodeResult = mainWindow.GetBestPositionLocalNotTask(mainWindow.ComputerColore);

                // var  MTT_value = nodeResult.Weight;
                //var result = nodeResult.NodeRandomList.FirstOrDefault(x => x.BestChildPosition == "b5");
                Assert.AreEqual(nodeResult.BestChildPosition, "c4");
            }
        }


        [TestMethod]
        public void MTT47LesNoirsDoiventEviterLeSpecificPosition0()
        {
            //Pour les SpecificPositions il faut se connecter � la base
            
            //Pour les SpecificPositions il faut se connecter � la base
            //mainWindow.SetIsConnectedDB(true);
            var mainWindow = new MainWindow(); mainWindow.SetTurnNumberLabel("5");mainWindow.ComputerColore = "Black";



            
            var pawnListWhite = new List<Pawn>();
            var pawnListBlack = new List<Pawn>();



            //WHITEList
            var whiteListString = "" +
      "King;e1;White;False;True;True;True" +
      "\nQueen;d1;White;False;False;False;False" +
      "\nRook;a1;White;False;False;False;False" +
      "\nRook;h1;White;False;False;False;False" +
      "\nBishop;c1;White;False;False;False;False" +
      "\nBishop;c4;White;False;False;False;False" +
      "\nKnight;c3;White;False;False;False;False" +
      "\nKnight;f3;White;False;False;False;False" +
      "\nSimplePawn;a2;White;True;False;False;False" +
      "\nSimplePawn;b2;White;True;False;False;False" +
      "\nSimplePawn;c2;White;True;False;False;False" +
      "\nSimplePawn;d4;White;False;False;False;False" +
      "\nSimplePawn;e4;White;False;False;False;False" +
      "\nSimplePawn;f2;White;True;False;False;False" +
      "\nSimplePawn;g2;White;True;False;False;False" +
      "\nSimplePawn;h2;White;True;False;False;False";
            var whiteList = whiteListString.Split('\n');
            foreach (var line in whiteList)
            {
                var datas = line.Split(';');
                var newPawn = new Pawn(datas[0], datas[1], new Button(), datas[2], mainWindow);
                //;{pawn.IsFirstMove};{pawn.IsFirstMoveKing};{pawn.IsLeftRookFirstMove};{pawn.IsRightRookFirstMove}
                newPawn.IsFirstMove = bool.Parse(datas[3]);
                newPawn.IsFirstMoveKing = bool.Parse(datas[4]);
                newPawn.IsLeftRookFirstMove = bool.Parse(datas[5]);
                newPawn.IsRightRookFirstMove = bool.Parse(datas[6]);
                pawnListWhite.Add(newPawn);
            }

            //BLACKList
            var blackListString = "" +
      "King;e8;Black;False;True;True;True" +
      "\nQueen;d8;Black;False;False;False;False" +
      "\nRook;a8;Black;False;False;False;False" +
      "\nRook;h8;Black;False;False;False;False" +
      "\nBishop;c8;Black;False;False;False;False" +
      "\nBishop;f8;Black;False;False;False;False" +
      "\nKnight;b8;Black;False;False;False;False" +
      "\nKnight;f6;Black;False;False;False;False" +
      "\nSimplePawn;a5;Black;False;False;False;False" +
      "\nSimplePawn;b6;Black;False;False;False;False" +
      "\nSimplePawn;c6;Black;False;False;False;False" +
      "\nSimplePawn;d6;Black;False;False;False;False" +
      "\nSimplePawn;e7;Black;True;False;False;False" +
      "\nSimplePawn;f7;Black;True;False;False;False" +
      "\nSimplePawn;g7;Black;True;False;False;False" +
      "\nSimplePawn;h7;Black;True;False;False;False";
            var blackList = blackListString.Split('\n');
            foreach (var line in blackList)
            {
                var datas = line.Split(';');
                var newPawn = new Pawn(datas[0], datas[1], new Button(), datas[2], mainWindow);
                //;{pawn.IsFirstMove};{pawn.IsFirstMoveKing};{pawn.IsLeftRookFirstMove};{pawn.IsRightRookFirstMove}
                newPawn.IsFirstMove = bool.Parse(datas[3]);
                newPawn.IsFirstMoveKing = bool.Parse(datas[4]);
                newPawn.IsLeftRookFirstMove = bool.Parse(datas[5]);
                newPawn.IsRightRookFirstMove = bool.Parse(datas[6]);
                pawnListBlack.Add(newPawn);
            }



            var pawnList = new List<Pawn>();pawnList.AddRange(pawnListWhite);pawnList.AddRange(pawnListBlack);mainWindow.PawnList = pawnList;

            using (var chess2UtilsNotStatic = new Chess2UtilsNotStatic())
            {
                var nodeResult = mainWindow.GetBestPositionLocalNotTask(mainWindow.ComputerColore);
                var isSucces = false;
                if (nodeResult.BestChildPosition == "g4" || nodeResult.BestChildPosition == "e6" || nodeResult.BestChildPosition == "h6" || nodeResult.BestChildPosition == "c8" || nodeResult.BestChildPosition == "c7")
                    isSucces = true;
                Assert.IsTrue(isSucces);
            }
        }
        */
        #endregion

        [TestMethod]
        public void MTT49LesNoirsDoiventprotegerLeRoiMenacE()
        {
            
            var mainWindow = new MainWindow(); mainWindow.SetTurnNumberLabel("5");mainWindow.ComputerColore = "Black";



            var testName = "T49LesNoirsDoiventprotegerLeRoiMenacE";
            var testPath = Path.Combine(testsDirrectory, testName);
           mainWindow.LoadFromDirectorie(testPath);
        

          
            using (var chess2UtilsNotStatic = new Chess2UtilsNotStatic())
            {
                var nodeResult = mainWindow.GetBestPositionLocalNotTask(mainWindow.ComputerColore);


                // var randomList = nodeResult.AsssociateNodeChess2.RandomEquivalentList;
                // Assert.IsNull(randomList);


                Assert.AreEqual(nodeResult.BestChildPosition, "e2");
            }
        }


        [TestMethod]
        public void MTT50LaToureNoirDoitSeMettreEnA7()
        {
            
            var mainWindow = new MainWindow(); mainWindow.SetTurnNumberLabel("5");mainWindow.ComputerColore = "Black";




            
            var pawnListWhite = new List<Pawn>();
            var pawnListBlack = new List<Pawn>();



            //WHITEList
            var whiteListString = "" +
      "King;e1;White;False;True;True;True" +
      "\nQueen;c3;White;False;False;False;False" +
      "\nRook;a1;White;False;False;False;False" +
      "\nRook;h1;White;False;False;False;False" +
      "\nBishop;c1;White;False;False;False;False" +
      "\nKnight;a7;White;False;False;False;False" +
      "\nKnight;g1;White;False;False;False;False" +
      "\nSimplePawn;a2;White;True;False;False;False" +
      "\nSimplePawn;b4;White;False;False;False;False" +
      "\nSimplePawn;c2;White;True;False;False;False" +
      "\nSimplePawn;d2;White;True;False;False;False" +
      "\nSimplePawn;e4;White;False;False;False;False" +
      "\nSimplePawn;f2;White;True;False;False;False" +
      "\nSimplePawn;g2;White;True;False;False;False" +
      "\nSimplePawn;h2;White;True;False;False;False";
            var whiteList = whiteListString.Split('\n');
            foreach (var line in whiteList)
            {
                var datas = line.Split(';');
                var newPawn = new Pawn(datas[0], datas[1], new Button(), datas[2], mainWindow);
                //;{pawn.IsFirstMove};{pawn.IsFirstMoveKing};{pawn.IsLeftRookFirstMove};{pawn.IsRightRookFirstMove}
                newPawn.IsFirstMove = bool.Parse(datas[3]);
                newPawn.IsFirstMoveKing = bool.Parse(datas[4]);
                newPawn.IsLeftRookFirstMove = bool.Parse(datas[5]);
                newPawn.IsRightRookFirstMove = bool.Parse(datas[6]);
                pawnListWhite.Add(newPawn);
            }

            //BLACKList
            var blackListString = "" +
      "King;e8;Black;False;False;True;True" +
      "\nQueen;d8;Black;False;False;False;False" +
      "\nRook;a8;Black;False;False;False;False" +
      "\nRook;h8;Black;False;False;False;False" +
      "\nBishop;c8;Black;False;False;False;False" +
      "\nBishop;h6;Black;False;False;False;False" +
      "\nKnight;b8;Black;False;False;False;False" +
      "\nKnight;g8;Black;False;False;False;False" +
      "\nSimplePawn;d7;Black;True;False;False;False" +
      "\nSimplePawn;e6;Black;False;False;False;False" +
      "\nSimplePawn;f6;Black;False;False;False;False" +
      "\nSimplePawn;g6;Black;False;False;False;False" +
      "\nSimplePawn;h7;Black;True;False;False;False";
            var blackList = blackListString.Split('\n');
            foreach (var line in blackList)
            {
                var datas = line.Split(';');
                var newPawn = new Pawn(datas[0], datas[1], new Button(), datas[2], mainWindow);
                //;{pawn.IsFirstMove};{pawn.IsFirstMoveKing};{pawn.IsLeftRookFirstMove};{pawn.IsRightRookFirstMove}
                newPawn.IsFirstMove = bool.Parse(datas[3]);
                newPawn.IsFirstMoveKing = bool.Parse(datas[4]);
                newPawn.IsLeftRookFirstMove = bool.Parse(datas[5]);
                newPawn.IsRightRookFirstMove = bool.Parse(datas[6]);
                pawnListBlack.Add(newPawn);
            }



            var pawnList = new List<Pawn>();pawnList.AddRange(pawnListWhite);pawnList.AddRange(pawnListBlack);mainWindow.PawnList = pawnList;

            using (var chess2UtilsNotStatic = new Chess2UtilsNotStatic())
            {
                var nodeResult = mainWindow.GetBestPositionLocalNotTask(mainWindow.ComputerColore);


                Assert.AreEqual(nodeResult.BestChildPosition, "a7");
            }
        }

      

        [TestMethod]
        /*tsiry;26-08-2021*/
        public void MTT52LaReineNoirNeDoitPasSeMettreEnC2()
        {
            
            var mainWindow = new MainWindow(); mainWindow.SetTurnNumberLabel("5");mainWindow.ComputerColore = "Black";




            
            var pawnListWhite = new List<Pawn>();
            var pawnListBlack = new List<Pawn>();



            //WHITEList
            var whiteListString = "" +
      "King;e1;White;False;True;True;True" +
      "\nQueen;d1;White;False;False;False;False" +
      "\nRook;a1;White;False;False;False;False" +
      "\nRook;h1;White;False;False;False;False" +
      "\nKnight;b1;White;False;False;False;False" +
      "\nBishop;c1;White;False;False;False;False" +
      "\nSimplePawn;a2;White;True;False;False;False" +
      "\nSimplePawn;b2;White;True;False;False;False" +
      "\nSimplePawn;c2;White;True;False;False;False" +
      "\nSimplePawn;d2;White;True;False;False;False" +
      "\nSimplePawn;e2;White;True;False;False;False" +
      "\nSimplePawn;f2;White;True;False;False;False" +
      "\nSimplePawn;g3;White;False;False;False;False" +
      "\nSimplePawn;h5;White;False;False;False;False";
            var whiteList = whiteListString.Split('\n');
            foreach (var line in whiteList)
            {
                var datas = line.Split(';');
                var newPawn = new Pawn(datas[0], datas[1], new Button(), datas[2], mainWindow);
                //;{pawn.IsFirstMove};{pawn.IsFirstMoveKing};{pawn.IsLeftRookFirstMove};{pawn.IsRightRookFirstMove}
                newPawn.IsFirstMove = bool.Parse(datas[3]);
                newPawn.IsFirstMoveKing = bool.Parse(datas[4]);
                newPawn.IsLeftRookFirstMove = bool.Parse(datas[5]);
                newPawn.IsRightRookFirstMove = bool.Parse(datas[6]);
                pawnListWhite.Add(newPawn);
            }

            //BLACKList
            var blackListString = "" +
      "King;e8;Black;False;True;True;True" +
      "\nQueen;g6;Black;False;False;False;False" +
      "\nRook;a8;Black;False;False;False;False" +
      "\nRook;h8;Black;False;False;False;False" +
      "\nKnight;b8;Black;False;False;False;False" +
      "\nBishop;c8;Black;False;False;False;False" +
      "\nBishop;d6;Black;False;False;False;False" +
      "\nKnight;g8;Black;False;False;False;False" +
      "\nSimplePawn;a6;Black;False;False;False;False" +
      "\nSimplePawn;b7;Black;True;False;False;False" +
      "\nSimplePawn;c7;Black;True;False;False;False" +
      "\nSimplePawn;e6;Black;False;False;False;False" +
      "\nSimplePawn;f7;Black;True;False;False;False" +
      "\nSimplePawn;g7;Black;True;False;False;False" +
      "\nSimplePawn;h7;Black;True;False;False;False";
            var blackList = blackListString.Split('\n');
            foreach (var line in blackList)
            {
                var datas = line.Split(';');
                var newPawn = new Pawn(datas[0], datas[1], new Button(), datas[2], mainWindow);
                //;{pawn.IsFirstMove};{pawn.IsFirstMoveKing};{pawn.IsLeftRookFirstMove};{pawn.IsRightRookFirstMove}
                newPawn.IsFirstMove = bool.Parse(datas[3]);
                newPawn.IsFirstMoveKing = bool.Parse(datas[4]);
                newPawn.IsLeftRookFirstMove = bool.Parse(datas[5]);
                newPawn.IsRightRookFirstMove = bool.Parse(datas[6]);
                pawnListBlack.Add(newPawn);
            }



            var pawnList = new List<Pawn>();pawnList.AddRange(pawnListWhite);pawnList.AddRange(pawnListBlack);mainWindow.PawnList = pawnList;

            using (var chess2UtilsNotStatic = new Chess2UtilsNotStatic())
            {
                var nodeResult = mainWindow.GetBestPositionLocalNotTask(mainWindow.ComputerColore);


                Assert.AreNotEqual(nodeResult.BestChildPosition, "c2");
            }
        }


        [TestMethod]
        /*tsiry;26-08-2021*/
        public void MTT53LaPositionFinalNoirNeDoitEtreE6OuE5()
        {
            
            var mainWindow = new MainWindow(); mainWindow.SetTurnNumberLabel("5");mainWindow.ComputerColore = "Black";

            var testName = "T53LaPositionFinalNoirNeDoitEtreE6OuE5";
            var testPath = Path.Combine(testsDirrectory, testName);
           mainWindow.LoadFromDirectorie(testPath);
            using (var chess2UtilsNotStatic = new Chess2UtilsNotStatic())
            {
                //var nodeResult = mainWindow.GetBestPositionLocalNotTask(mainWindow.ComputerColore);
                //Assert.AreEqual(nodeResult.BestChildPosition, "h1");

                var nodeResult = mainWindow.GetBestPositionLocalNotTask(mainWindow.ComputerColore);
                

                var isSucces = (nodeResult.BestChildPosition == "e6" || nodeResult.BestChildPosition == "e5");
                Assert.IsFalse(isSucces);

            }



        }


        [TestMethod]
        /*tsiry;27-08-2021*/
        public void MTT54ALesBlanchDoiventEviterLEvolutionDuPion()
        {
            
            var mainWindow = new MainWindow(); mainWindow.SetTurnNumberLabel("5");mainWindow.ComputerColore = "White";




            
            var pawnListWhite = new List<Pawn>();
            var pawnListBlack = new List<Pawn>();



            //WHITEList
            var whiteListString = "" +
      "King;d1;White;False;False;True;True" +
      "\nQueen;e3;White;False;False;False;False" +
      "\nRook;a1;White;False;False;False;False" +
      "\nBishop;c4;White;False;False;False;False" +
      "\nKnight;g1;White;False;False;False;False" +
      "\nSimplePawn;a5;White;False;False;False;False" +
      "\nSimplePawn;h3;White;False;False;False;False";
            var whiteList = whiteListString.Split('\n');
            foreach (var line in whiteList)
            {
                var datas = line.Split(';');
                var newPawn = new Pawn(datas[0], datas[1], new Button(), datas[2], mainWindow);
                //;{pawn.IsFirstMove};{pawn.IsFirstMoveKing};{pawn.IsLeftRookFirstMove};{pawn.IsRightRookFirstMove}
                newPawn.IsFirstMove = bool.Parse(datas[3]);
                newPawn.IsFirstMoveKing = bool.Parse(datas[4]);
                newPawn.IsLeftRookFirstMove = bool.Parse(datas[5]);
                newPawn.IsRightRookFirstMove = bool.Parse(datas[6]);
                pawnListWhite.Add(newPawn);
            }

            //BLACKList
            var blackListString = "" +
      "King;e8;Black;False;True;False;False" +
      "\nQueen;b4;Black;False;False;False;False" +
      "\nBishop;h1;Black;False;False;False;False" +
      "\nBishop;e7;Black;False;False;False;False" +
      "\nSimplePawn;b2;Black;False;False;False;False" +
      "\nSimplePawn;g7;Black;True;False;False;False" +
      "\nSimplePawn;g6;Black;False;False;False;False";
            var blackList = blackListString.Split('\n');
            foreach (var line in blackList)
            {
                var datas = line.Split(';');
                var newPawn = new Pawn(datas[0], datas[1], new Button(), datas[2], mainWindow);
                //;{pawn.IsFirstMove};{pawn.IsFirstMoveKing};{pawn.IsLeftRookFirstMove};{pawn.IsRightRookFirstMove}
                newPawn.IsFirstMove = bool.Parse(datas[3]);
                newPawn.IsFirstMoveKing = bool.Parse(datas[4]);
                newPawn.IsLeftRookFirstMove = bool.Parse(datas[5]);
                newPawn.IsRightRookFirstMove = bool.Parse(datas[6]);
                pawnListBlack.Add(newPawn);
            }



            var pawnList = new List<Pawn>();pawnList.AddRange(pawnListWhite);pawnList.AddRange(pawnListBlack);mainWindow.PawnList = pawnList;

            using (var chess2UtilsNotStatic = new Chess2UtilsNotStatic())
            {
                var nodeResult = mainWindow.GetBestPositionLocalNotTask(mainWindow.ComputerColore);

                var randomList = nodeResult.AsssociateNodeChess2.RandomEquivalentList;


                var succes = false;

                if (randomList.Count == 0)
                    succes = true;



                Assert.IsTrue(succes);

                Assert.AreEqual(nodeResult.BestChildPosition, "b1");
            }
        }


        [TestMethod]
        /*tsiry;27-08-2021*/
        public void MTT54BLaRaineBlancDoitMenacerLeRoiEtSeMettreEnG6()
        {
            
            var mainWindow = new MainWindow(); mainWindow.SetTurnNumberLabel("5");mainWindow.ComputerColore = "White";




            
            var pawnListWhite = new List<Pawn>();
            var pawnListBlack = new List<Pawn>();



            //WHITEList
            var whiteListString = "" +
      "King;d1;White;False;False;True;True" +
      "\nQueen;d3;White;False;False;False;False" +
      "\nRook;a1;White;False;False;False;False" +
      "\nBishop;c4;White;False;False;False;False" +
      "\nKnight;g1;White;False;False;False;False" +
      "\nSimplePawn;a5;White;False;False;False;False" +
      "\nSimplePawn;h3;White;False;False;False;False";
            var whiteList = whiteListString.Split('\n');
            foreach (var line in whiteList)
            {
                var datas = line.Split(';');
                var newPawn = new Pawn(datas[0], datas[1], new Button(), datas[2], mainWindow);
                //;{pawn.IsFirstMove};{pawn.IsFirstMoveKing};{pawn.IsLeftRookFirstMove};{pawn.IsRightRookFirstMove}
                newPawn.IsFirstMove = bool.Parse(datas[3]);
                newPawn.IsFirstMoveKing = bool.Parse(datas[4]);
                newPawn.IsLeftRookFirstMove = bool.Parse(datas[5]);
                newPawn.IsRightRookFirstMove = bool.Parse(datas[6]);
                pawnListWhite.Add(newPawn);
            }

            //BLACKList
            var blackListString = "" +
      "King;e8;Black;False;True;False;False" +
      "\nQueen;b4;Black;False;False;False;False" +
      "\nBishop;h1;Black;False;False;False;False" +
      "\nBishop;e7;Black;False;False;False;False" +
      "\nSimplePawn;b2;Black;False;False;False;False" +
      "\nSimplePawn;g7;Black;True;False;False;False" +
      "\nSimplePawn;g6;Black;False;False;False;False";
            var blackList = blackListString.Split('\n');
            foreach (var line in blackList)
            {
                var datas = line.Split(';');
                var newPawn = new Pawn(datas[0], datas[1], new Button(), datas[2], mainWindow);
                //;{pawn.IsFirstMove};{pawn.IsFirstMoveKing};{pawn.IsLeftRookFirstMove};{pawn.IsRightRookFirstMove}
                newPawn.IsFirstMove = bool.Parse(datas[3]);
                newPawn.IsFirstMoveKing = bool.Parse(datas[4]);
                newPawn.IsLeftRookFirstMove = bool.Parse(datas[5]);
                newPawn.IsRightRookFirstMove = bool.Parse(datas[6]);
                pawnListBlack.Add(newPawn);
            }



            var pawnList = new List<Pawn>();pawnList.AddRange(pawnListWhite);pawnList.AddRange(pawnListBlack);mainWindow.PawnList = pawnList;

            using (var chess2UtilsNotStatic = new Chess2UtilsNotStatic())
            {
                var nodeResult = mainWindow.GetBestPositionLocalNotTask(mainWindow.ComputerColore);

                Assert.AreEqual(nodeResult.BestChildPosition, "g6");
            }
        }


        [TestMethod]
        /*tsiry;27-08-2021*/
        public void MTT54CLePionNoirDoitEvoluerDoitSeMettreEnC1()
        {
            
            var mainWindow = new MainWindow(); mainWindow.SetTurnNumberLabel("5");mainWindow.ComputerColore = "Black";




            
            var pawnListWhite = new List<Pawn>();
            var pawnListBlack = new List<Pawn>();



            //WHITEList
            var whiteListString = "" +
      "King;d1;White;False;False;True;True" +
      "\nQueen;e3;White;False;False;False;False" +
      "\nRook;a1;White;False;False;False;False" +
      "\nBishop;c4;White;False;False;False;False" +
      "\nKnight;g1;White;False;False;False;False" +
      "\nSimplePawn;a5;White;False;False;False;False" +
      "\nSimplePawn;h3;White;False;False;False;False";
            var whiteList = whiteListString.Split('\n');
            foreach (var line in whiteList)
            {
                var datas = line.Split(';');
                var newPawn = new Pawn(datas[0], datas[1], new Button(), datas[2], mainWindow);
                //;{pawn.IsFirstMove};{pawn.IsFirstMoveKing};{pawn.IsLeftRookFirstMove};{pawn.IsRightRookFirstMove}
                newPawn.IsFirstMove = bool.Parse(datas[3]);
                newPawn.IsFirstMoveKing = bool.Parse(datas[4]);
                newPawn.IsLeftRookFirstMove = bool.Parse(datas[5]);
                newPawn.IsRightRookFirstMove = bool.Parse(datas[6]);
                pawnListWhite.Add(newPawn);
            }

            //BLACKList
            var blackListString = "" +
      "King;e8;Black;False;True;False;False" +
      "\nQueen;b4;Black;False;False;False;False" +
      "\nBishop;h1;Black;False;False;False;False" +
      "\nBishop;e7;Black;False;False;False;False" +
      "\nSimplePawn;b2;Black;False;False;False;False" +
      "\nSimplePawn;g7;Black;True;False;False;False" +
      "\nSimplePawn;g6;Black;False;False;False;False";
            var blackList = blackListString.Split('\n');
            foreach (var line in blackList)
            {
                var datas = line.Split(';');
                var newPawn = new Pawn(datas[0], datas[1], new Button(), datas[2], mainWindow);
                //;{pawn.IsFirstMove};{pawn.IsFirstMoveKing};{pawn.IsLeftRookFirstMove};{pawn.IsRightRookFirstMove}
                newPawn.IsFirstMove = bool.Parse(datas[3]);
                newPawn.IsFirstMoveKing = bool.Parse(datas[4]);
                newPawn.IsLeftRookFirstMove = bool.Parse(datas[5]);
                newPawn.IsRightRookFirstMove = bool.Parse(datas[6]);
                pawnListBlack.Add(newPawn);
            }



            var pawnList = new List<Pawn>();pawnList.AddRange(pawnListWhite);pawnList.AddRange(pawnListBlack);mainWindow.PawnList = pawnList;

            using (var chess2UtilsNotStatic = new Chess2UtilsNotStatic())
            {
                var nodeResult = mainWindow.GetBestPositionLocalNotTask(mainWindow.ComputerColore);

                Assert.AreEqual(nodeResult.BestChildPosition, "a1");
            }
        }


        [TestMethod]
        /*tsiry;27-08-2021*/
        public void MTT54ELePionNoirDoitEvoluerDoitSeMettreEnA1()
        {
            
            var mainWindow = new MainWindow(); mainWindow.SetTurnNumberLabel("5");mainWindow.ComputerColore = "Black";




            
            var pawnListWhite = new List<Pawn>();
            var pawnListBlack = new List<Pawn>();



            //WHITEList
            var whiteListString = "" +
      "King;e2;White;False;False;True;True" +
      "\nQueen;d3;White;False;False;False;False" +
      "\nRook;a1;White;False;False;False;False" +
      "\nKnight;g1;White;False;False;False;False" +
      "\nSimplePawn;a5;White;False;False;False;False" +
      "\nSimplePawn;h3;White;False;False;False;False";
            var whiteList = whiteListString.Split('\n');
            foreach (var line in whiteList)
            {
                var datas = line.Split(';');
                var newPawn = new Pawn(datas[0], datas[1], new Button(), datas[2], mainWindow);
                //;{pawn.IsFirstMove};{pawn.IsFirstMoveKing};{pawn.IsLeftRookFirstMove};{pawn.IsRightRookFirstMove}
                newPawn.IsFirstMove = bool.Parse(datas[3]);
                newPawn.IsFirstMoveKing = bool.Parse(datas[4]);
                newPawn.IsLeftRookFirstMove = bool.Parse(datas[5]);
                newPawn.IsRightRookFirstMove = bool.Parse(datas[6]);
                pawnListWhite.Add(newPawn);
            }

            //BLACKList
            var blackListString = "" +
      "King;e8;Black;False;True;False;False" +
      "\nQueen;b4;Black;False;False;False;False" +
      "\nBishop;h1;Black;False;False;False;False" +
      "\nBishop;e7;Black;False;False;False;False" +
      "\nSimplePawn;b2;Black;False;False;False;False" +
      "\nSimplePawn;g7;Black;True;False;False;False" +
      "\nSimplePawn;g6;Black;False;False;False;False";
            var blackList = blackListString.Split('\n');
            foreach (var line in blackList)
            {
                var datas = line.Split(';');
                var newPawn = new Pawn(datas[0], datas[1], new Button(), datas[2], mainWindow);
                //;{pawn.IsFirstMove};{pawn.IsFirstMoveKing};{pawn.IsLeftRookFirstMove};{pawn.IsRightRookFirstMove}
                newPawn.IsFirstMove = bool.Parse(datas[3]);
                newPawn.IsFirstMoveKing = bool.Parse(datas[4]);
                newPawn.IsLeftRookFirstMove = bool.Parse(datas[5]);
                newPawn.IsRightRookFirstMove = bool.Parse(datas[6]);
                pawnListBlack.Add(newPawn);
            }



            var pawnList = new List<Pawn>();pawnList.AddRange(pawnListWhite);pawnList.AddRange(pawnListBlack);mainWindow.PawnList = pawnList;

            using (var chess2UtilsNotStatic = new Chess2UtilsNotStatic())
            {
                var nodeResult = mainWindow.GetBestPositionLocalNotTask(mainWindow.ComputerColore);

                Assert.AreEqual(nodeResult.BestChildPosition, "a1");
            }
        }
        [TestMethod]
        /*tsiry;14-10-2021*/
        public void MTT54FLaReineNoirMenaverleRoiBlanchEtSeMettreEnD6()
        {
            
            var mainWindow = new MainWindow(); mainWindow.SetTurnNumberLabel("5");mainWindow.ComputerColore = "Black";




            
            var pawnListWhite = new List<Pawn>();
            var pawnListBlack = new List<Pawn>();



            //WHITEList
            var whiteListString = "" +
      "King;d1;White;False;False;True;True" +
      "\nQueen;e3;White;False;False;False;False" +
      "\nRook;a1;White;False;False;False;False" +
      "\nKnight;g1;White;False;False;False;False" +
      "\nSimplePawn;a5;White;False;False;False;False" +
      "\nSimplePawn;h3;White;False;False;False;False";
            var whiteList = whiteListString.Split('\n');
            foreach (var line in whiteList)
            {
                var datas = line.Split(';');
                var newPawn = new Pawn(datas[0], datas[1], new Button(), datas[2], mainWindow);
                //;{pawn.IsFirstMove};{pawn.IsFirstMoveKing};{pawn.IsLeftRookFirstMove};{pawn.IsRightRookFirstMove}
                newPawn.IsFirstMove = bool.Parse(datas[3]);
                newPawn.IsFirstMoveKing = bool.Parse(datas[4]);
                newPawn.IsLeftRookFirstMove = bool.Parse(datas[5]);
                newPawn.IsRightRookFirstMove = bool.Parse(datas[6]);
                pawnListWhite.Add(newPawn);
            }

            //BLACKList
            var blackListString = "" +
      "King;e8;Black;False;True;False;False" +
      "\nQueen;b4;Black;False;False;False;False" +
      "\nBishop;h1;Black;False;False;False;False" +
      "\nBishop;e7;Black;False;False;False;False" +
      "\nSimplePawn;b2;Black;False;False;False;False" +
      "\nSimplePawn;g7;Black;True;False;False;False" +
      "\nSimplePawn;g6;Black;False;False;False;False";
            var blackList = blackListString.Split('\n');
            foreach (var line in blackList)
            {
                var datas = line.Split(';');
                var newPawn = new Pawn(datas[0], datas[1], new Button(), datas[2], mainWindow);
                //;{pawn.IsFirstMove};{pawn.IsFirstMoveKing};{pawn.IsLeftRookFirstMove};{pawn.IsRightRookFirstMove}
                newPawn.IsFirstMove = bool.Parse(datas[3]);
                newPawn.IsFirstMoveKing = bool.Parse(datas[4]);
                newPawn.IsLeftRookFirstMove = bool.Parse(datas[5]);
                newPawn.IsRightRookFirstMove = bool.Parse(datas[6]);
                pawnListBlack.Add(newPawn);
            }



            var pawnList = new List<Pawn>();pawnList.AddRange(pawnListWhite);pawnList.AddRange(pawnListBlack);mainWindow.PawnList = pawnList;



            using (var chess2UtilsNotStatic = new Chess2UtilsNotStatic())
            {
                var nodeResult = mainWindow.GetBestPositionLocalNotTask(mainWindow.ComputerColore);

                var randomList = nodeResult.AsssociateNodeChess2.RandomEquivalentList;
                var isSucces = true;
                if (randomList != null)
                {
                    //  Pour  MTTester que  MTT69
                    foreach (var item in randomList)
                    {
                        if (item.ToIndex == 41)
                        {
                            isSucces = false;
                            break;
                        }
                    }
                }
                Assert.IsTrue(isSucces);




                isSucces = false;
                if (nodeResult.BestChildPosition == "d6" || nodeResult.BestChildPosition == "a1" || nodeResult.BestChildPosition == "b3")
                    isSucces = true;
                Assert.IsTrue(isSucces);
            }
        }



        [TestMethod]
        /*tsiry;27-08-2021*/
        public void MTT54DLePionNoirDoitEvoluerETSeMettreEnB1()//  MTT54DLaReinneNoirDoitSeMettreEnC4()
        {
            
            var mainWindow = new MainWindow(); mainWindow.SetTurnNumberLabel("5");mainWindow.ComputerColore = "Black";




            
            var pawnListWhite = new List<Pawn>();
            var pawnListBlack = new List<Pawn>();



            //WHITEList
            var whiteListString = "" +
      "King;e2;White;False;False;True;True" +
      "\nQueen;e3;White;False;False;False;False" +
      "\nBishop;c4;White;False;False;False;False" +
      "\nKnight;g1;White;False;False;False;False" +
      "\nSimplePawn;a5;White;False;False;False;False" +
      "\nSimplePawn;h3;White;False;False;False;False";
            var whiteList = whiteListString.Split('\n');
            foreach (var line in whiteList)
            {
                var datas = line.Split(';');
                var newPawn = new Pawn(datas[0], datas[1], new Button(), datas[2], mainWindow);
                //;{pawn.IsFirstMove};{pawn.IsFirstMoveKing};{pawn.IsLeftRookFirstMove};{pawn.IsRightRookFirstMove}
                newPawn.IsFirstMove = bool.Parse(datas[3]);
                newPawn.IsFirstMoveKing = bool.Parse(datas[4]);
                newPawn.IsLeftRookFirstMove = bool.Parse(datas[5]);
                newPawn.IsRightRookFirstMove = bool.Parse(datas[6]);
                pawnListWhite.Add(newPawn);
            }

            //BLACKList
            var blackListString = "" +
      "King;e8;Black;False;True;False;False" +
      //"\nQueen;b4;Black;False;False;False;False" +
      "\nBishop;h1;Black;False;False;False;False" +
      "\nBishop;e7;Black;False;False;False;False" +
      "\nSimplePawn;b2;Black;False;False;False;False" +
      "\nSimplePawn;g7;Black;True;False;False;False" +
      "\nSimplePawn;g6;Black;False;False;False;False";
            var blackList = blackListString.Split('\n');
            foreach (var line in blackList)
            {
                var datas = line.Split(';');
                var newPawn = new Pawn(datas[0], datas[1], new Button(), datas[2], mainWindow);
                //;{pawn.IsFirstMove};{pawn.IsFirstMoveKing};{pawn.IsLeftRookFirstMove};{pawn.IsRightRookFirstMove}
                newPawn.IsFirstMove = bool.Parse(datas[3]);
                newPawn.IsFirstMoveKing = bool.Parse(datas[4]);
                newPawn.IsLeftRookFirstMove = bool.Parse(datas[5]);
                newPawn.IsRightRookFirstMove = bool.Parse(datas[6]);
                pawnListBlack.Add(newPawn);
            }



            var pawnList = new List<Pawn>();pawnList.AddRange(pawnListWhite);pawnList.AddRange(pawnListBlack);mainWindow.PawnList = pawnList;

            using (var chess2UtilsNotStatic = new Chess2UtilsNotStatic())
            {
                var nodeResult = mainWindow.GetBestPositionLocalNotTask(mainWindow.ComputerColore);

                Assert.AreEqual(nodeResult.BestChildPosition, "b1");
            }
        }


        [TestMethod]
        /*tsiry;27-08-2021*/
        public void MTT54GLaReinneNoirDoitAttaquerEnC4()//  MTT54DLaReinneNoirDoitSeMettreEnC4()
        {
            
            var mainWindow = new MainWindow(); mainWindow.SetTurnNumberLabel("5");mainWindow.ComputerColore = "Black";





            var testName = "T54GLaReinneNoirDoitAttaquerEnC4";
            var testPath = Path.Combine(testsDirrectory, testName);
           mainWindow.LoadFromDirectorie(testPath);
            using (var chess2UtilsNotStatic = new Chess2UtilsNotStatic())
            {
                //var nodeResult = mainWindow.GetBestPositionLocalNotTask(mainWindow.ComputerColore);
                //Assert.AreEqual(nodeResult.BestChildPosition, "h1");
               // var nodeResult = mainWindow.GetBestPositionLocalNotTask(mainWindow.ComputerColore);
                var nodeResult = mainWindow.GetBestPositionLocalNotTask(mainWindow.ComputerColore);
               // Assert.AreEqual(nodeResult.BestChildPosition, "c4");
                Assert.AreEqual(nodeResult.BestChildPosition, "b1");


            }
            
               // 
            

        }

        [TestMethod]
        /*tsiry;30-08-2021*/
        public void MTT55SecificPositionLeCavalierBlanchDoitSeMettreSurG6()
        {
            
            var mainWindow = new MainWindow(); mainWindow.SetTurnNumberLabel("5");mainWindow.ComputerColore = "White";




            
            var pawnListWhite = new List<Pawn>();
            var pawnListBlack = new List<Pawn>();



            //WHITEList
            var whiteListString = "" +
      "King;e1;White;False;True;True;True" +
      "\nQueen;d1;White;False;False;False;False" +
      "\nRook;a1;White;False;False;False;False" +
      "\nRook;h1;White;False;False;False;False" +
      "\nKnight;b5;White;False;False;False;False" +
      "\nBishop;c1;White;False;False;False;False" +
      "\nBishop;c4;White;False;False;False;False" +
      "\nKnight;h4;White;False;False;False;False" +
      "\nSimplePawn;a3;White;False;False;False;False" +
      "\nSimplePawn;b2;White;True;False;False;False" +
      "\nSimplePawn;c2;White;True;False;False;False" +
      "\nSimplePawn;d4;White;False;False;False;False" +
      "\nSimplePawn;e5;White;False;False;False;False" +
      "\nSimplePawn;f2;White;True;False;False;False" +
      "\nSimplePawn;g2;White;True;False;False;False" +
      "\nSimplePawn;h2;White;True;False;False;False";
            var whiteList = whiteListString.Split('\n');
            foreach (var line in whiteList)
            {
                var datas = line.Split(';');
                var newPawn = new Pawn(datas[0], datas[1], new Button(), datas[2], mainWindow);
                //;{pawn.IsFirstMove};{pawn.IsFirstMoveKing};{pawn.IsLeftRookFirstMove};{pawn.IsRightRookFirstMove}
                newPawn.IsFirstMove = bool.Parse(datas[3]);
                newPawn.IsFirstMoveKing = bool.Parse(datas[4]);
                newPawn.IsLeftRookFirstMove = bool.Parse(datas[5]);
                newPawn.IsRightRookFirstMove = bool.Parse(datas[6]);
                pawnListWhite.Add(newPawn);
            }

            //BLACKList
            var blackListString = "" +
      "King;e7;Black;False;False;True;True" +
      "\nQueen;d8;Black;False;False;False;False" +
      "\nRook;a8;Black;False;False;False;False" +
      "\nRook;h8;Black;False;False;False;False" +
      "\nKnight;b8;Black;False;False;False;False" +
      "\nBishop;c8;Black;False;False;False;False" +
      "\nBishop;f8;Black;False;False;False;False" +
      "\nKnight;g8;Black;False;False;False;False" +
      "\nSimplePawn;a4;Black;False;False;False;False" +
      "\nSimplePawn;b6;Black;False;False;False;False" +
      "\nSimplePawn;c7;Black;True;False;False;False" +
      "\nSimplePawn;d7;Black;True;False;False;False" +
      "\nSimplePawn;e6;Black;False;False;False;False" +
      "\nSimplePawn;f5;Black;False;False;False;False" +
      "\nSimplePawn;g7;Black;True;False;False;False" +
      "\nSimplePawn;h6;Black;False;False;False;False";
            var blackList = blackListString.Split('\n');
            foreach (var line in blackList)
            {
                var datas = line.Split(';');
                var newPawn = new Pawn(datas[0], datas[1], new Button(), datas[2], mainWindow);
                //;{pawn.IsFirstMove};{pawn.IsFirstMoveKing};{pawn.IsLeftRookFirstMove};{pawn.IsRightRookFirstMove}
                newPawn.IsFirstMove = bool.Parse(datas[3]);
                newPawn.IsFirstMoveKing = bool.Parse(datas[4]);
                newPawn.IsLeftRookFirstMove = bool.Parse(datas[5]);
                newPawn.IsRightRookFirstMove = bool.Parse(datas[6]);
                pawnListBlack.Add(newPawn);
            }



            var pawnList = new List<Pawn>();pawnList.AddRange(pawnListWhite);pawnList.AddRange(pawnListBlack);mainWindow.PawnList = pawnList;
            using (var chess2UtilsNotStatic = new Chess2UtilsNotStatic())
            {
                var nodeResult = mainWindow.GetBestPositionLocalNotTask(mainWindow.ComputerColore);


                Assert.AreEqual(nodeResult.BestChildPosition, "g6");
            }
        }


        [TestMethod]
        /*tsiry;30-08-2021*/
        public void MTT56ToNotSecificPositionMesNoirDoiventEmpecherLeCavalierBlanchDeSeMettreSurG6()
        {
            
            var mainWindow = new MainWindow(); mainWindow.SetTurnNumberLabel("5");mainWindow.ComputerColore = "Black";




            
            var pawnListWhite = new List<Pawn>();
            var pawnListBlack = new List<Pawn>();



            //WHITEList
            var whiteListString = "" +
      "King;e1;White;False;True;True;True" +
      "\nQueen;d1;White;False;False;False;False" +
      "\nRook;a1;White;False;False;False;False" +
      "\nRook;h1;White;False;False;False;False" +
      "\nKnight;b5;White;False;False;False;False" +
      "\nBishop;c1;White;False;False;False;False" +
      "\nBishop;c4;White;False;False;False;False" +
      "\nKnight;h4;White;False;False;False;False" +
      "\nSimplePawn;a3;White;False;False;False;False" +
      "\nSimplePawn;b2;White;True;False;False;False" +
      "\nSimplePawn;c2;White;True;False;False;False" +
      "\nSimplePawn;d4;White;False;False;False;False" +
      "\nSimplePawn;e5;White;False;False;False;False" +
      "\nSimplePawn;f2;White;True;False;False;False" +
      "\nSimplePawn;g2;White;True;False;False;False" +
      "\nSimplePawn;h2;White;True;False;False;False";
            var whiteList = whiteListString.Split('\n');
            foreach (var line in whiteList)
            {
                var datas = line.Split(';');
                var newPawn = new Pawn(datas[0], datas[1], new Button(), datas[2], mainWindow);
                //;{pawn.IsFirstMove};{pawn.IsFirstMoveKing};{pawn.IsLeftRookFirstMove};{pawn.IsRightRookFirstMove}
                newPawn.IsFirstMove = bool.Parse(datas[3]);
                newPawn.IsFirstMoveKing = bool.Parse(datas[4]);
                newPawn.IsLeftRookFirstMove = bool.Parse(datas[5]);
                newPawn.IsRightRookFirstMove = bool.Parse(datas[6]);
                pawnListWhite.Add(newPawn);
            }

            //BLACKList
            var blackListString = "" +
      "King;e7;Black;False;False;True;True" +
      "\nQueen;d8;Black;False;False;False;False" +
      "\nRook;a8;Black;False;False;False;False" +
      "\nRook;h8;Black;False;False;False;False" +
      "\nKnight;b8;Black;False;False;False;False" +
      "\nBishop;c8;Black;False;False;False;False" +
      "\nBishop;f8;Black;False;False;False;False" +
      "\nKnight;g8;Black;False;False;False;False" +
      "\nSimplePawn;a4;Black;False;False;False;False" +
      "\nSimplePawn;b6;Black;False;False;False;False" +
      "\nSimplePawn;c7;Black;True;False;False;False" +
      "\nSimplePawn;d7;Black;True;False;False;False" +
      "\nSimplePawn;e6;Black;False;False;False;False" +
      "\nSimplePawn;f5;Black;False;False;False;False" +
      "\nSimplePawn;g7;Black;True;False;False;False" +
      "\nSimplePawn;h6;Black;False;False;False;False";
            var blackList = blackListString.Split('\n');
            foreach (var line in blackList)
            {
                var datas = line.Split(';');
                var newPawn = new Pawn(datas[0], datas[1], new Button(), datas[2], mainWindow);
                //;{pawn.IsFirstMove};{pawn.IsFirstMoveKing};{pawn.IsLeftRookFirstMove};{pawn.IsRightRookFirstMove}
                newPawn.IsFirstMove = bool.Parse(datas[3]);
                newPawn.IsFirstMoveKing = bool.Parse(datas[4]);
                newPawn.IsLeftRookFirstMove = bool.Parse(datas[5]);
                newPawn.IsRightRookFirstMove = bool.Parse(datas[6]);
                pawnListBlack.Add(newPawn);
            }



            var pawnList = new List<Pawn>();pawnList.AddRange(pawnListWhite);pawnList.AddRange(pawnListBlack);mainWindow.PawnList = pawnList;

            using (var chess2UtilsNotStatic = new Chess2UtilsNotStatic())
            {
                var nodeResult = mainWindow.GetBestPositionLocalNotTask(mainWindow.ComputerColore);

                Assert.AreNotEqual(nodeResult.BestChildPosition, "c6");
                Assert.AreNotEqual(nodeResult.BestChildPosition, "b7");
            }
        }

        [TestMethod]
        /*tsiry;30-08-2021*/
        public void MTT57SeulLeRookDoitBougerNotRandomD5()
        {
            

            var mainWindow = new MainWindow(); mainWindow.SetTurnNumberLabel("5");mainWindow.ComputerColore = "Black";




            
            var pawnListWhite = new List<Pawn>();
            var pawnListBlack = new List<Pawn>();



            //WHITEList
            var whiteListString = "" +
      "King;f1;White;False;False;True;False" +
      "\nQueen;f3;White;False;False;False;False" +
      "\nRook;a1;White;False;False;False;False" +
      "\nRook;g1;White;False;False;False;False" +
      "\nKnight;b1;White;False;False;False;False" +
      "\nBishop;c1;White;False;False;False;False" +
      "\nKnight;f4;White;False;False;False;False" +
      "\nSimplePawn;a2;White;True;False;False;False" +
      "\nSimplePawn;b2;White;True;False;False;False" +
      "\nSimplePawn;c2;White;True;False;False;False" +
      "\nSimplePawn;d3;White;False;False;False;False" +
      "\nSimplePawn;g3;White;False;False;False;False" +
      "\nSimplePawn;h2;White;True;False;False;False";
            var whiteList = whiteListString.Split('\n');
            foreach (var line in whiteList)
            {
                var datas = line.Split(';');
                var newPawn = new Pawn(datas[0], datas[1], new Button(), datas[2], mainWindow);
                //;{pawn.IsFirstMove};{pawn.IsFirstMoveKing};{pawn.IsLeftRookFirstMove};{pawn.IsRightRookFirstMove}
                newPawn.IsFirstMove = bool.Parse(datas[3]);
                newPawn.IsFirstMoveKing = bool.Parse(datas[4]);
                newPawn.IsLeftRookFirstMove = bool.Parse(datas[5]);
                newPawn.IsRightRookFirstMove = bool.Parse(datas[6]);
                pawnListWhite.Add(newPawn);
            }

            //BLACKList
            var blackListString = "" +
      "King;e8;Black;False;True;True;True" +
      "\nQueen;f6;Black;False;False;False;False" +
      "\nRook;a8;Black;False;False;False;False" +
      "\nRook;h8;Black;False;False;False;False" +
      "\nKnight;b8;Black;False;False;False;False" +
      "\nBishop;c8;Black;False;False;False;False" +
      "\nBishop;g7;Black;False;False;False;False" +
      "\nKnight;g8;Black;False;False;False;False" +
      "\nSimplePawn;a5;Black;False;False;False;False" +
      "\nSimplePawn;b5;Black;False;False;False;False" +
      "\nSimplePawn;c5;Black;False;False;False;False" +
      "\nSimplePawn;d6;Black;False;False;False;False" +
      "\nSimplePawn;e5;Black;False;False;False;False" +
      "\nSimplePawn;g6;Black;False;False;False;False" +
      "\nSimplePawn;h6;Black;False;False;False;False";
            var blackList = blackListString.Split('\n');
            foreach (var line in blackList)
            {
                var datas = line.Split(';');
                var newPawn = new Pawn(datas[0], datas[1], new Button(), datas[2], mainWindow);
                //;{pawn.IsFirstMove};{pawn.IsFirstMoveKing};{pawn.IsLeftRookFirstMove};{pawn.IsRightRookFirstMove}
                newPawn.IsFirstMove = bool.Parse(datas[3]);
                newPawn.IsFirstMoveKing = bool.Parse(datas[4]);
                newPawn.IsLeftRookFirstMove = bool.Parse(datas[5]);
                newPawn.IsRightRookFirstMove = bool.Parse(datas[6]);
                pawnListBlack.Add(newPawn);
            }



            var pawnList = new List<Pawn>();pawnList.AddRange(pawnListWhite);pawnList.AddRange(pawnListBlack);mainWindow.PawnList = pawnList;
            using (var chess2UtilsNotStatic = new Chess2UtilsNotStatic())
            {
                var nodeResult = mainWindow.GetBestPositionLocalNotTask(mainWindow.ComputerColore);
                //Assert.AreNotEqual(nodeResult.BestChildPosition, "g5");



                // var result = nodeResult.NodeRandomList.FirstOrDefault(x => x.BestChildPosition == "d5");
                // Assert.IsNull(result);
                Assert.AreNotEqual(nodeResult.BestChildPosition, "d5");
            }
        }


        /*tsiry;06-10-2021*/
        [TestMethod]
        public void MTT59FinDePartieEviterMortDuRoiNoir()
        {
            

            var mainWindow = new MainWindow(); mainWindow.SetTurnNumberLabel("5");mainWindow.ComputerColore = "Black";




            
            var pawnListWhite = new List<Pawn>();
            var pawnListBlack = new List<Pawn>();



            //WHITEList
            var whiteListString = "" +
      "King;b1;White;False;False;False;False" +
      "\nRook;a7;White;False;False;False;False" +
      "\nSimplePawn;b2;White;True;False;False;False" +
      "\nSimplePawn;c2;White;True;False;False;False" +
      "\nSimplePawn;d5;White;False;False;False;False";

            ;
            var whiteList = whiteListString.Split('\n');
            foreach (var line in whiteList)
            {
                var datas = line.Split(';');
                var newPawn = new Pawn(datas[0], datas[1], new Button(), datas[2], mainWindow);
                //;{pawn.IsFirstMove};{pawn.IsFirstMoveKing};{pawn.IsLeftRookFirstMove};{pawn.IsRightRookFirstMove}
                newPawn.IsFirstMove = bool.Parse(datas[3]);
                newPawn.IsFirstMoveKing = bool.Parse(datas[4]);
                newPawn.IsLeftRookFirstMove = bool.Parse(datas[5]);
                newPawn.IsRightRookFirstMove = bool.Parse(datas[6]);
                pawnListWhite.Add(newPawn);
            }

            //BLACKList
            var blackListString = "" +
      "King;c7;Black;False;False;False;False" +
      "\nRook;g2;Black;False;False;False;False" +
      "\nBishop;h2;Black;False;False;False;False" +
      "\nSimplePawn;b6;Black;False;False;False;False";
            var blackList = blackListString.Split('\n');
            foreach (var line in blackList)
            {
                var datas = line.Split(';');
                var newPawn = new Pawn(datas[0], datas[1], new Button(), datas[2], mainWindow);
                //;{pawn.IsFirstMove};{pawn.IsFirstMoveKing};{pawn.IsLeftRookFirstMove};{pawn.IsRightRookFirstMove}
                newPawn.IsFirstMove = bool.Parse(datas[3]);
                newPawn.IsFirstMoveKing = bool.Parse(datas[4]);
                newPawn.IsLeftRookFirstMove = bool.Parse(datas[5]);
                newPawn.IsRightRookFirstMove = bool.Parse(datas[6]);
                pawnListBlack.Add(newPawn);
            }



            var pawnList = new List<Pawn>();pawnList.AddRange(pawnListWhite);pawnList.AddRange(pawnListBlack);mainWindow.PawnList = pawnList;
            using (var chess2UtilsNotStatic = new Chess2UtilsNotStatic())
            {
                var nodeResult = mainWindow.GetBestPositionLocalNotTask(mainWindow.ComputerColore);
                var randomList = nodeResult.AsssociateNodeChess2.RandomEquivalentList;
                var isSuccess = true;
                if (randomList != null)
                {
                    //  Pour  MTTester que  MTT59
                    foreach (var item in randomList)
                    {
                        if (item.ToIndex == 62)
                        {
                            isSuccess = false;
                            break;
                        }
                    }
                }
                Assert.IsTrue(isSuccess);
                Assert.AreNotEqual(nodeResult.BestChildPosition, "g1");
            }
        }


        [TestMethod]
        public void MTT61aPourBestSpecificPosition3White()
        {
            //Pour les SpecificPositions il faut se connecter � la base
            

            //Pour les SpecificPositions il faut se connecter � la base
            //mainWindow.SetIsConnectedDB(true);
            var mainWindow = new MainWindow(); mainWindow.SetTurnNumberLabel("5");mainWindow.ComputerColore = "White";
            var testName = "T61aPourBestSpecificPosition3White";
            var testPath = Path.Combine(testsDirrectory, testName);
             mainWindow.LoadFromDirectorie(testPath);
            using (var chess2UtilsNotStatic = new Chess2UtilsNotStatic())
            {
                var nodeResult = mainWindow.GetBestPositionLocalNotTask(mainWindow.ComputerColore);

                //var randomList = nodeResult.AsssociateNodeChess2.RandomEquivalentList;
                //Assert.IsNull(randomList);
                //echec si nodeResult.Location ==  nodeResult.BestChildPosition
                Assert.AreEqual(nodeResult.BestChildPosition, "e6");

            }

        }

        /*tsiry;12-10-2021*/
        [TestMethod]
        public void MTT60leRoisNoirDoitEvierDeMourirDoitSeDeplacerEnF8()
        {
            //Pour les SpecificPositions il faut se connecter � la base
            
            var mainWindow = new MainWindow(); mainWindow.SetTurnNumberLabel("5");mainWindow.ComputerColore = "Black";

            var testName = "T60leRoisNoirDoitEvierDeMourirDoitSeDeplacerEnF8";
            var testPath = Path.Combine(testsDirrectory, testName);
             mainWindow.LoadFromDirectorie(testPath);

            using (var chess2UtilsNotStatic = new Chess2UtilsNotStatic())
            {
                var nodeResult = mainWindow.GetBestPositionLocalNotTask(mainWindow.ComputerColore);

                //var randomList = nodeResult.AsssociateNodeChess2.RandomEquivalentList;
                //Assert.IsNull(randomList);
                //echec si nodeResult.Location ==  nodeResult.BestChildPosition
                Assert.AreEqual(nodeResult.BestChildPosition, "f8");
            }




        }

    /*tsiry;05-07-2022*/
    [TestMethod]
    public void MTT60Suite1BlackIsInChessWhiteToF7()
    {
      //la reine blanche doit se mettre en f7
      var mainWindow = new MainWindow(); mainWindow.SetTurnNumberLabel("5"); mainWindow.ComputerColore = "White";

      var testName = "T60Suite1BlackIsInChessWhiteToF7";
      var testPath = Path.Combine(testsDirrectory, testName);
      mainWindow.LoadFromDirectorie(testPath);

      using (var chess2UtilsNotStatic = new Chess2UtilsNotStatic())
      {
        var nodeResult = mainWindow.GetBestPositionLocalNotTask(mainWindow.ComputerColore);

        Assert.AreEqual("e6", nodeResult.Location);
        Assert.AreEqual("f7", nodeResult.BestChildPosition);
      }




    }

    /*tsiry;12-10-2021*/
    [TestMethod]
        public void MTT61PourEviterBestSpecificPosition3White()
        {
            

            var mainWindow = new MainWindow(); mainWindow.SetTurnNumberLabel("5");mainWindow.ComputerColore = "Black";




            
            var pawnListWhite = new List<Pawn>();
            var pawnListBlack = new List<Pawn>();



            //WHITEList
            var whiteListString = "" +
      "King;g1;White;False;True;True;True" +
      "\nQueen;g4;White;False;False;False;False" +
      "\nRook;a1;White;False;False;False;False" +
      "\nRook;f1;White;False;False;False;False" +
      "\nKnight;b1;White;False;False;False;False" +
      "\nBishop;d2;White;False;False;False;False" +
      "\nKnight;g5;White;False;False;False;False" +
      "\nSimplePawn;a2;White;True;False;False;False" +
      "\nSimplePawn;b2;White;True;False;False;False" +
      "\nSimplePawn;c2;White;True;False;False;False" +
      "\nSimplePawn;d3;White;False;False;False;False" +
      "\nSimplePawn;e4;White;False;False;False;False" +
      "\nSimplePawn;f2;White;True;False;False;False" +
      "\nSimplePawn;g2;White;True;False;False;False" +
      "\nSimplePawn;h2;White;True;False;False;False";

            ;
            var whiteList = whiteListString.Split('\n');
            foreach (var line in whiteList)
            {
                var datas = line.Split(';');
                var newPawn = new Pawn(datas[0], datas[1], new Button(), datas[2], mainWindow);
                //;{pawn.IsFirstMove};{pawn.IsFirstMoveKing};{pawn.IsLeftRookFirstMove};{pawn.IsRightRookFirstMove}
                newPawn.IsFirstMove = bool.Parse(datas[3]);
                newPawn.IsFirstMoveKing = bool.Parse(datas[4]);
                newPawn.IsLeftRookFirstMove = bool.Parse(datas[5]);
                newPawn.IsRightRookFirstMove = bool.Parse(datas[6]);
                pawnListWhite.Add(newPawn);
            }

            //BLACKList
            var blackListString = "" +
      "King;e7;Black;False;False;True;False" +
      "\nQueen;d8;Black;False;False;False;False" +
      "\nRook;a8;Black;False;False;False;False" +
      "\nRook;h8;Black;False;False;False;False" +
      "\nKnight;b8;Black;False;False;False;False" +
      "\nBishop;f8;Black;False;False;False;False" +
      "\nKnight;f7;Black;False;False;False;False" +
      "\nSimplePawn;a7;Black;True;False;False;False" +
      "\nSimplePawn;b7;Black;True;False;False;False" +
      "\nSimplePawn;c6;Black;False;False;False;False" +
      "\nSimplePawn;d6;Black;False;False;False;False" +
      "\nSimplePawn;e5;Black;False;False;False;False" +
      "\nSimplePawn;g6;Black;False;False;False;False" +
      "\nSimplePawn;h7;Black;True;False;False;False";
            var blackList = blackListString.Split('\n');
            foreach (var line in blackList)
            {
                var datas = line.Split(';');
                var newPawn = new Pawn(datas[0], datas[1], new Button(), datas[2], mainWindow);
                //;{pawn.IsFirstMove};{pawn.IsFirstMoveKing};{pawn.IsLeftRookFirstMove};{pawn.IsRightRookFirstMove}
                newPawn.IsFirstMove = bool.Parse(datas[3]);
                newPawn.IsFirstMoveKing = bool.Parse(datas[4]);
                newPawn.IsLeftRookFirstMove = bool.Parse(datas[5]);
                newPawn.IsRightRookFirstMove = bool.Parse(datas[6]);
                pawnListBlack.Add(newPawn);
            }



            var pawnList = new List<Pawn>();pawnList.AddRange(pawnListWhite);pawnList.AddRange(pawnListBlack);mainWindow.PawnList = pawnList;
            using (var chess2UtilsNotStatic = new Chess2UtilsNotStatic())
            {
                var nodeResult = mainWindow.GetBestPositionLocalNotTask(mainWindow.ComputerColore);
                Assert.AreNotEqual(nodeResult.BestChildPosition, "g7");
            }
        }

        /*tsiry;12-10-2021*/
        [TestMethod]
        public void MTT62LePionNoirDoitAttaqueLaReineBlancEnH5()
        {
            

            var mainWindow = new MainWindow(); mainWindow.SetTurnNumberLabel("5");mainWindow.ComputerColore = "Black";
            var testName = "T62LePionNoirDoitAttaqueLaReineBlancEnH5";
            var testPath = Path.Combine(testsDirrectory, testName);
           mainWindow.LoadFromDirectorie(testPath);
            using (var chess2UtilsNotStatic = new Chess2UtilsNotStatic())
            {
                var nodeResult = mainWindow.GetBestPositionLocalNotTask(mainWindow.ComputerColore);

                Assert.AreEqual(nodeResult.BestChildPosition, "h5");
            }
            // var result = nodeResult.NodeRandomList.FirstOrDefault(x => x.BestChildPosition == "d5");
            // Assert.IsNull(result);
            
            
        }


        /*tsiry;14-10-2021*/
        [TestMethod]
        public void MTT65LeRookBlanchNeDoitPasSeMettreEnA6()
        {
            

            var mainWindow = new MainWindow(); mainWindow.SetTurnNumberLabel("5");mainWindow.ComputerColore = "White";

            var testName = "T65LeRookBlanchNeDoitPasSeMettreEnA6";
            var testPath = Path.Combine(testsDirrectory, testName);
           mainWindow.LoadFromDirectorie(testPath);
            using (var chess2UtilsNotStatic = new Chess2UtilsNotStatic())
            {
                var nodeResult = mainWindow.GetBestPositionLocalNotTask(mainWindow.ComputerColore);
                Assert.AreNotEqual(nodeResult.BestChildPosition, "a6");

            }
            
            
        }
    /*tsiry;05-07-2022*/
    [TestMethod]
    public void MTT67SuiteLaReineNoirDoitSeMettreEnE2()
    {



      var mainWindow = new MainWindow(); mainWindow.SetTurnNumberLabel("5"); mainWindow.ComputerColore = "Black";


      var testName = "T67SuiteLaReineNoirDoitSeMettreEnE2";
      var testPath = Path.Combine(testsDirrectory, testName);
      mainWindow.LoadFromDirectorie(testPath);
      using (var chess2UtilsNotStatic = new Chess2UtilsNotStatic())
      {
        var nodeResult = mainWindow.GetBestPositionLocalNotTask(mainWindow.ComputerColore);
        Assert.AreEqual("h2", nodeResult.Location);
        Assert.AreEqual("e2", nodeResult.BestChildPosition);
      }
    }


    /*tsiry;18-10-2021*/
    [TestMethod]
        public void MTT67EchecBlancLeRoiBlanchDoitBougerPourNePasPerdre()
        {
            

            var mainWindow = new MainWindow(); mainWindow.SetTurnNumberLabel("5");mainWindow.ComputerColore = "White";


      var testName = "T67EchecBlancLaReineDoitProtegerLeRoiEtSeMettreEnF3";
      var testPath = Path.Combine(testsDirrectory, testName);
      mainWindow.LoadFromDirectorie(testPath);
      using (var chess2UtilsNotStatic = new Chess2UtilsNotStatic())
      {
        var nodeResult = mainWindow.GetBestPositionLocalNotTask(mainWindow.ComputerColore);
        Assert.AreEqual("f3", nodeResult.BestChildPosition);
      }
    }
  

        /*tsiry;19-10-2021*/
        [TestMethod]
        public void MTT68LeRoiBlanchNeDoitPasSeMettreEnG6()
        {
            

            var mainWindow = new MainWindow(); mainWindow.SetTurnNumberLabel("5");mainWindow.ComputerColore = "White";




            
            var pawnListWhite = new List<Pawn>();
            var pawnListBlack = new List<Pawn>();



            //WHITEList
            var whiteListString = "" +
      "King;f5;White;False;False;False;True" +
      "\nRook;c5;White;False;False;False;False" +
      "\nRook;h1;White;False;False;False;False" +
      "\nBishop;b2;White;False;False;False;False" +
      "\nBishop;f1;White;False;False;False;False" +
      "\nKnight;g1;White;False;False;False;False" +
      "\nSimplePawn;e2;White;True;False;False;False" +
      "\nSimplePawn;g2;White;True;False;False;False" +
      "\nSimplePawn;h5;White;False;False;False;False";

            ;
            var whiteList = whiteListString.Split('\n');
            foreach (var line in whiteList)
            {
                var datas = line.Split(';');
                var newPawn = new Pawn(datas[0], datas[1], new Button(), datas[2], mainWindow);
                //;{pawn.IsFirstMove};{pawn.IsFirstMoveKing};{pawn.IsLeftRookFirstMove};{pawn.IsRightRookFirstMove}
                newPawn.IsFirstMove = bool.Parse(datas[3]);
                newPawn.IsFirstMoveKing = bool.Parse(datas[4]);
                newPawn.IsLeftRookFirstMove = bool.Parse(datas[5]);
                newPawn.IsRightRookFirstMove = bool.Parse(datas[6]);
                pawnListWhite.Add(newPawn);
            }

            //BLACKList
            var blackListString = "" +
      "King;h7;Black;False;False;False;True" +
      "\nRook;e3;Black;False;False;False;False" +
      "\nRook;h8;Black;False;False;False;False" +
      "\nKnight;a2;Black;False;False;False;False" +
      "\nSimplePawn;a7;Black;True;False;False;False" +
      "\nSimplePawn;c7;Black;True;False;False;False" +
      "\nSimplePawn;g7;Black;True;False;False;False" +
      "\nSimplePawn;h6;Black;False;False;False;False";
            var blackList = blackListString.Split('\n');
            foreach (var line in blackList)
            {
                var datas = line.Split(';');
                var newPawn = new Pawn(datas[0], datas[1], new Button(), datas[2], mainWindow);
                //;{pawn.IsFirstMove};{pawn.IsFirstMoveKing};{pawn.IsLeftRookFirstMove};{pawn.IsRightRookFirstMove}
                newPawn.IsFirstMove = bool.Parse(datas[3]);
                newPawn.IsFirstMoveKing = bool.Parse(datas[4]);
                newPawn.IsLeftRookFirstMove = bool.Parse(datas[5]);
                newPawn.IsRightRookFirstMove = bool.Parse(datas[6]);
                pawnListBlack.Add(newPawn);
            }



            var pawnList = new List<Pawn>();pawnList.AddRange(pawnListWhite);pawnList.AddRange(pawnListBlack);mainWindow.PawnList = pawnList;
            using (var chess2UtilsNotStatic = new Chess2UtilsNotStatic())
            {
                var nodeResult = mainWindow.GetBestPositionLocalNotTask(mainWindow.ComputerColore);
                Assert.AreNotEqual(nodeResult.BestChildPosition, "g6");
            }
        }


        /*tsiry;21-10-2021*/
        [TestMethod]
        public void MTT69LeRoiBanchNeDoitPasPrendreLePionEnG2()
        {
            

            var mainWindow = new MainWindow(); mainWindow.SetTurnNumberLabel("5");mainWindow.ComputerColore = "White";




            
            var pawnListWhite = new List<Pawn>();
            var pawnListBlack = new List<Pawn>();



            //WHITEList
            var whiteListString = "" +
      "King;f2;White;False;False;False;True" +
      "\nRook;a1;White;False;False;False;False" +
      "\nKnight;e2;White;False;False;False;False";

            ;
            var whiteList = whiteListString.Split('\n');
            foreach (var line in whiteList)
            {
                var datas = line.Split(';');
                var newPawn = new Pawn(datas[0], datas[1], new Button(), datas[2], mainWindow);
                //;{pawn.IsFirstMove};{pawn.IsFirstMoveKing};{pawn.IsLeftRookFirstMove};{pawn.IsRightRookFirstMove}
                newPawn.IsFirstMove = bool.Parse(datas[3]);
                newPawn.IsFirstMoveKing = bool.Parse(datas[4]);
                newPawn.IsLeftRookFirstMove = bool.Parse(datas[5]);
                newPawn.IsRightRookFirstMove = bool.Parse(datas[6]);
                pawnListWhite.Add(newPawn);
            }

            //BLACKList
            var blackListString = "" +
      "King;h2;Black;False;False;False;False" +
      "\nBishop;d5;Black;False;False;False;False" +
      "\nSimplePawn;a2;Black;False;False;False;False" +
      "\nSimplePawn;g2;Black;False;False;False;False";
            var blackList = blackListString.Split('\n');
            foreach (var line in blackList)
            {
                var datas = line.Split(';');
                var newPawn = new Pawn(datas[0], datas[1], new Button(), datas[2], mainWindow);
                //;{pawn.IsFirstMove};{pawn.IsFirstMoveKing};{pawn.IsLeftRookFirstMove};{pawn.IsRightRookFirstMove}
                newPawn.IsFirstMove = bool.Parse(datas[3]);
                newPawn.IsFirstMoveKing = bool.Parse(datas[4]);
                newPawn.IsLeftRookFirstMove = bool.Parse(datas[5]);
                newPawn.IsRightRookFirstMove = bool.Parse(datas[6]);
                pawnListBlack.Add(newPawn);
            }



            var pawnList = new List<Pawn>();pawnList.AddRange(pawnListWhite);pawnList.AddRange(pawnListBlack);mainWindow.PawnList = pawnList;
            using (var chess2UtilsNotStatic = new Chess2UtilsNotStatic())
            {
                var nodeResult = mainWindow.GetBestPositionLocalNotTask(mainWindow.ComputerColore);

                var randomList = nodeResult.AsssociateNodeChess2.RandomEquivalentList;
                var isSuccess = true;
                if (randomList != null)
                {
                    //  Pour  MTTester que  MTT69
                    foreach (var item in randomList)
                    {
                        if (item.ToIndex == 54)
                        {
                            isSuccess = false;
                            break;
                        }
                    }
                }
                Assert.IsTrue(isSuccess);

                Assert.AreNotEqual(nodeResult.BestChildPosition, "g2");
            }
        }





        /*tsiry;25-10-2021*/
        [TestMethod]
        public void MTT71LeRoisBlantNeDoitPasPrendreLeRookEnF5()
        {
            

            var mainWindow = new MainWindow(); mainWindow.SetTurnNumberLabel("5");mainWindow.ComputerColore = "White";




            
            var pawnListWhite = new List<Pawn>();
            var pawnListBlack = new List<Pawn>();



            //WHITEList
            var whiteListString = "" +
      "King;e4;White;False;True;True;True" +
      "\nRook;a1;White;False;False;False;False" +
      "\nRook;h1;White;False;False;False;False" +
      "\nBishop;d3;White;False;False;False;False" +
      "\nKnight;g4;White;False;False;False;False" +
      "\nSimplePawn;b4;White;True;False;False;False" +
      "\nSimplePawn;b3;White;True;False;False;False" +
      "\nSimplePawn;c4;White;True;False;False;False" +
      "\nSimplePawn;g2;White;True;False;False;False" +
      "\nSimplePawn;h4;White;True;False;False;False";

            ;
            var whiteList = whiteListString.Split('\n');
            foreach (var line in whiteList)
            {
                var datas = line.Split(';');
                var newPawn = new Pawn(datas[0], datas[1], new Button(), datas[2], mainWindow);
                //;{pawn.IsFirstMove};{pawn.IsFirstMoveKing};{pawn.IsLeftRookFirstMove};{pawn.IsRightRookFirstMove}
                newPawn.IsFirstMove = bool.Parse(datas[3]);
                newPawn.IsFirstMoveKing = bool.Parse(datas[4]);
                newPawn.IsLeftRookFirstMove = bool.Parse(datas[5]);
                newPawn.IsRightRookFirstMove = bool.Parse(datas[6]);
                pawnListWhite.Add(newPawn);
            }

            //BLACKList
            var blackListString = "" +
      "King;e6;Black;False;True;True;True" +
      "\nRook;d8;Black;False;False;False;False" +
      "\nRook;f5;Black;False;False;False;False" +
      "\nSimplePawn;a2;Black;True;False;False;False" +
      "\nSimplePawn;b6;Black;True;False;False;False" +
      "\nSimplePawn;c5;Black;True;False;False;False" +
      "\nSimplePawn;f7;Black;True;False;False;False" +
      "\nSimplePawn;h7;Black;True;False;False;False";
            var blackList = blackListString.Split('\n');
            foreach (var line in blackList)
            {
                var datas = line.Split(';');
                var newPawn = new Pawn(datas[0], datas[1], new Button(), datas[2], mainWindow);
                //;{pawn.IsFirstMove};{pawn.IsFirstMoveKing};{pawn.IsLeftRookFirstMove};{pawn.IsRightRookFirstMove}
                newPawn.IsFirstMove = bool.Parse(datas[3]);
                newPawn.IsFirstMoveKing = bool.Parse(datas[4]);
                newPawn.IsLeftRookFirstMove = bool.Parse(datas[5]);
                newPawn.IsRightRookFirstMove = bool.Parse(datas[6]);
                pawnListBlack.Add(newPawn);
            }



            var pawnList = new List<Pawn>();pawnList.AddRange(pawnListWhite);pawnList.AddRange(pawnListBlack);mainWindow.PawnList = pawnList;
            using (var chess2UtilsNotStatic = new Chess2UtilsNotStatic())
            {
                var nodeResult = mainWindow.GetBestPositionLocalNotTask(mainWindow.ComputerColore);


                Assert.AreNotEqual(nodeResult.BestChildPosition, "f5");
            }
        }

        /*tsiry;25-10-2021*/
        [TestMethod]
        public void MTT72LaReineNoirDoitPrendreLePionEnD5()
        {
            

            var mainWindow = new MainWindow(); mainWindow.SetTurnNumberLabel("5");mainWindow.ComputerColore = "Black";




            
            var pawnListWhite = new List<Pawn>();
            var pawnListBlack = new List<Pawn>();



            //WHITEList
            var whiteListString = "" +
      "King;e1;White;False;True;True;True" +
      "\nQueen;d1;White;False;False;False;False" +
      "\nRook;a1;White;False;False;False;False" +
      "\nRook;h1;White;False;False;False;False" +
      "\nKnight;b1;White;False;False;False;False" +
      "\nBishop;c1;White;False;False;False;False" +
      "\nBishop;f1;White;False;False;False;False" +
      "\nKnight;g1;White;False;False;False;False" +
      "\nSimplePawn;a2;White;True;False;False;False" +
      "\nSimplePawn;b2;White;True;False;False;False" +
      "\nSimplePawn;c2;White;True;False;False;False" +
      "\nSimplePawn;d2;White;True;False;False;False" +
      "\nSimplePawn;d5;White;True;False;False;False" +
      "\nSimplePawn;f2;White;True;False;False;False" +
      "\nSimplePawn;g2;White;True;False;False;False" +
      "\nSimplePawn;h2;White;True;False;False;False";

            ;
            var whiteList = whiteListString.Split('\n');
            foreach (var line in whiteList)
            {
                var datas = line.Split(';');
                var newPawn = new Pawn(datas[0], datas[1], new Button(), datas[2], mainWindow);
                //;{pawn.IsFirstMove};{pawn.IsFirstMoveKing};{pawn.IsLeftRookFirstMove};{pawn.IsRightRookFirstMove}
                newPawn.IsFirstMove = bool.Parse(datas[3]);
                newPawn.IsFirstMoveKing = bool.Parse(datas[4]);
                newPawn.IsLeftRookFirstMove = bool.Parse(datas[5]);
                newPawn.IsRightRookFirstMove = bool.Parse(datas[6]);
                pawnListWhite.Add(newPawn);
            }

            //BLACKList
            var blackListString = "" +
      "King;e8;Black;False;True;True;True" +
      "\nQueen;d8;Black;False;False;False;False" +
      "\nRook;a8;Black;False;False;False;False" +
      "\nRook;h8;Black;False;False;False;False" +
      "\nKnight;b8;Black;False;False;False;False" +
      "\nBishop;c8;Black;False;False;False;False" +
      "\nBishop;f8;Black;False;False;False;False" +
      "\nKnight;g8;Black;False;False;False;False" +
      "\nSimplePawn;a7;Black;True;False;False;False" +
      "\nSimplePawn;b7;Black;True;False;False;False" +
      "\nSimplePawn;c7;Black;True;False;False;False" +
      "\nSimplePawn;e7;Black;True;False;False;False" +
      "\nSimplePawn;f7;Black;True;False;False;False" +
      "\nSimplePawn;g7;Black;True;False;False;False" +
      "\nSimplePawn;h7;Black;True;False;False;False";
            var blackList = blackListString.Split('\n');
            foreach (var line in blackList)
            {
                var datas = line.Split(';');
                var newPawn = new Pawn(datas[0], datas[1], new Button(), datas[2], mainWindow);
                //;{pawn.IsFirstMove};{pawn.IsFirstMoveKing};{pawn.IsLeftRookFirstMove};{pawn.IsRightRookFirstMove}
                newPawn.IsFirstMove = bool.Parse(datas[3]);
                newPawn.IsFirstMoveKing = bool.Parse(datas[4]);
                newPawn.IsLeftRookFirstMove = bool.Parse(datas[5]);
                newPawn.IsRightRookFirstMove = bool.Parse(datas[6]);
                pawnListBlack.Add(newPawn);
            }



            var pawnList = new List<Pawn>();pawnList.AddRange(pawnListWhite);pawnList.AddRange(pawnListBlack);mainWindow.PawnList = pawnList;
            using (var chess2UtilsNotStatic = new Chess2UtilsNotStatic())
            {
                var nodeResult = mainWindow.GetBestPositionLocalNotTask(mainWindow.ComputerColore);

                var randomList = nodeResult.AsssociateNodeChess2.RandomEquivalentList;


                var isSuccess = false;
                if (randomList.Count == 0)
                    isSuccess = true;
                Assert.IsTrue(isSuccess);

                Assert.AreEqual(nodeResult.BestChildPosition, "d5");
            }
        }

        /*tsiry;25-10-2021*/
        [TestMethod]
        public void MTT72BLaReineNoirDoitPrendreLePionEnD5()
        {
            

            var mainWindow = new MainWindow(); mainWindow.SetTurnNumberLabel("5");mainWindow.ComputerColore = "White";
            var testName = "T72BLaReineBlanchDoitPrendreLePionEnD4";
            var testPath = Path.Combine(testsDirrectory, testName);
             mainWindow.LoadFromDirectorie(testPath);

            using (var chess2UtilsNotStatic = new Chess2UtilsNotStatic())
            {
                var nodeResult = mainWindow.GetBestPositionLocalNotTask(mainWindow.ComputerColore);

                var randomList = nodeResult.AsssociateNodeChess2.RandomEquivalentList;
                var isSuccess = false;
                if (randomList.Count == 0 || randomList.Count == 1)
                    isSuccess = true;
                Assert.IsTrue(isSuccess);

                Assert.AreEqual(nodeResult.BestChildPosition, "d4");
            }
        }


        /*tsiry;25-10-2021*/
        [TestMethod]
        public void MTT73LeFouNoirNeDoitPasPrendreLePionEnB2()
        {
            

            var mainWindow = new MainWindow(); mainWindow.SetTurnNumberLabel("5");mainWindow.ComputerColore = "Black";

            var testName = "T73LeFouNoirNeDoitPasPrendreLePionEnB2";
            var testPath = Path.Combine(testsDirrectory, testName);
            mainWindow.LoadFromDirectorie(testPath);
            using (var chess2UtilsNotStatic = new Chess2UtilsNotStatic())
            {
                var nodeResult = mainWindow.GetBestPositionLocalNotTask(mainWindow.ComputerColore);

                var randomList = nodeResult.AsssociateNodeChess2.RandomEquivalentList;
                //Assert.IsNull(randomList);

                Assert.AreNotEqual(nodeResult.BestChildPosition, "b2");
            }
        }

        /*tsiry;28-10-2021*/
        [TestMethod]
        public void MTT74LesBlanchsDoiventPrendreLePionEnD4()
        {
            

            var mainWindow = new MainWindow(); mainWindow.SetTurnNumberLabel("5");mainWindow.ComputerColore = "White";




            
            var pawnListWhite = new List<Pawn>();
            var pawnListBlack = new List<Pawn>();

            var testName = "T74LesBlanchsDoiventPrendreLePionEnD4";
            var testPath = Path.Combine(testsDirrectory, testName);
            mainWindow.LoadFromDirectorie(testPath);
            using (var chess2UtilsNotStatic = new Chess2UtilsNotStatic())
            {
                var nodeResult = mainWindow.GetBestPositionLocalNotTask(mainWindow.ComputerColore);

                //var randomList = nodeResult.AsssociateNodeChess2.RandomEquivalentList ;
                //Assert.AreEqual(0, randomList.Count);

                Assert.AreEqual(nodeResult.BestChildPosition, "d4");
            }
        }

        /*tsiry;28-10-2021*/
        [TestMethod]
        public void MTT78ProtectionDuRookDesNoirs()
        {
            

            var mainWindow = new MainWindow(); mainWindow.SetTurnNumberLabel("5");mainWindow.ComputerColore = "White";

            var testName = "T78ProtectionDuRookDesNoirs";
            var testPath = Path.Combine(testsDirrectory, testName);
            mainWindow.LoadFromDirectorie(testPath);

            using (var chess2UtilsNotStatic = new Chess2UtilsNotStatic())
            {
                var nodeResult = mainWindow.GetBestPositionLocalNotTask(mainWindow.ComputerColore);

        // var randomList = nodeResult.AsssociateNodeChess2.RandomEquivalentList;
        //  Assert.IsNull(randomList);
        Assert.AreEqual(nodeResult.Location, "a2");
        Assert.AreEqual(nodeResult.BestChildPosition, "b2");
      }
        }


        /*tsiry;28-10-2021*/
        [TestMethod]
        public void MTT79LeRoisBlanchDoitSeMettreEnG1()
        {
            

            var mainWindow = new MainWindow(); mainWindow.SetTurnNumberLabel("5");mainWindow.ComputerColore = "White";




            
            var pawnListWhite = new List<Pawn>();
            var pawnListBlack = new List<Pawn>();



            //WHITEList
            var whiteListString = "" +
      "King;f1;White;False;True;True;True" +
      "\nRook;g3;White;False;False;False;False" +
      "\nBishop;a2;White;False;False;False;False" +
      "\nSimplePawn;f2;White;True;False;False;False" +
      "\nSimplePawn;g4;White;True;False;False;False";

            ;
            var whiteList = whiteListString.Split('\n');
            foreach (var line in whiteList)
            {
                var datas = line.Split(';');
                var newPawn = new Pawn(datas[0], datas[1], new Button(), datas[2], mainWindow);
                //;{pawn.IsFirstMove};{pawn.IsFirstMoveKing};{pawn.IsLeftRookFirstMove};{pawn.IsRightRookFirstMove}
                newPawn.IsFirstMove = bool.Parse(datas[3]);
                newPawn.IsFirstMoveKing = bool.Parse(datas[4]);
                newPawn.IsLeftRookFirstMove = bool.Parse(datas[5]);
                newPawn.IsRightRookFirstMove = bool.Parse(datas[6]);
                pawnListWhite.Add(newPawn);
            }

            //BLACKList
            var blackListString = "" +
      "King;e8;Black;False;True;True;True" +
      "\nRook;h2;Black;False;False;False;False" +
      "\nBishop;a6;Black;False;False;False;False" +
      "\nBishop;a5;Black;False;False;False;False" +
      "\nSimplePawn;a7;Black;True;False;False;False" +
      "\nSimplePawn;d4;Black;True;False;False;False" +
      "\nSimplePawn;f7;Black;True;False;False;False";
            var blackList = blackListString.Split('\n');
            foreach (var line in blackList)
            {
                var datas = line.Split(';');
                var newPawn = new Pawn(datas[0], datas[1], new Button(), datas[2], mainWindow);
                //;{pawn.IsFirstMove};{pawn.IsFirstMoveKing};{pawn.IsLeftRookFirstMove};{pawn.IsRightRookFirstMove}
                newPawn.IsFirstMove = bool.Parse(datas[3]);
                newPawn.IsFirstMoveKing = bool.Parse(datas[4]);
                newPawn.IsLeftRookFirstMove = bool.Parse(datas[5]);
                newPawn.IsRightRookFirstMove = bool.Parse(datas[6]);
                pawnListBlack.Add(newPawn);
            }



            var pawnList = new List<Pawn>();pawnList.AddRange(pawnListWhite);pawnList.AddRange(pawnListBlack);mainWindow.PawnList = pawnList;
            using (var chess2UtilsNotStatic = new Chess2UtilsNotStatic())
            {
                var nodeResult = mainWindow.GetBestPositionLocalNotTask(mainWindow.ComputerColore);

                var randomList = nodeResult.AsssociateNodeChess2.RandomEquivalentList;
                //Assert.IsNull(randomList);
                Assert.AreEqual(0, randomList.Count);

                Assert.AreEqual(nodeResult.BestChildPosition, "g1");
            }
        }


        /*tsiry;12-11-2021*/
        [TestMethod]
        public void MTT80LeRoiNoirDoitBougerEtLaReineNoirNeDoitPasSeMettreEn()
        {
            

            var mainWindow = new MainWindow(); mainWindow.SetTurnNumberLabel("5");mainWindow.ComputerColore = "Black";




            
            var pawnListWhite = new List<Pawn>();
            var pawnListBlack = new List<Pawn>();



            //WHITEList
            var whiteListString = "" +
      "King;g3;White;False;True;True;True" +
      "\nQueen;g8;White;False;False;False;False" +
      "\nRook;a1;White;False;False;False;False" +
      "\nKnight;b1;White;False;False;False;False" +
      "\nBishop;c3;White;False;False;False;False" +
      "\nBishop;f1;White;False;False;False;False" +
      "\nSimplePawn;a2;White;True;False;False;False" +
      "\nSimplePawn;g5;White;True;False;False;False" +
      "\nSimplePawn;c4;White;True;False;False;False" +
      "\nSimplePawn;d3;White;True;False;False;False" +
      "\nSimplePawn;e4;White;True;False;False;False" +
      "\nSimplePawn;f2;White;True;False;False;False" +
      "\nSimplePawn;g2;White;True;False;False;False";

            ;
            var whiteList = whiteListString.Split('\n');
            foreach (var line in whiteList)
            {
                var datas = line.Split(';');
                var newPawn = new Pawn(datas[0], datas[1], new Button(), datas[2], mainWindow);
                //;{pawn.IsFirstMove};{pawn.IsFirstMoveKing};{pawn.IsLeftRookFirstMove};{pawn.IsRightRookFirstMove}
                newPawn.IsFirstMove = bool.Parse(datas[3]);
                newPawn.IsFirstMoveKing = bool.Parse(datas[4]);
                newPawn.IsLeftRookFirstMove = bool.Parse(datas[5]);
                newPawn.IsRightRookFirstMove = bool.Parse(datas[6]);
                pawnListWhite.Add(newPawn);
            }

            //BLACKList
            var blackListString = "" +
      "King;d8;Black;False;True;True;True" +
      "\nQueen;d1;Black;False;False;False;False" +
      "\nRook;a8;Black;False;False;False;False" +
      "\nRook;h4;Black;False;False;False;False" +
      "\nKnight;b8;Black;False;False;False;False" +
      "\nBishop;c8;Black;False;False;False;False" +
      "\nSimplePawn;a7;Black;True;False;False;False" +
      "\nSimplePawn;b7;Black;True;False;False;False" +
      "\nSimplePawn;c5;Black;True;False;False;False" +
      "\nSimplePawn;d7;Black;True;False;False;False" +
      "\nSimplePawn;e7;Black;True;False;False;False" +
      "\nSimplePawn;g6;Black;True;False;False;False";
            var blackList = blackListString.Split('\n');
            foreach (var line in blackList)
            {
                var datas = line.Split(';');
                var newPawn = new Pawn(datas[0], datas[1], new Button(), datas[2], mainWindow);
                //;{pawn.IsFirstMove};{pawn.IsFirstMoveKing};{pawn.IsLeftRookFirstMove};{pawn.IsRightRookFirstMove}
                newPawn.IsFirstMove = bool.Parse(datas[3]);
                newPawn.IsFirstMoveKing = bool.Parse(datas[4]);
                newPawn.IsLeftRookFirstMove = bool.Parse(datas[5]);
                newPawn.IsRightRookFirstMove = bool.Parse(datas[6]);
                pawnListBlack.Add(newPawn);
            }



            var pawnList = new List<Pawn>();pawnList.AddRange(pawnListWhite);pawnList.AddRange(pawnListBlack);mainWindow.PawnList = pawnList;
            using (var chess2UtilsNotStatic = new Chess2UtilsNotStatic())
            {
                var nodeResult = mainWindow.GetBestPositionLocalNotTask(mainWindow.ComputerColore);

                var randomList = nodeResult.AsssociateNodeChess2.RandomEquivalentList;
               // Assert.AreEqual(0, randomList.Count);

                Assert.AreEqual(nodeResult.BestChildPosition, "c7");
            }
        }


        /*tsiry;12-11-2021*/
        [TestMethod]
        public void MTT81LeCavalierBlanchNeDoitPasPrendreLaReinEtLesBlanchDoiventEviterLEchec()
        {
            

            var mainWindow = new MainWindow(); mainWindow.SetTurnNumberLabel("5");mainWindow.ComputerColore = "White";




            
            var pawnListWhite = new List<Pawn>();
            var pawnListBlack = new List<Pawn>();



            //WHITEList
            var whiteListString = "" +
      "King;e1;White;False;True;True;True" +
      "\nQueen;c1;White;False;False;False;False" +
      "\nRook;a1;White;False;False;False;False" +
      "\nRook;h1;White;False;False;False;False" +
      "\nKnight;e4;White;False;False;False;False" +
      "\nBishop;f1;White;False;False;False;False" +
      "\nKnight;g1;White;False;False;False;False" +
      "\nSimplePawn;a2;White;True;False;False;False" +
      "\nSimplePawn;b2;White;True;False;False;False" +
      "\nSimplePawn;d3;White;True;False;False;False" +
      "\nSimplePawn;e2;White;True;False;False;False" +
      "\nSimplePawn;f3;White;True;False;False;False" +
      "\nSimplePawn;g2;White;True;False;False;False" +
      "\nSimplePawn;h2;White;True;False;False;False";

            ;
            var whiteList = whiteListString.Split('\n');
            foreach (var line in whiteList)
            {
                var datas = line.Split(';');
                var newPawn = new Pawn(datas[0], datas[1], new Button(), datas[2], mainWindow);
                //;{pawn.IsFirstMove};{pawn.IsFirstMoveKing};{pawn.IsLeftRookFirstMove};{pawn.IsRightRookFirstMove}
                newPawn.IsFirstMove = bool.Parse(datas[3]);
                newPawn.IsFirstMoveKing = bool.Parse(datas[4]);
                newPawn.IsLeftRookFirstMove = bool.Parse(datas[5]);
                newPawn.IsRightRookFirstMove = bool.Parse(datas[6]);
                pawnListWhite.Add(newPawn);
            }

            //BLACKList
            var blackListString = "" +
      "King;g8;Black;False;True;True;True" +
      "\nQueen;f6;Black;False;False;False;False" +
      "\nRook;a8;Black;False;False;False;False" +
      "\nRook;e8;Black;False;False;False;False" +
      "\nKnight;c6;Black;False;False;False;False" +
      "\nBishop;c8;Black;False;False;False;False" +
      "\nBishop;b4;Black;False;False;False;False" +
      "\nSimplePawn;a7;Black;True;False;False;False" +
      "\nSimplePawn;b7;Black;True;False;False;False" +
      "\nSimplePawn;c7;Black;True;False;False;False" +
      "\nSimplePawn;d4;Black;True;False;False;False" +
      "\nSimplePawn;f7;Black;True;False;False;False" +
      "\nSimplePawn;g7;Black;True;False;False;False" +
      "\nSimplePawn;h7;Black;True;False;False;False";
            var blackList = blackListString.Split('\n');
            foreach (var line in blackList)
            {
                var datas = line.Split(';');
                var newPawn = new Pawn(datas[0], datas[1], new Button(), datas[2], mainWindow);
                //;{pawn.IsFirstMove};{pawn.IsFirstMoveKing};{pawn.IsLeftRookFirstMove};{pawn.IsRightRookFirstMove}
                newPawn.IsFirstMove = bool.Parse(datas[3]);
                newPawn.IsFirstMoveKing = bool.Parse(datas[4]);
                newPawn.IsLeftRookFirstMove = bool.Parse(datas[5]);
                newPawn.IsRightRookFirstMove = bool.Parse(datas[6]);
                pawnListBlack.Add(newPawn);
            }



            var pawnList = new List<Pawn>();pawnList.AddRange(pawnListWhite);pawnList.AddRange(pawnListBlack);mainWindow.PawnList = pawnList;
            using (var chess2UtilsNotStatic = new Chess2UtilsNotStatic())
            {
                var nodeResult = mainWindow.GetBestPositionLocalNotTask(mainWindow.ComputerColore);

                //var randomList = nodeResult.AsssociateNodeChess2.RandomEquivalentList;
                //Assert.IsNotNull(randomList);

                Assert.AreNotEqual(nodeResult.BestChildPosition, "f6");
            }
        }


        [TestMethod]
        public void MTT82Null2LesNoirDoiventEviterLeNull()
        {
            var mainWindow = new MainWindow(); mainWindow.SetTurnNumberLabel("5");

            mainWindow.ComputerColore = "Black";




            mainWindow.CleanPawnList();
            var pawnListWhite = new List<Pawn>();
            var pawnListBlack = new List<Pawn>();



            //WHITEList
            var whiteListString = "" +
      "King;c5;White;False;False;True;True";

            var whiteList = whiteListString.Split('\n');
            foreach (var line in whiteList)
            {
                var datas = line.Split(';');
                var newPawn = new Pawn(datas[0], datas[1], new Button(), datas[2], mainWindow);
                //;{pawn.IsFirstMove};{pawn.IsFirstMoveKing};{pawn.IsLeftRookFirstMove};{pawn.IsRightRookFirstMove}
                newPawn.IsFirstMove = bool.Parse(datas[3]);
                newPawn.IsFirstMoveKing = bool.Parse(datas[4]);
                newPawn.IsLeftRookFirstMove = bool.Parse(datas[5]);
                newPawn.IsRightRookFirstMove = bool.Parse(datas[6]);
                pawnListWhite.Add(newPawn);
            }

            //BLACKList
            var blackListString = "" +
      "King;f7;Black;False;False;True;True" +
      "\nQueen;f1;Black;False;False;False;False";
            var blackList = blackListString.Split('\n');
            foreach (var line in blackList)
            {
                var datas = line.Split(';');
                var newPawn = new Pawn(datas[0], datas[1], new Button(), datas[2], mainWindow);
                //;{pawn.IsFirstMove};{pawn.IsFirstMoveKing};{pawn.IsLeftRookFirstMove};{pawn.IsRightRookFirstMove}
                newPawn.IsFirstMove = bool.Parse(datas[3]);
                newPawn.IsFirstMoveKing = bool.Parse(datas[4]);
                newPawn.IsLeftRookFirstMove = bool.Parse(datas[5]);
                newPawn.IsRightRookFirstMove = bool.Parse(datas[6]);
                pawnListBlack.Add(newPawn);
            }



            mainWindow.FillPawnListAndFillAllPossibleTrips(pawnListWhite, pawnListBlack);
            //ajout des movements
            if (Chess2Console.Utils.MovingList == null)
                Chess2Console.Utils.MovingList = new List<string>();
            Chess2Console.Utils.MovingList.Add("5(K|B)>13(__)");
            Chess2Console.Utils.MovingList.Add("33(K|W)>34(__)");

            Chess2Console.Utils.MovingList.Add("53(Q|B)>61(__)");
            Chess2Console.Utils.MovingList.Add("34(K|W)>26(__)");
            Chess2Console.Utils.MovingList.Add("61(Q|B)>53(__)");
            Chess2Console.Utils.MovingList.Add("26(K|W)>34(__)");
            Chess2Console.Utils.MovingList.Add("53(Q|B)>61(__)");
            Chess2Console.Utils.MovingList.Add("34(K|W)>26(__)");
            using (var chess2UtilsNotStatic = new Chess2UtilsNotStatic())
            {
                var nodeResult = chess2UtilsNotStatic.GetBestPositionLocalUsingMiltiThreading(mainWindow.ComputerColore, Chess2Utils.GenerateBoardFormPawnList(mainWindow.PawnList), mainWindow.IsReprise, mainWindow.SpecifiBoardList);

                var randomList = nodeResult.AsssociateNodeChess2.RandomEquivalentList;
                //var t_movingList = Chess2Console.Utils.MovingList;
                var notValide = randomList.FirstOrDefault(x => x.FromIndex == 61 && x.ToIndex == 53);
                Assert.IsNull(notValide);
            }

            // Assert.AreNotEqual(nodeResult.BestChildPosition, "f6");
        }

        /*tsiry;12-11-2021*/
        [TestMethod]
        public void MTT84EchecEtMatNoir()
        {
            

            var mainWindow = new MainWindow(); mainWindow.SetTurnNumberLabel("5");mainWindow.ComputerColore = "Black";




            
            var pawnListWhite = new List<Pawn>();
            var pawnListBlack = new List<Pawn>();



            //WHITEList
            var whiteListString = "" +
      "King;g1;White;False;True;True;True" +
      "\nQueen;d8;White;False;False;False;False" +
      "\nRook;f1;White;False;False;False;False" +
      "\nBishop;e3;White;False;False;False;False" +
      "\nBishop;c4;White;False;False;False;False" +
      "\nSimplePawn;h2;White;True;False;False;False" +
      "\nSimplePawn;g2;White;True;False;False;False" +
      "\nSimplePawn;f2;White;True;False;False;False" +
      "\nSimplePawn;e4;White;True;False;False;False" +
      "\nSimplePawn;a3;White;True;False;False;False";

            ;
            var whiteList = whiteListString.Split('\n');
            foreach (var line in whiteList)
            {
                var datas = line.Split(';');
                var newPawn = new Pawn(datas[0], datas[1], new Button(), datas[2], mainWindow);
                //;{pawn.IsFirstMove};{pawn.IsFirstMoveKing};{pawn.IsLeftRookFirstMove};{pawn.IsRightRookFirstMove}
                newPawn.IsFirstMove = bool.Parse(datas[3]);
                newPawn.IsFirstMoveKing = bool.Parse(datas[4]);
                newPawn.IsLeftRookFirstMove = bool.Parse(datas[5]);
                newPawn.IsRightRookFirstMove = bool.Parse(datas[6]);
                pawnListWhite.Add(newPawn);
            }

            //BLACKList
            var blackListString = "" +
      "King;f8;Black;False;True;True;True" +
      "\nRook;c7;Black;False;False;False;False" +
      "\nRook;h8;Black;False;False;False;False" +
      "\nKnight;a6;Black;False;False;False;False" +
      "\nBishop;c3;Black;False;False;False;False" +
      "\nSimplePawn;h7;Black;True;False;False;False" +
      "\nSimplePawn;g7;Black;True;False;False;False" +
      "\nSimplePawn;c6;Black;True;False;False;False" +
      "\nSimplePawn;a7;Black;True;False;False;False";
            var blackList = blackListString.Split('\n');
            foreach (var line in blackList)
            {
                var datas = line.Split(';');
                var newPawn = new Pawn(datas[0], datas[1], new Button(), datas[2], mainWindow);
                //;{pawn.IsFirstMove};{pawn.IsFirstMoveKing};{pawn.IsLeftRookFirstMove};{pawn.IsRightRookFirstMove}
                newPawn.IsFirstMove = bool.Parse(datas[3]);
                newPawn.IsFirstMoveKing = bool.Parse(datas[4]);
                newPawn.IsLeftRookFirstMove = bool.Parse(datas[5]);
                newPawn.IsRightRookFirstMove = bool.Parse(datas[6]);
                pawnListBlack.Add(newPawn);
            }



            var pawnList = new List<Pawn>();pawnList.AddRange(pawnListWhite);pawnList.AddRange(pawnListBlack);mainWindow.PawnList = pawnList;
            using (var chess2UtilsNotStatic = new Chess2UtilsNotStatic())
            {
                var nodeResult = mainWindow.GetBestPositionLocalNotTask(mainWindow.ComputerColore);

                Assert.IsNull(nodeResult);
            }

        }


        [TestMethod]
        public void MTT84BEchecEtMatNoir()
        {
            

            var mainWindow = new MainWindow(); mainWindow.SetTurnNumberLabel("5");mainWindow.ComputerColore = "Black";




            
            var pawnListWhite = new List<Pawn>();
            var pawnListBlack = new List<Pawn>();



            //WHITEList
            var whiteListString = "" +
      "King;g1;White;False;True;True;True" +
      "\nQueen;d8;White;False;False;False;False" +
      "\nRook;f1;White;False;False;False;False" +
      "\nBishop;e3;White;False;False;False;False" +
      "\nBishop;c4;White;False;False;False;False" +
      "\nSimplePawn;h2;White;True;False;False;False" +
      "\nSimplePawn;g2;White;True;False;False;False" +
      "\nSimplePawn;f2;White;True;False;False;False" +
      "\nSimplePawn;e4;White;True;False;False;False" +
      "\nSimplePawn;a3;White;True;False;False;False";

            ;
            var whiteList = whiteListString.Split('\n');
            foreach (var line in whiteList)
            {
                var datas = line.Split(';');
                var newPawn = new Pawn(datas[0], datas[1], new Button(), datas[2], mainWindow);
                //;{pawn.IsFirstMove};{pawn.IsFirstMoveKing};{pawn.IsLeftRookFirstMove};{pawn.IsRightRookFirstMove}
                newPawn.IsFirstMove = bool.Parse(datas[3]);
                newPawn.IsFirstMoveKing = bool.Parse(datas[4]);
                newPawn.IsLeftRookFirstMove = bool.Parse(datas[5]);
                newPawn.IsRightRookFirstMove = bool.Parse(datas[6]);
                pawnListWhite.Add(newPawn);
            }

            //BLACKList
            var blackListString = "" +
      "King;f8;Black;False;True;True;True" +
      "\nRook;c7;Black;False;False;False;False" +
      "\nRook;h8;Black;False;False;False;False" +
      "\nKnight;a6;Black;False;False;False;False" +
      "\nBishop;c3;Black;False;False;False;False" +
      "\nSimplePawn;h7;Black;True;False;False;False" +
      "\nSimplePawn;g7;Black;True;False;False;False" +
      "\nSimplePawn;c6;Black;True;False;False;False" +
      "\nSimplePawn;a7;Black;True;False;False;False";
            var blackList = blackListString.Split('\n');
            foreach (var line in blackList)
            {
                var datas = line.Split(';');
                var newPawn = new Pawn(datas[0], datas[1], new Button(), datas[2], mainWindow);
                //;{pawn.IsFirstMove};{pawn.IsFirstMoveKing};{pawn.IsLeftRookFirstMove};{pawn.IsRightRookFirstMove}
                newPawn.IsFirstMove = bool.Parse(datas[3]);
                newPawn.IsFirstMoveKing = bool.Parse(datas[4]);
                newPawn.IsLeftRookFirstMove = bool.Parse(datas[5]);
                newPawn.IsRightRookFirstMove = bool.Parse(datas[6]);
                pawnListBlack.Add(newPawn);
            }



            var pawnList = new List<Pawn>();pawnList.AddRange(pawnListWhite);pawnList.AddRange(pawnListBlack);mainWindow.PawnList = pawnList;
            using (var chess2UtilsNotStatic = new Chess2UtilsNotStatic())
            {
                var nodeResult = mainWindow.GetBestPositionLocalNotTask(mainWindow.ComputerColore);

                //  var randomList = nodeResult.AsssociateNodeChess2.RandomEquivalentList;
                Assert.IsNull(nodeResult);
                //echec si nodeResult.Location ==  nodeResult.BestChildPosition
                // Assert.AreEqual(nodeResult.Location, nodeResult.BestChildPosition);
            }
        }


        /*tsiry;16-12-2021*/
        [TestMethod]
        public void MTT85LaToureNoirDoitPrendreLePionEnA5()
        {


            
            var mainWindow = new MainWindow(); mainWindow.SetTurnNumberLabel("5");mainWindow.ComputerColore = "Black";
            var testName = "T85LaToureNoirDoitPrendreLePionEnA5";
            var testPath = Path.Combine(testsDirrectory, testName);
            mainWindow.LoadFromDirectorie(testPath);

            using (var chess2UtilsNotStatic = new Chess2UtilsNotStatic())
            {
                var nodeResult = mainWindow.GetBestPositionLocalNotTask(mainWindow.ComputerColore);

                //var randomList = nodeResult.AsssociateNodeChess2.RandomEquivalentList;
                //Assert.IsNull(randomList);
                //echec si nodeResult.Location ==  nodeResult.BestChildPosition
                Assert.AreEqual(nodeResult.BestChildPosition, "a5");
            }
        }


        /*tsiry;11-01-2022
         * */
        [TestMethod]
        public void MTT86ApplicationDownOutOfmemories()
        {


            
            var mainWindow = new MainWindow(); mainWindow.SetTurnNumberLabel("5");mainWindow.ComputerColore = "White";

            var testName = "T86ApplicationDownOutOfmemories";
            var testPath = Path.Combine(testsDirrectory, testName);
            mainWindow.LoadFromDirectorie(testPath);

            using (var chess2UtilsNotStatic = new Chess2UtilsNotStatic())
            {
                var nodeResult = mainWindow.GetBestPositionLocalNotTask(mainWindow.ComputerColore);

        //var randomList = nodeResult.AsssociateNodeChess2.RandomEquivalentList;
        //Assert.IsNull(randomList);
        //echec si nodeResult.Location ==  nodeResult.BestChildPosition
        Assert.AreEqual("a8", nodeResult.BestChildPosition);
      }
        }
        /*tsiry;11-01-2022
        * */
        [TestMethod]
        public void MTT87BlackWinL2()
        {


            
            var mainWindow = new MainWindow(); mainWindow.SetTurnNumberLabel("5");mainWindow.ComputerColore = "Black";
            var testName = "T87BlackInChessInL2";
            var testPath = Path.Combine(testsDirrectory, testName);
            mainWindow.LoadFromDirectorie(testPath);

            using (var chess2UtilsNotStatic = new Chess2UtilsNotStatic())
            {
                var nodeResult = mainWindow.GetBestPositionLocalNotTask(mainWindow.ComputerColore);
                Assert.AreEqual(nodeResult.BestChildPosition, "f2");
            } //var randomList = nodeResult.AsssociateNodeChess2.RandomEquivalentList;
              //Assert.IsNull(randomList);
              //echec si nodeResult.Location ==  nodeResult.BestChildPosition

            /*    -2  d7 => e6
          - 2  d8 => a5
           - 2  f8 => b4
            - 2  e8 => e7
             - 2  g8 => f6
              - 2  d7 => e6
               - 2  d8 => f6
                - 2  f8 => c5*/

        }
        [TestMethod]
        public void MTT87WhiteAvoidInChessInL2()
        {


            
            var mainWindow = new MainWindow(); mainWindow.SetTurnNumberLabel("5");mainWindow.ComputerColore = "White";

            var testName = "T87BlackInChessInL2";
            var testPath = Path.Combine(testsDirrectory, testName);
            mainWindow.LoadFromDirectorie(testPath);

            using (var chess2UtilsNotStatic = new Chess2UtilsNotStatic())
            {
                var nodeResult = mainWindow.GetBestPositionLocalNotTask(mainWindow.ComputerColore);


        Assert.IsTrue(nodeResult.BestChildPosition == "e3" || nodeResult.BestChildPosition == "g3");//e3 ou g3 

      }


    }

        [TestMethod]
        public void MTT88LesBlanchDoiventEviterLEchec()
        {


            
            var mainWindow = new MainWindow(); mainWindow.SetTurnNumberLabel("5");mainWindow.ComputerColore = "White";

            var testName = "T88LesBlanchDoiventEviterLEchec";
            var testPath = Path.Combine(testsDirrectory, testName);

      mainWindow.LoadFromDirectorie(testPath);
      using (var chess2UtilsNotStatic = new Chess2UtilsNotStatic())
      {
      
        var nodeResult = mainWindow.GetBestPositionLocalNotTask(mainWindow.ComputerColore);

        Assert.IsTrue(nodeResult.BestChildPosition == "e3" || nodeResult.BestChildPosition == "g3");//e3 ou g3 

      }


    }
        [TestMethod]
        public void MTT88LesNoirDoiventSeMettreEnF2()
        {


            
            var mainWindow = new MainWindow(); mainWindow.SetTurnNumberLabel("5");mainWindow.ComputerColore = "Black";
            var testName = "T88LesBlanchDoiventEviterLEchec";
            var testPath = Path.Combine(testsDirrectory, testName);
            mainWindow.LoadFromDirectorie(testPath);
            using (var chess2UtilsNotStatic = new Chess2UtilsNotStatic())
            {
                var nodeResult = mainWindow.GetBestPositionLocalNotTask(mainWindow.ComputerColore);

                //var randomList = nodeResult.AsssociateNodeChess2.RandomEquivalentList;
                //Assert.IsNull(randomList);
                //echec si nodeResult.Location ==  nodeResult.BestChildPosition


                Assert.AreEqual(nodeResult.BestChildPosition, "f2");
            }


        }


        /*tsiry;16-03-2022*/
        [TestMethod]
        public void MTT89LeFouNoirNeDoitPasSeMettreEnB4()
        {


            
            var mainWindow = new MainWindow(); mainWindow.SetTurnNumberLabel("5");mainWindow.ComputerColore = "Black";
            var testName = "T89LeFouNoirNeDoitPasSeMettreEnB4";
            var testPath = Path.Combine(testsDirrectory, testName);
            mainWindow.LoadFromDirectorie(testPath);
            using (var chess2UtilsNotStatic = new Chess2UtilsNotStatic())
            {
                var nodeResult = mainWindow.GetBestPositionLocalNotTask(mainWindow.ComputerColore);

                Assert.AreNotEqual(nodeResult.BestChildPosition, "b4");
            }
            //var randomList = nodeResult.AsssociateNodeChess2.RandomEquivalentList;
            //Assert.IsNull(randomList);
            //echec si nodeResult.Location ==  nodeResult.BestChildPosition





        }

     /*   //tsiry;16-03-2022
        [TestMethod]
        public void MTT90LePoinNoirDoitSeMettreEnH5()
        {


            
            var mainWindow = new MainWindow(); mainWindow.SetTurnNumberLabel("5");mainWindow.ComputerColore = "Black";
            var testName = "T90LePoinNoirDoitSeMettreEnH5";
            var testPath = Path.Combine(testsDirrectory, testName);
            mainWindow.LoadFromDirectorie(testPath);
            using (var chess2UtilsNotStatic = new Chess2UtilsNotStatic())
            {
                var nodeResult = mainWindow.GetBestPositionLocalNotTask(mainWindow.ComputerColore);

                Assert.AreEqual(nodeResult.Location, "h7");
                Assert.AreEqual(nodeResult.BestChildPosition, "h5");
            }
            //var randomList = nodeResult.AsssociateNodeChess2.RandomEquivalentList;
            //Assert.IsNull(randomList);
            //echec si nodeResult.Location ==  nodeResult.BestChildPosition





        }
       */ /*tsiry;17-03-2022*/
        [TestMethod]
        public void MTT91LePoinNoirNeDoitPasSeMettreEnH5()
        {


            
            var mainWindow = new MainWindow(); mainWindow.SetTurnNumberLabel("5");mainWindow.ComputerColore = "Black";
            var testName = "T91LaReineNoirDoitSeMettreEnH5";
            var testPath = Path.Combine(testsDirrectory, testName);
            mainWindow.LoadFromDirectorie(testPath);
            using (var chess2UtilsNotStatic = new Chess2UtilsNotStatic())
            {
                var nodeResult = mainWindow.GetBestPositionLocalNotTask(mainWindow.ComputerColore);

                Assert.AreEqual(nodeResult.Location, "g4");
                Assert.AreEqual(nodeResult.BestChildPosition, "h5");
            }
            //var randomList = nodeResult.AsssociateNodeChess2.RandomEquivalentList;
            //Assert.IsNull(randomList);
            //echec si nodeResult.Location ==  nodeResult.BestChildPosition





        }
        [TestMethod]
        public void MTT33bLePionBlancDoitPrendreLeCavalierOuLeFoueEnD5()
        {
            /*Le pion blanch prendre le cavalier en d4*/






            var mainWindow = new MainWindow(); mainWindow.SetTurnNumberLabel("5");mainWindow.ComputerColore = "White";
            var testName = "T33bLePionBlancDoitPrendreLeCavalierOuLeFoueEnD5";
            var testPath = Path.Combine(testsDirrectory, testName);
           mainWindow.LoadFromDirectorie(testPath);

            using (var chess2UtilsNotStatic = new Chess2UtilsNotStatic())
            {
                var nodeResult = mainWindow.GetBestPositionLocalNotTask(mainWindow.ComputerColore);
                //Le poin doit pas se mettre en d4
                //if()
                Assert.IsTrue(nodeResult.BestChildPosition == "d4" || nodeResult.BestChildPosition == "d5");
               // var randomList = nodeResult.AsssociateNodeChess2.RandomEquivalentList;
               // Assert.AreEqual(randomList.Count, 0);
            }



        }



        /*tsiry;16-05-2022*/
        [TestMethod]
        public void MTT92ALaReineNoirNeDoitPasSeMettreEnC3()
        {


            
            var mainWindow = new MainWindow(); mainWindow.SetTurnNumberLabel("5");mainWindow.ComputerColore = "Black";
            var testName = "T92ALaReineNoirNeDoitPasSeMettreEnC3";
            var testPath = Path.Combine(testsDirrectory, testName);
            mainWindow.LoadFromDirectorie(testPath);
            using (var chess2UtilsNotStatic = new Chess2UtilsNotStatic())
            {
                var nodeResult = mainWindow.GetBestPositionLocalNotTask(mainWindow.ComputerColore);

                //Assert.AreEqual(nodeResult.Location, "g4");
                Assert.AreNotEqual(nodeResult.BestChildPosition, "c3");
            }
            //var randomList = nodeResult.AsssociateNodeChess2.RandomEquivalentList;
            //Assert.IsNull(randomList);
            //echec si nodeResult.Location ==  nodeResult.BestChildPosition





        }
        /*tsiry;17-05-2022*/
        [TestMethod]
        public void MTT92BLeCavalierNoirDoitPartieDeF6()
        {


            
            var mainWindow = new MainWindow(); mainWindow.SetTurnNumberLabel("5");mainWindow.ComputerColore = "Black";
            var testName = "T92BLeCavalierNoirDoitPartieDeF6";
            var testPath = Path.Combine(testsDirrectory, testName);
            mainWindow.LoadFromDirectorie(testPath);
            using (var chess2UtilsNotStatic = new Chess2UtilsNotStatic())
            {
                var nodeResult = mainWindow.GetBestPositionLocalNotTask(mainWindow.ComputerColore);

                //Assert.AreEqual(nodeResult.Location, "g4");
                Assert.AreEqual(nodeResult.Location, "f6");
            }
            //var randomList = nodeResult.AsssociateNodeChess2.RandomEquivalentList;
            //Assert.IsNull(randomList);
            //echec si nodeResult.Location ==  nodeResult.BestChildPosition





        }
       
        /*tsiry;19-05-2022*/
        [TestMethod]
        public void MTT93ALaReineNoirDoitSeMettreEnG3()
        {

            var mainWindow = new MainWindow(); mainWindow.SetTurnNumberLabel("5");mainWindow.ComputerColore = "Black";
            var testName = "T93ALaReineNoirDoitSeMettreEnG3";
            var testPath = Path.Combine(testsDirrectory, testName);
           mainWindow.LoadFromDirectorie(testPath);
            using (var chess2UtilsNotStatic = new Chess2UtilsNotStatic())
            {
                var nodeResult = mainWindow.GetBestPositionLocalNotTask(mainWindow.ComputerColore);

                //Assert.AreEqual(nodeResult.Location, "g4");
                Assert.AreEqual(nodeResult.BestChildPosition, "g3");
            }
            //var randomList = nodeResult.AsssociateNodeChess2.RandomEquivalentList;
            //Assert.IsNull(randomList);
            //echec si nodeResult.Location ==  nodeResult.BestChildPosition





        }

        /*tsiry;19-05-2022*/
        [TestMethod]
        public void MTT94LeCavalierBlanchDoitSeMettreEnD2_ou_leFouDoiSePettreEnE6()
        {

            var mainWindow = new MainWindow(); mainWindow.SetTurnNumberLabel("5");mainWindow.ComputerColore = "White";
            var testName = "T94LeCavalierBlanchDoitSeMettreEnD2_ou_leFouDoiSePettreEnE6";
            var testPath = Path.Combine(testsDirrectory, testName);
           mainWindow.LoadFromDirectorie(testPath);
            using (var chess2UtilsNotStatic = new Chess2UtilsNotStatic())
            {
                var nodeResult = mainWindow.GetBestPositionLocalNotTask(mainWindow.ComputerColore);

                var result = nodeResult.BestChildPosition == "e6" || nodeResult.BestChildPosition == "d2";
                //Assert.AreEqual(nodeResult.Location, "g4");
                Assert.IsTrue(result);
                var randomList = nodeResult.AsssociateNodeChess2.RandomEquivalentList;
                Assert.AreEqual(randomList.Count,0);
            }

            //echec si nodeResult.Location ==  nodeResult.BestChildPosition





        }

        /*tsiry;23-05-2022*/
        [TestMethod]
        public void MTT95LaReineNoirDoitSeMettreEnH1PourGagnier()
        {

            var mainWindow = new MainWindow(); mainWindow.SetTurnNumberLabel("5");mainWindow.ComputerColore = "Black";
            var testName = "T95LaReineNoirDoitSeMettreEnH1PourGagnier";
            var testPath = Path.Combine(testsDirrectory, testName);
           mainWindow.LoadFromDirectorie(testPath);
            using (var chess2UtilsNotStatic = new Chess2UtilsNotStatic())
            {
                var nodeResult = mainWindow.GetBestPositionLocalNotTask(mainWindow.ComputerColore);
             //   Assert.AreEqual(nodeResult.BestChildPosition, "h1");
        Assert.AreEqual("f2", nodeResult.Location);//h1

      }
            //var randomList = nodeResult.AsssociateNodeChess2.RandomEquivalentList;
            //Assert.IsNull(randomList);
            //echec si nodeResult.Location ==  nodeResult.BestChildPosition





        }


    /*tsiry;05-07-2022*/
    [TestMethod]
    public void MTT95SuiteWhiteE4ToG3()
    {

      var mainWindow = new MainWindow(); mainWindow.SetTurnNumberLabel("5"); mainWindow.ComputerColore = "White";

      var testName = "T95SuiteWhiteE4ToG3";
      var testPath = Path.Combine(testsDirrectory, testName);
       mainWindow.LoadFromDirectorie(testPath);
      using (var chess2UtilsNotStatic = new Chess2UtilsNotStatic())
      {
        var nodeResult = mainWindow.GetBestPositionLocalNotTask(mainWindow.ComputerColore);

        Assert.AreEqual("g3", nodeResult.BestChildPosition);//h1

      }
    }


    [TestMethod]
    public void MTT95SuiteSuite()
    {

      var mainWindow = new MainWindow(); mainWindow.SetTurnNumberLabel("5"); mainWindow.ComputerColore = "Black";

      var testName = "T95SuiteSuite";
      var testPath = Path.Combine(testsDirrectory, testName);
      mainWindow.LoadFromDirectorie(testPath);
      using (var chess2UtilsNotStatic = new Chess2UtilsNotStatic())
      {
        var nodeResult = mainWindow.GetBestPositionLocalNotTask(mainWindow.ComputerColore);
        Assert.AreEqual("f2", nodeResult.BestChildPosition);//h1

      }
      //var randomList = nodeResult.AsssociateNodeChess2.RandomEquivalentList;
      //Assert.IsNull(randomList);
      //echec si nodeResult.Location ==  nodeResult.BestChildPosition





    }

    /*tsiry;23-05-2022*/
    [TestMethod]
         public void MTT95BLeCavalierBlanchDoitAttaquerEnF2()
        {

            var mainWindow = new MainWindow(); mainWindow.SetTurnNumberLabel("5");mainWindow.ComputerColore = "White";
            var testName = "T95BLeCavalierBlanchDoitAttaquerEnF2";
            var testPath = Path.Combine(testsDirrectory, testName);
           mainWindow.LoadFromDirectorie(testPath);
            using (var chess2UtilsNotStatic = new Chess2UtilsNotStatic())
            {
                var nodeResult = mainWindow.GetBestPositionLocalNotTask(mainWindow.ComputerColore);
                Assert.AreEqual(nodeResult.BestChildPosition, "f2");

            }
            //var randomList = nodeResult.AsssociateNodeChess2.RandomEquivalentList;
            //Assert.IsNull(randomList);
            //echec si nodeResult.Location ==  nodeResult.BestChildPosition





        }


    /*tsiry;24-06-2022*/
    [TestMethod]
    public void MTT96LeCavalierBlanchDoitSePettreEnC7()
    {

      var mainWindow = new MainWindow(); mainWindow.SetTurnNumberLabel("5"); mainWindow.ComputerColore = "White";
      var testName = "T96LeCavalierBlanchDoitSePettreEnC7";
      var testPath = Path.Combine(testsDirrectory, testName);
      mainWindow.LoadFromDirectorie(testPath);
      using (var chess2UtilsNotStatic = new Chess2UtilsNotStatic())
      {
        var nodeResult = mainWindow.GetBestPositionLocalNotTask(mainWindow.ComputerColore);
        Assert.AreEqual(nodeResult.BestChildPosition, "c7");

      }
      //var randomList = nodeResult.AsssociateNodeChess2.RandomEquivalentList;
      //Assert.IsNull(randomList);
      //echec si nodeResult.Location ==  nodeResult.BestChildPosition





    }
  }
}