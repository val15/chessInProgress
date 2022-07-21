using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Chess2Console
{
  public class Engine
  {

    public List<NodeChess2> level1NodeList { get; set; }
  public bool IsSecond { get; set; } = true;
    
    public string ComputerColore { get; set; }
    public string OpinionrColore { get; set; }
    public Board MainBord { get; set; }


    public List<SpecificBoard> SpecifiBoardList { get; set; }


    public int DeepLevel { get; set; }


    private bool _isReprise = false;
    private bool _isInTest  = false;

    


    public List<NodeChess2> LastNodes { get; set; }

    public NodeChess2 BestNode { get; set; }
    public NodeChess2 BestNodeSecond { get; set; }

    public NodeChess2 NotBestNode { get; set; }

    public bool IsParallelMode { get; set; }




    public Engine(int deepLevel, string computerColore, bool isReprise, List<SpecificBoard> specifiBoardList = null,bool isInTest=false)
    {
      _isReprise = isReprise;
      _isInTest = isInTest;
      DeepLevel = deepLevel;
      LastNodes = new List<NodeChess2>();
      ComputerColore = computerColore;
      OpinionrColore = "W";
      if (ComputerColore == "W")
        OpinionrColore = "B";
      SpecifiBoardList = specifiBoardList;
      Utils.ComputerColor = computerColore;
    }

    /*tsiry;27-09-2021
     * */
    public bool IsEquals(Board board1, Board board2)
    {
      var caseList1 = board1.GetCases();
      var caseList2 = board2.GetCases();
      for (int i = 0; i < caseList1.Count(); i++)
      {
        if (caseList1[i] != caseList2[i])
          return false;
      }



      return true;
    }

 
    public NodeChess2 Search(Board mainBord, string tunNumber, int fromIndexNotValide = -1, int toIndexNotValide = -1)
    {
      MainBord = mainBord;
     // Utils.MainBord = MainBord;

      //Si reprise
      // IsReprise = true;

      if ((tunNumber == "1" || tunNumber == "0") && !_isReprise)
        EmulAllPossibleMovesForFirstTurn(null, mainBord, ComputerColore, 0, -1, -1);
      else
        EmulAllPossibleMovesFor(null, mainBord, ComputerColore, 0, -1, -1, fromIndexNotValide, toIndexNotValide);

      if (BestNode == null)
        MinMaxByRoot();

      Console.WriteLine($"L ZEZO : {BestNode.Level};{BestNode.Weight};{BestNode.Color}\t\t{BestNode.FromIndex}=>{BestNode.ToIndex}");
      
      return BestNode;
    }


    public List<NodeChess2> Emul(Board mainBord, string tunNumber, int fromIndexNotValide = -1, int toIndexNotValide = -1)
    {
      MainBord = mainBord;

      //Si reprise
      // IsReprise = true;

      if ((tunNumber == "1" || tunNumber == "0") && !_isReprise)
        EmulAllPossibleMovesForFirstTurn(null, mainBord, ComputerColore, 0, -1, -1);
      else
        EmulAllPossibleMovesFor(null, mainBord, ComputerColore, 0, -1, -1, fromIndexNotValide, toIndexNotValide);

      return LastNodes;
    }


    public void EmulAllPossibleMovesFor(NodeChess2 parentNode, Board board, string color, int level, int fromIndex, int toIndex, int fromIndexNotValide = -1, int toIndexNotValide = -1)
    {
      
      if (level == 0)
      {
        var node = new NodeChess2(null, board, level, color, -1, -1, ComputerColore, DeepLevel);
        node.Weight = 0;
        //LastNodes.Add(node);
        parentNode = node;
      }

      if (NotBestNode != null)
      {
        if (fromIndex == NotBestNode.FromIndex && toIndex == NotBestNode.ToIndex)
        {
          return;
        }
      }


      //Specifiques positions
      if (SpecifiBoardList != null)
      {
        foreach (var specifics in SpecifiBoardList)
        {
          //var t_board = specifics.SpecificsBoard;
          var result = IsEquals(specifics.SpecificsBoard, board);
          var nodeColor = "W";
          if (color == "W")
            nodeColor = "B";
          /* var localComputeurColor = "W";
           if (ComputerColore == "Black")
             localComputeurColor = "B";*/


          if (result)
          {
            if ((specifics.Color[0].ToString() == nodeColor) && (ComputerColore == specifics.Color[0].ToString()))
            {
              /*var resultArray0 = new int[2] { specifics.Score.Value, makeCheckmateLevel };
              return null;*/

              //si on trouve une best position
              BestNode = new NodeChess2();
              BestNode.FromIndex = fromIndex;
              BestNode.ToIndex = toIndex;
              return;
            }
            else
            {
              /*var resultArray0 = new int[2] { -specifics.Score.Value, makeCheckmateLevel };
              return null;*/
              //var score = specifics.Score.Value;
              NotBestNode = new NodeChess2();
              NotBestNode.FromIndex = fromIndex;
              NotBestNode.ToIndex = toIndex;
              return;
            }
          }
        }


      }





      if (level == DeepLevel)
        return;
      level++;


      //Pour T67
      /*  var isInChess = board.IsInChess(color);
        var opinionColor = "W";
        if (ComputerColore == "W")
          opinionColor = "B";
      */


      //si menacer au prochain tour
      //Pour T29 et T67
      /*   if (level == 1 && !isInChess && _isChessInNextLevel==false)
         {
           _isChessInNextLevel = board.IsInChessInNextLevel(ComputerColore);
         }
      */


      var pawns = board.GetCasesIndexForColor(color);
      // var opinionIsInChess = board.IsInChess(opinionColor);
      foreach (var index in pawns)
      {
       // _oldW = -9000;
        
        var elementInIndex = board.GetCases().ElementAt(index);

        if(DeepLevel == 4)
        {
          if (elementInIndex.Contains("Q") && level == 4)
            continue;
        }
      
        var possiblesMoves = board.GetPossibleMoves(index, level).Select(x=>x.Index);
        foreach (var movedIndex in possiblesMoves)
        {
          ////Console.WriteLine($"{index} => {movedIndex}");
          ////Console.WriteLine($"\t L : {level}");
          var copyAndMovingBord = Utils.CloneAndMove(board, index, movedIndex, level);


          /////copyAndMovingBord.Print();
          //si Board est menacer et copyAndMovingBord aussi mencer, on ne l'éxpoite plus

          /*  if (!_isChessInNextLevel)
            {
              if (isInChess && !opinionIsInChess)
              {
                if (copyAndMovingBord.IsInChess(color))
                {
                  continue;
                }
              }
            }*/






          if (fromIndexNotValide != -1 && toIndexNotValide != -1)
          {
            if (index == fromIndexNotValide && movedIndex == toIndexNotValide)
              continue;
          }

          //Ajout des neuds
          var newNode = new NodeChess2(parentNode, copyAndMovingBord, level, color, index, movedIndex, ComputerColore, DeepLevel);
          parentNode.ChildList.Add(newNode);


          if (newNode.Level == DeepLevel)
          {

            //LastNodes.Add(newNode);

          /*  if (_oldW < newNode.Weight)
            {*/
              LastNodes.Add(newNode);
             // _oldW = newNode.Weight;
          //  }



          }





          var newColor = "B";
          if (color == "B")
            newColor = "W";
          EmulAllPossibleMovesFor(newNode, copyAndMovingBord, newColor, level, index, movedIndex);
        }
      }
      // }




    }

    public void EmulAllPossibleMovesForFirstTurn(NodeChess2 parentNode, Board board, string color, int level, int fromIndex, int toIndex)
    {

      var randomNodes = new List<NodeChess2>();
      if (level == 0)
      {
        var node = new NodeChess2(null, board, level, color, -1, -1, ComputerColore, DeepLevel);
        node.Weight = 0;
        //LastNodes.Add(node);
        parentNode = node;
      }


      if (level == DeepLevel)
        return;
      level++;
      var pawns = board.GetCasesIndexForColor(color);

      foreach (var index in pawns)
      {

        //_oldW = -9000;
        var possiblesMoves = board.GetPossibleMoves(index, level).Select(x=>x.Index);
        foreach (var movedIndex in possiblesMoves)
        {
          ////Console.WriteLine($"{index} => {movedIndex}");
          ////Console.WriteLine($"\t L : {level}");
          var copyAndMovingBord = Utils.CloneAndMove(board, index, movedIndex, level);
          /////copyAndMovingBord.Print();

          //Ajout des neuds
          var newNode = new NodeChess2(parentNode, copyAndMovingBord, level, color, index, movedIndex, ComputerColore, DeepLevel);
          randomNodes.Add(newNode);
          // Nodes.Add(newNode);




        }





      }

      var rand = new Random();
      BestNode = randomNodes[rand.Next(randomNodes.Count())];
    }


    public void PrintAllNode()
    {
      foreach (var node in LastNodes)
      {
        //if(node.Level == 3)
        Console.WriteLine($"l : {node.Level}\tcolor: {node.Color}\tWeight:{node.Weight}\t\t{node.FromIndex}=>{node.ToIndex}");
      }
    }





    //retour le position du roi
    public int GetKingAlierIndex(Board board)
    {






      var kingIndex = board.GetKingColorIndex(ComputerColore);

      return kingIndex;








    }

    public List<NodeChess2> GetParentListAndMinMax2(List<NodeChess2> nodesIn, int level)
    {
      var oldParent = new NodeChess2();
      List<NodeChess2> parentLevelList = new List<NodeChess2>();

      foreach (var node in nodesIn)//Remplissage des parent
      {
        var currentParent = node.Parent;
        if (oldParent == currentParent)
        {
          parentLevelList.Add(currentParent);

        }
        else
          oldParent = currentParent;


      }

      //Pour tous les parentLevel5List
      //MAX
      foreach (var parent in parentLevelList)
      // Parallel.ForEach(parentLevelList, parent =>
      {
        if ((level % 2) == 1)//MAX
      {


      


          var maxWeight = parent.ChildList.Max(x => x.Weight);
          parent.Weight = maxWeight;



        }//);
        if (level == 1)
        {



         




            //Pour T80 et T81
           // parent.ChildList.RemoveAll(x => Chess2ConsoleChess2Console.Utils.ComputerKingIsMenaced(x.Board));

            //Pour 82
            //pour eviter le nulle on enleve evite de refaire les memes actions
            //on rend les 6 dérnier action



            var maxWeith = parent.ChildList.Min(x => x.Weight);

            // if (maxWeith == 999)
            maxWeith = parent.ChildList.Where(x => !Utils.KingIsMenaced(x.Board,Utils.ComputerColor)).Max(x => x.Weight);

            var maxNodeList = parent.ChildList.Where(x => x.Weight == maxWeith).ToList();

            // var t_maxNode = maxNodeList.First();
            // Chess2ConsoleChess2Console.Utils.ComputerKingIsMenaced( t_maxNode.Board);
            if (maxNodeList.Count != 0)
            {



              var maxNode = new NodeChess2();
              if (maxNodeList.Count() == 1)
                maxNode = maxNodeList.First();






              else
              {

                var rand = new Random();
                maxNode = maxNodeList[rand.Next(maxNodeList.Count())];
                maxNode.RandomEquivalentList = maxNodeList;

              }



              parent.BestNode = maxNode;
              break;
            }

         
        }
      
      else//MIN
      {
        //if (level == 4)
        //{
        //  foreach (var parent in parentLevelList)
        //  {
        //    parent.Weight = parent.ChildList.Max(x => x.Weight);
        //  }
        //}
        //else
        //{




       
          parent.Weight = parent.ChildList.Min(x => x.Weight);
        }






        // }

      }



      level--;


      if (level == 0)
        return parentLevelList;
      else
        return GetParentListAndMinMax2(parentLevelList, level);




    }

    public List<NodeChess2> GetParentListAndMinMax(List<NodeChess2> nodesIn, int level)
    {
      var oldParent = new NodeChess2();
      List<NodeChess2> parentLevelList = new List<NodeChess2>();
      
      foreach (var node in nodesIn)//Remplissage des parent
      {
        var currentParent = node.Parent;
        if (oldParent == currentParent)
        {
          parentLevelList.Add(currentParent);

        }
        else
          oldParent = currentParent;


      }

      //Pour tous les parentLevel5List
      //MAX

      if ((level % 2) == 1)//MAX
      {


        foreach (var parent in parentLevelList)
        // Parallel.ForEach(parentLevelList, parent =>
        {
      

          var maxWeight = parent.ChildList.Max(x => x.Weight);
          parent.Weight = maxWeight;



        }//);
        if (level == 1)
        {


          
          foreach (var parent in parentLevelList)
          {

            //TODO A TESTER
            for (int i = 0; i < parent.ChildList.Count; i++)
            {
              var child = parent.ChildList[i];
              //Si kingIsInChess
              var opinionColor = "W";
              if (Utils.ComputerColor == "W")
                opinionColor = "B";
              if (Utils.KingIsInChess(child.Board, Utils.ComputerColor))
              {
                child.Weight = -999;

              }

              if (Utils.KingIsInChess(child.Board, opinionColor))
              {
                child.Weight = 999;

              }
            }
            


            //Pour T80 et T81
            parent.ChildList.RemoveAll(x => Utils.KingIsMenaced(x.Board, Utils.ComputerColor));

            //Pour 82
            //pour eviter le nulle on enleve evite de refaire les memes actions
            //on rend les 6 dérnier action
            var sixLastAction = new List<string>();
            if (Utils.MovingList != null)
            {
              if (Utils.MovingList.Count >= 6)
              {
                sixLastAction = Utils.MovingList.Skip(Math.Max(0, Utils.MovingList.Count() - 6)).ToList();
                var opinionRepetitionCount = 0;
                var repetionOpinionMove = "";
                var cumputerRepetitionCount = 0;
                var repetionCumputerMove = "";

                foreach (var item in sixLastAction)
                {

                  if (item.Contains($"{ComputerColore})"))
                  {
                    cumputerRepetitionCount = sixLastAction.Where(x => x == item).Count();
                    if (cumputerRepetitionCount > 1)
                      repetionCumputerMove = item;

                  }

                  if (item.Contains($"{GetOpinionColor()})"))
                  {
                    opinionRepetitionCount = sixLastAction.Where(x => x == item).Count();
                    if (opinionRepetitionCount > 1)
                      repetionOpinionMove = item;

                  }
                }

                //si il y a repetition
                if (opinionRepetitionCount == 2 && cumputerRepetitionCount == 2)
                {
                  //on prend l'élement à ne pas répeter
                  sixLastAction.RemoveAll(x => x.Contains($"{GetOpinionColor()})") || x == repetionCumputerMove || x == repetionOpinionMove);
                  if (sixLastAction.Count == 1)
                  {
                    var toRemoveCumputerMove = sixLastAction.First();


                    //on doit enlever toRemovecumputerMove de parent.ChildList pour éviter la répétition
                    //  "61(Q|B)>53(__)"
                    var data = toRemoveCumputerMove.Split('>');

                    var fromIndexToRemove = data[0].Substring(0, data[0].IndexOf("("));
                    var toIndexToRemove = data[1].Substring(0, data[1].IndexOf("("));

                    parent.ChildList.RemoveAll(x => x.FromIndex == Int32.Parse(fromIndexToRemove) && x.ToIndex == Int32.Parse(toIndexToRemove));

                  }



                }
              }

            }


            //si ChildList.count ==0 => on l'ia a perdu
            if(parent.ChildList.Count ==0)
            {
              //var t_ = "echec";
              var loseNode = new NodeChess2();
              loseNode.Weight = -999;
              parent.BestNode = loseNode;
              break;
            }
              


            var maxWeith = parent.ChildList.Max(x => x.Weight);

            // if (maxWeith == 999)
            maxWeith = parent.ChildList.Where(x => !Utils.KingIsMenaced(x.Board, Utils.ComputerColor)).Max(x => x.Weight);

            var maxNodeList = parent.ChildList.Where(x => x.Weight == maxWeith).ToList();

            // var t_maxNode = maxNodeList.First();
            // Chess2ConsoleChess2Console.Utils.ComputerKingIsMenaced( t_maxNode.Board);
            if (maxNodeList.Count != 0)
            {



              var maxNode = new NodeChess2();
              if (maxNodeList.Count() == 1)
                maxNode = maxNodeList.First();



           


              else
              {

                //pour T35 et T54A
                for (int i = 0; i < maxNodeList.Count; i++)
                {


                  var item = maxNodeList[i];
                  if (item.Board.DestinationIndexIsMenaced)
                  {
                    //item.Weight -= 1;
                    item.Weight -= 1;// .Remove(item);
                  }
                }
                maxWeith = maxNodeList.Max(x => x.Weight);

                 maxNodeList = maxNodeList.Where(x => x.Weight == maxWeith).ToList();

                //si on ne trouve pas, on prend les maxNodeList
                //et le les imule de 2 level
                var movinListCount = 0;
                if (Utils.MovingList != null)
                {
                  movinListCount = Utils.MovingList.Count;
                }
                  if (IsSecond && (_isInTest || movinListCount > 5))
                  {
                    
                    
                      //Pour T32
                      //lancement d'un deuxiemme niveau
                      List<double[]> secondResultsList = new List<double[]>();
                      // List<NodeChess2> secondeNodesList = new List<NodeChess2>();

                      //List<NodeChess2> best2List = new List<NodeChess2>();
                      foreach (var node in maxNodeList)
                      {

                        //emuler jusqu'au niveau 2

                        var engine = new Engine(2, OpinionrColore, true, null);
                        engine.IsSecond = false;
                        var currentLastNodeList = engine.Emul(node.Board, "5", -1, -1);

                        var currentMaxW = currentLastNodeList.Max(x => x.Weight);
                        //int[] containte[ = 
                        //  secondResultsList.Add($"{currentMaxW}:{node.FromIndex}:{node.ToIndex}");

                        double[] array = new double[] { currentMaxW, node.FromIndex, node.ToIndex };
                        secondResultsList.Add(array);

                      }


                      //on prend le plus petit des poids car on silule le pion adverse
                      var minSeoncd = secondResultsList.OrderBy(x => x[0]).First();
                      var secondBestToIndex = minSeoncd[2];


                      //on ne garde de les min de l'adverse (les max du cpu)
                      maxNodeList.RemoveAll(x => x.ToIndex != secondBestToIndex);
                    }
                  

                

                var rand = new Random();
                maxNode = maxNodeList[rand.Next(maxNodeList.Count())];
                maxNode.RandomEquivalentList = maxNodeList;

              }



              parent.BestNode = maxNode;
              break;
            }

          };
        }
      }
      else//MIN
      {
        //if (level == 4)
        //{
        //  foreach (var parent in parentLevelList)
        //  {
        //    parent.Weight = parent.ChildList.Max(x => x.Weight);
        //  }
        //}
        //else
        //{

       

        
          foreach (var parent in parentLevelList)
          {
            parent.Weight = parent.ChildList.Min(x => x.Weight);
          }
        
       
       
       


       // }
         
      }



      level--;

      
        if (level == 0)
          return parentLevelList;
        else
          return GetParentListAndMinMax(parentLevelList, level);
    



    }

    public string GetOpinionColor()
    {
      if (ComputerColore == "W")
        return "B";
      else
        return "W";
    }

    public void MinMaxByRoot()
    {


      //var maxW = LastNodes.Max(x => x.Weight);
      var parentLevel1List = GetParentListAndMinMax(LastNodes, DeepLevel);



     /* foreach (var item in parentLevel1List)
      {
        foreach (var childNode in item.ChildList)
        {
          level1NodeList.Add(childNode);
        }
      }*/


      //pour éviter le NULL, on enleve les mouvement qui on déjà été faites
      //parentLevel1List.RemoveAll(x => x.BestNode.FromIndex == fromIndexNotValide && x.BestNode.ToIndex == toIndexNotValide);


      //var noteValideMove = 
     
        var nodeZero = parentLevel1List.First();
        BestNode = nodeZero.BestNode;


     
     
    }





    public void PrintAllPossiblePossiblesPositionFromColor(Board board, string color)
    {
      var pawns = board.GetCasesIndexForColor(color);
      foreach (var index in pawns)
      {
        PrintAllPossiblePossiblesPositionFromOncePosition(board, index);
      }
    }

    public void PrintAllPossiblePossiblesPositionFromOncePosition(Board board, int initalPosition)
    {
      var possiblesIndex = board.GetPossibleMoves(initalPosition, 1);
      Console.WriteLine($"POSSIBLES POSITION FOR {initalPosition} :");
      foreach (var index in possiblesIndex)
      {
        Console.WriteLine($"\t{index}");
      }

    }

  }

 
}