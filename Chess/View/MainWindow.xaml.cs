using Chess.Utils;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using System.Threading;
using System.Windows.Threading;
using System.IO;
using System.ComponentModel;
using Chess.View;
using System.Net;
using System.Net.Sockets;
using ToastNotifications;
using ToastNotifications.Position;
using ToastNotifications.Lifetime;
using ToastNotifications.Messages;
using Notifications.Wpf;
using Chess.Model;
using Chess.Entity;
using System.Drawing.Printing;
using System.Printing;
using Microsoft.WindowsAPICodePack.Dialogs;
using Path = System.IO.Path;
using Chess2Console;

namespace Chess
{
  /// <summary>
  /// Interaction logic for MainWindow.xaml
  /// </summary>
  public partial class MainWindow : Window
  {


    #region Properties
    public int DeeLevel { get; set; } = 4;

    public bool IsReprise { get; set; } = false;
    public List<SpecificPositions> SpecificPositionsList { get; set; }

    public List<SpecificBoard> SpecifiBoardList { get; set; }


    public List<Case> CaseList { get; set; }

    public List<Pawn> PawnList { get; set; }
    private List<string> _deadList;



    Notifier Notifier { get; set; }
    NotificationManager NotificationManagerWindows { get; set; }


    // public List<Pawn> TempsPawnList { get; set; }
    public List<Pawn> PawnListWhite { get; set; }
    public List<Pawn> PawnListBlack { get; set; }

    public Pawn SelectedPawn { get; set; }

    public string FromPosition { get; set; }
    public string ToPosition { get; set; }

    private string _currentTurn;


    /*tsiry;28-05-2021
 * creation de l'historique
 * */
    public List<List<string>> HistoricalWhiteList { get; set; } //une liste de liste de Pawn qui servira d'hystorique
    public List<List<string>> HistoricalBlackList { get; set; } //une liste de liste de Pawn qui servira d'hystorique

    public string ComputerColore
    {
      get => _computerColore;
      set
      {
        _computerColore = value;
        PreviousButon.IsEnabled = true && _isConnectedDB;


      }
    }

    public string CurrentTurn
    {
      get => _currentTurn;
      set
      {
        //_watch.Stop();
        GC.Collect();
        var dateTimeDiff00 = DateTime.Now - _dateTimeCount;
        Debug.WriteLine($"Execution Time: {dateTimeDiff00} ms");
        _dateTimeCount = DateTime.Now;



        // var currentTimeStart = DateTime.Now;
        lbBlackScore.Content = GetScore("Black");
        lbWhiteScore.Content = GetScore("White");
        //DoSomething();
        _currentTurn = value;
        if (CurrentTurn == "Black")
        {
          //var dateTimeDiff = DateTime.Now - _dateTimeCount;
          //Debug.WriteLine($"Execution Time: {_watch.ElapsedMilliseconds} ms");
          _whiteCountTime = _whiteCountTime.AddMilliseconds(dateTimeDiff00.TotalMilliseconds);
          lbWhiteTime.Content = String.Format("{0:HH:mm:ss}", _whiteCountTime);

          // _watch.Start();

          BlackTurnButton.Visibility = Visibility.Visible;
          WhiteTurnButton.Visibility = Visibility.Hidden;
          /*if (_whiteTimer != null)
            _whiteTimer.Stop();
          startOrContinuBlackTimer();*/
          ////PythonTurnButon.IsEnabled = true;

        }

        if (CurrentTurn == "White")
        {
          //var dateTimeDiff = DateTime.Now - _dateTimeCount;


          _blackCountTime = _blackCountTime.AddMilliseconds(dateTimeDiff00.TotalMilliseconds);
          lbBlackTime.Content = String.Format("{0:HH:mm:ss}", _blackCountTime);
          //_watch.Start();

          BlackTurnButton.Visibility = Visibility.Hidden;
          WhiteTurnButton.Visibility = Visibility.Visible;
          /* if (_blackTimer != null)
             _blackTimer.Stop();
           startOrContinuWhiteTimer();*/
          ////PythonTurnButon.IsEnabled = false;
        }

        /*tsiry;30-06-2021
         *implementation de la base
         *enregistrment dans la base à chaque fin de tour
         */
        if (_serviceChessDB != null)
        {
          var inseredIndex = _serviceChessDB.InserTurn(_gamePartID, PawnList, CurrentTurn) - 1;
          if (TurnNumberLabel.Content != null)
          {
            if (inseredIndex > Int32.Parse(TurnNumberLabel.Content.ToString()))
              TurnNumberLabel.Content = inseredIndex.ToString();
          }
          else
            TurnNumberLabel.Content = inseredIndex.ToString();




          PreviousButon.IsEnabled = true;
        }
        else
        {
          _turnNumber++;
          TurnNumberLabel.Content = _turnNumber.ToString();
        }

        if (_currentTurn == ComputerColore)
        {
          CpuTurnIndication.Visibility = Visibility.Visible;
          HumanTurnIndication.Visibility = Visibility.Collapsed;
          ProgressBarCpuTurnIndication.Visibility = Visibility.Visible;

        }
        else
        {
          CpuTurnIndication.Visibility = Visibility.Collapsed;
          HumanTurnIndication.Visibility = Visibility.Visible;
          ProgressBarCpuTurnIndication.Visibility = Visibility.Hidden;
        }




      }


    }


    public string GetTurnNumberLabel()
    {
      return TurnNumberLabel.Content.ToString();
    }
    public void SetTurnNumberLabel(string turnNumber)
    {
      TurnNumberLabel.Content = turnNumber;
    }


    //utile pour le sauvegarde des partie
    public static bool IsDebug
    {
      get
      {
#if DEBUG
        return true;
#else
            return false;
#endif
      }
    }
    #endregion


    #region attributs

    private bool _isConnectedDB = false;
    private int _turnNumber = -1;
    private bool _isFromStart = false;
    private bool _graveyardIsLoaded;
    private int _blackPoint = 0;
    private int _whitePoint = 0;
    private Node _lastBestNode;
    /*tsiry;01-10-2021
    * implementation de Rotation
    * */
    private bool _rotationIsRevert = false;
    public string _rotationTextTabString = "         ";

    /*tsiry;05-10-2021
 * ajout de history pour chaque partie
 * */
    private string _destinationHistoryFolderPath = @"./HistoriesFiles/";
    private string _destinationLogFolderPath = @"./LogsFiles/";
    private string _partHistoryDestinationFileFullPath;
    private string _partLogDestinationFileFullPath;



    private bool _isInLocalEgine;

    private bool _isVSPythonMode;

    //private int deepStep = 0;





    private string _computerColore;
    public int BlackTurnNumber { get; set; }
    public int WhiteTurnNumber { get; set; }

    //Timers
    private DispatcherTimer _cpuTimer;
    private DispatcherTimer _blackTimer;
    private DispatcherTimer _whiteTimer;
    private DateTime _cpuStartTime;
    private DateTime _blackCountTime;
    private DateTime _whiteCountTime;
    //private System.Diagnostics.Stopwatch _watch;

    private DateTime _dateTimeCount;

    //pour les cimetiaire
    private int _simplePawnBlackDeadNumber;
    private int _simplePawnWhiteDeadNumber;
    private int _bishopBlackDeadNumber;
    private int _bishopWhiteDeadNumber;
    private int _knighBlackDeadNumber;
    private int _knighWhiteDeadNumber;
    private int _rookBlackDeadNumber;
    private int _rookWhiteDeadNumber;
    private int _queenPawnBlackDeadNumber;
    private int _queenPawnWhiteDeadNumber;
    /*tsiry;30-06-2021
     * ajout de la base
     * */
    private int _navigationInDBIndex;
    private ServiceChessDB _serviceChessDB;
    private long _gamePartID;
    private string _mode;


    #endregion


    #region Methodes



    /*tsiry;07-05-2021
     * implémentation du cimetière
     * */

    public void AddDeadList(string deadPawn)
    {

      fillGraveyard(deadPawn);
      //SaveGraveyardList for Load
      _deadList.Add(deadPawn);

      //calcule des point
      calculatePoint();
    }
    private void calculatePoint()
    {
      var whiteDeadList = _deadList.Where(x => x.Contains("White"));
      var point = 0;
      foreach (var pawnString in whiteDeadList)
      {
        var pawnName = pawnString.Replace("White", "");

        switch (pawnName)
        {
          case "SimplePawn":
            point += 1;
            break;
          case "Knight":
            point += 3;
            break;
          case "Bishop":
            point += 3;
            break;
          case "Rook":
            point += 5;
            break;
          case "Queen":
            point += 9;
            break;
        }
      }

      _blackPoint = point;

      var blackDeadList = _deadList.Where(x => x.Contains("Black"));
      point = 0;
      foreach (var pawnString in blackDeadList)
      {
        var pawnName = pawnString.Replace("Black", "");

        switch (pawnName)
        {
          case "SimplePawn":
            point += 1;
            break;
          case "Knight":
            point += 3;
            break;
          case "Bishop":
            point += 3;
            break;
          case "Rook":
            point += 5;
            break;
          case "Queen":
            point += 9;
            break;
        }
      }

      _whitePoint = point;
      BlackPointLabel.Content = "";
      WhitePointLabel.Content = "";

      if (_blackPoint == _whitePoint)
        return;
      if (_blackPoint > _whitePoint)
      {
        var diffPoint = _blackPoint - _whitePoint;
        BlackPointLabel.Content = $"+{diffPoint}";
        return;
      }

      if (_whitePoint > _blackPoint)
      {
        var diffPoint = _whitePoint - _blackPoint;
        WhitePointLabel.Content = $"+{diffPoint}";
        return;
      }

    }
    private void fillGraveyard(string deadPawn)
    {
      try
      {


        //BLACK
        if (deadPawn.Contains("Black"))
        {

          if (deadPawn.Contains("SimplePawn"))
          {
            //SimplePawnBlack
            _simplePawnBlackDeadNumber++;
            if (_simplePawnBlackDeadNumber > 1)
            {
              SimplePawnBlackDeadNumberLabel.Content = "* " + _simplePawnBlackDeadNumber.ToString();
              if (_rotationIsRevert)
              {
                SimplePawnBlackDeadNumberLabel.Content = _rotationTextTabString + _simplePawnBlackDeadNumber.ToString() + "*";
              }



            }
            else
            {
              var dockPanel = new DockPanel();
              var image = new Image();
              image.Height = 40;
              image.Width = 40;
              image.Source = new BitmapImage(new Uri(@"/Images/" + "SimplePawnBlack.png", UriKind.Relative));
              dockPanel.Children.Add(image);
              SimplePawnBlackDeadButton.Content = dockPanel;
            }
          }
          if (deadPawn.Contains("Bishop"))
          {
            //BishopBlack
            _bishopBlackDeadNumber++;
            if (_bishopBlackDeadNumber > 1)
            {
              BishopBlackDeadNumberLabel.Content = "* " + _bishopBlackDeadNumber.ToString();

              if (_rotationIsRevert)
              {
                BishopBlackDeadNumberLabel.Content = _rotationTextTabString + _bishopBlackDeadNumber.ToString() + "*";
              }
            }
            else
            {
              var dockPanel = new DockPanel();
              var image = new Image();
              image.Height = 40;
              image.Width = 40;
              image.Source = new BitmapImage(new Uri(@"/Images/" + "BishopBlack.png", UriKind.Relative));
              dockPanel.Children.Add(image);
              BishopBlackDeadButton.Content = dockPanel;
            }
          }

          if (deadPawn.Contains("Knight"))
          {
            //KnightBlack
            _knighBlackDeadNumber++;
            if (_knighBlackDeadNumber > 1)
            {
              KnightBlackDeadNumberLabel.Content = "* " + _knighBlackDeadNumber.ToString();

              if (_rotationIsRevert)
              {
                KnightBlackDeadNumberLabel.Content = _rotationTextTabString + _knighBlackDeadNumber.ToString() + "*";
              }
            }
            else
            {
              var dockPanel = new DockPanel();
              var image = new Image();
              image.Height = 40;
              image.Width = 40;
              image.Source = new BitmapImage(new Uri(@"/Images/" + "KnightBlack.png", UriKind.Relative));
              dockPanel.Children.Add(image);
              KnightBlackDeadButton.Content = dockPanel;
            }
          }

          if (deadPawn.Contains("Rook"))
          {
            //RookBlack
            _rookBlackDeadNumber++;
            if (_rookBlackDeadNumber > 1)
            {
              RookBlackDeadNumberLabel.Content = "* " + _rookBlackDeadNumber.ToString();
              if (_rotationIsRevert)
              {
                RookBlackDeadNumberLabel.Content = _rotationTextTabString + _rookBlackDeadNumber.ToString() + "*";
              }
            }
            else
            {
              var dockPanel = new DockPanel();
              var image = new Image();
              image.Height = 40;
              image.Width = 40;
              image.Source = new BitmapImage(new Uri(@"/Images/" + "RookBlack.png", UriKind.Relative));
              dockPanel.Children.Add(image);
              RookBlackDeadButton.Content = dockPanel;
            }
          }

          if (deadPawn.Contains("Queen"))
          {
            //QueenBlack
            _queenPawnBlackDeadNumber++;
            if (_queenPawnBlackDeadNumber > 1)
            {
              QueenBlackDeadNumberLabel.Content = "* " + _queenPawnBlackDeadNumber.ToString();

              if (_rotationIsRevert)
              {
                QueenBlackDeadNumberLabel.Content = _rotationTextTabString + _queenPawnBlackDeadNumber.ToString() + "*";
              }
            }

            else
            {
              var dockPanel = new DockPanel();
              var image = new Image();
              image.Height = 40;
              image.Width = 40;
              image.Source = new BitmapImage(new Uri(@"/Images/" + "QueenBlack.png", UriKind.Relative));
              dockPanel.Children.Add(image);
              QueenBlackDeadButton.Content = dockPanel;
            }
          }

        }


        //WHITE
        if (deadPawn.Contains("White"))
        {
          if (deadPawn.Contains("SimplePawn"))
          {
            //SimplePawnWhite
            _simplePawnWhiteDeadNumber++;
            if (_simplePawnWhiteDeadNumber > 1)
            {
              SimplePawnWhiteDeadNumberLabel.Content = "* " + _simplePawnWhiteDeadNumber.ToString();

              if (_rotationIsRevert)
                SimplePawnWhiteDeadNumberLabel.Content = _rotationTextTabString + _simplePawnWhiteDeadNumber.ToString() + "*";

            }
            else
            {
              var dockPanel = new DockPanel();
              var image = new Image();
              image.Height = 40;
              image.Width = 40;
              image.Source = new BitmapImage(new Uri(@"/Images/" + "SimplePawnWhite.png", UriKind.Relative));
              dockPanel.Children.Add(image);
              SimplePawnWhiteDeadButton.Content = dockPanel;
            }


          }


          if (deadPawn.Contains("Bishop"))
          {
            //BishopWhite
            _bishopWhiteDeadNumber++;
            if (_bishopWhiteDeadNumber > 1)
            {
              BishopWhiteDeadNumberLabel.Content = "* " + _bishopWhiteDeadNumber.ToString();
              if (_rotationIsRevert)
                BishopWhiteDeadNumberLabel.Content = _rotationTextTabString + _bishopWhiteDeadNumber.ToString() + "*";

            }
            else
            {
              var dockPanel = new DockPanel();
              var image = new Image();
              image.Height = 40;
              image.Width = 40;
              image.Source = new BitmapImage(new Uri(@"/Images/" + "BishopWhite.png", UriKind.Relative));
              dockPanel.Children.Add(image);
              BishopWhiteDeadButton.Content = dockPanel;
            }


          }

          if (deadPawn.Contains("Knight"))
          {
            //KnightWhite
            _knighWhiteDeadNumber++;
            if (_knighWhiteDeadNumber > 1)
            {
              KnightWhiteDeadNumberLabel.Content = "* " + _knighWhiteDeadNumber.ToString();

              if (_rotationIsRevert)
                KnightWhiteDeadNumberLabel.Content = _rotationTextTabString + _knighWhiteDeadNumber.ToString() + "*";

            }
            else
            {
              var dockPanel = new DockPanel();
              var image = new Image();
              image.Height = 40;
              image.Width = 40;
              image.Source = new BitmapImage(new Uri(@"/Images/" + "KnightWhite.png", UriKind.Relative));
              dockPanel.Children.Add(image);
              KnightWhiteDeadButton.Content = dockPanel;
            }
          }

          if (deadPawn.Contains("Rook"))
          {
            //RookWhite
            _rookWhiteDeadNumber++;
            if (_rookWhiteDeadNumber > 1)
            {
              RookWhiteDeadNumberLabel.Content = "* " + _rookWhiteDeadNumber.ToString();

              if (_rotationIsRevert)
                RookWhiteDeadNumberLabel.Content = _rotationTextTabString + _rookWhiteDeadNumber.ToString() + "*";

            }
            else
            {
              var dockPanel = new DockPanel();
              var image = new Image();
              image.Height = 40;
              image.Width = 40;
              image.Source = new BitmapImage(new Uri(@"/Images/" + "RookWhite.png", UriKind.Relative));
              dockPanel.Children.Add(image);
              RookWhiteDeadButton.Content = dockPanel;
            }
          }

          if (deadPawn.Contains("Queen"))
          {
            //QueenWhite
            _queenPawnWhiteDeadNumber++;
            if (_queenPawnWhiteDeadNumber > 1)
            {
              QueenWhiteDeadNumberLabel.Content = "* " + _queenPawnWhiteDeadNumber.ToString();

              if (_rotationIsRevert)
                QueenWhiteDeadNumberLabel.Content = _rotationTextTabString + _queenPawnWhiteDeadNumber.ToString() + "*";

            }
            else
            {
              var dockPanel = new DockPanel();
              var image = new Image();
              image.Height = 40;
              image.Width = 40;
              image.Source = new BitmapImage(new Uri(@"/Images/" + "QueenWhite.png", UriKind.Relative));
              dockPanel.Children.Add(image);
              QueenWhiteDeadButton.Content = dockPanel;
            }


          }

        }
      }
      catch (Exception ex)
      {
        WriteInLog(ex.ToString());
      }



    }

    private void ThreadCountCPUReflectionTime()
    {
      _cpuTimer = null;
      this.Dispatcher.BeginInvoke(new Action(() =>
      {
        _cpuTimer = new DispatcherTimer(new TimeSpan(0, 0, 0, 0, 50), DispatcherPriority.Background,
                cpuTimer_Tick, Dispatcher.CurrentDispatcher); _cpuTimer.IsEnabled = true;
        _cpuStartTime = DateTime.Now;
        //lbCPUReflectionTime.Content = "Hello Geeks !";

      }));

    }
    private void cpuTimer_Tick(object sender, EventArgs e)
    {
      lbCPUReflectionTime.Content = Convert.ToString(DateTime.Now - _cpuStartTime);
    }

    private void startOrContinuBlackTimer()
    {
      Thread threadTimer = new Thread(ThreadStartOrContinuBlackTimer);
      threadTimer.Start();
    }

    private void startOrContinuWhiteTimer()
    {
      Thread threadTimer = new Thread(ThreadStartOrContinuWhiteTimer);
      threadTimer.Start();
    }

    private void ThreadStartOrContinuBlackTimer()
    {

      _blackTimer = null;
      this.Dispatcher.BeginInvoke(new Action(() =>
      {
        _blackTimer = new DispatcherTimer(new TimeSpan(0, 0, 0, 1), DispatcherPriority.Background,
                blackTimer_Tick, Dispatcher.CurrentDispatcher); _blackTimer.IsEnabled = true;
      }));

    }
    private void blackTimer_Tick(object sender, EventArgs e)
    {
      _blackCountTime = _blackCountTime.AddSeconds(1);
      lbBlackTime.Content = String.Format("{0:HH:mm:ss}", _blackCountTime);
    }

    private void ThreadStartOrContinuWhiteTimer()
    {

      _whiteTimer = null;
      this.Dispatcher.BeginInvoke(new Action(() =>
      {
        _whiteTimer = new DispatcherTimer(new TimeSpan(0, 0, 0, 1), DispatcherPriority.Background,
                whiteTimer_Tick, Dispatcher.CurrentDispatcher); _whiteTimer.IsEnabled = true;
      }));

    }
    private void whiteTimer_Tick(object sender, EventArgs e)
    {
      _whiteCountTime = _whiteCountTime.AddSeconds(1);
      lbWhiteTime.Content = String.Format("{0:HH:mm:ss}", _whiteCountTime);
    }


    public void ReActive()
    {
      //this.IsActive = true;
      if (this.WindowState == WindowState.Minimized)
        this.WindowState = WindowState.Normal;
    }

    public async Task SwithTurnAsync()
    {

      //// GC.Collect();
      //GC.WaitForPendingFinalizers();
      if (this.WindowState == WindowState.Minimized)
      {
        if (ComputerColore == CurrentTurn)
        {
          //Notification sur l'application
          //Notifier.ShowInformation("Move completed");

          //notification dans la bare de tache

          /* Your code here */
          NotificationManagerWindows.Show(new NotificationContent
          {
            Title = "Chess notification",
            Message = $"CPU ({ComputerColore}) move completed",
            Type = NotificationType.Information
          }, onClick: () => ReActive()/*,
               onClose: () => ReActive()*/);




          /* NotificationManagerWindows.Show("String notification", onClick: () => ReActive(),
                  onClose: () => ReActive());*/
          //NotificationManagerWindows = null;
        }


      }



      if (CurrentTurn == "White")
      {
        WhiteTurnNumber++;
        CurrentTurn = "Black";

        if (ComputerColore == CurrentTurn)
        {
          //await Task.Delay(100);
          GetBestPositionAndMoveFor(CurrentTurn);
        }




      }
      else
      {
        BlackTurnNumber++;
        CurrentTurn = "White";
        //searchAndExecuteBestMove(PawnListBlack);
        if (ComputerColore == CurrentTurn)
        {
          //await Task.Delay(100);
          GetBestPositionAndMoveFor(CurrentTurn);
        }


      }




      Save(PawnList);


      // var t0 = PawnList.Count;
      LoadOld();
      // System.GC.Collect();
      // GC.WaitForPendingFinalizers();



    }
    public void FillAllPossibleTrips()
    {
      foreach (var pawn in PawnList)
      {
        pawn.FillPossibleTrips();
      }
    }

    public void SetDefaultColoreAllCases()
    {
      foreach (var item in CaseList)
      {
        item.SetDefaultColore();
      }
    }

    public void SetOldPositionColore(string location)
    {
      var oldCase = GetCase(location);
      oldCase.SetOldPositionColore();

    }
    public Pawn GetPawn(string location, List<Pawn> currentPawnList = null)
    {

      /*if(isFromTemps)
       */
      /* if (TempsPawnList != null)
         return TempsPawnList.FirstOrDefault(x => x.Location == location);
       else
         return null;///PawnList.FirstOrDefault(x => x.Location == location);
       /* else*/
      if (currentPawnList == null)
        return PawnList.FirstOrDefault(x => x.Location == location);
      else
        return currentPawnList.FirstOrDefault(x => x.Location == location);

    }
    public List<Pawn> GetOpignonPawnList(string colore)
    {
      if (colore == "Black")
        return PawnListWhite;
      else
        return PawnListBlack;
    }


    public Pawn GetKing(string colore)
    {
      return PawnList.FirstOrDefault(x => x.Colore == colore && x.Name == "King");
    }
    public Pawn GetRightRook(string colore)
    {
      return PawnList.FirstOrDefault(x => x.Colore == colore && x.Name == "Rook" && x.X == "h");
    }
    public Pawn GetLeftRook(string colore)
    {
      return PawnList.FirstOrDefault(x => x.Colore == colore && x.Name == "Rook" && x.X == "a");
    }
    public Case GetCase(string location)
    {
      return CaseList.FirstOrDefault(x => x.CaseName == location);
    }

    private void button1_Click(object sender, EventArgs e)
    {
      var buttonSender = (Button)sender;
    }

    private void WhiteGiveUp_Click(object sender, RoutedEventArgs e)
    {
      MessageBox.Show("BLACK WIN");
      //System.Windows.Forms.Application.Restart();

      System.Diagnostics.Process.Start(Application.ResourceAssembly.Location);
      Application.Current.Shutdown();
    }



    private void BlackGiveUp_Click(object sender, RoutedEventArgs e)
    {
      MessageBox.Show("WHITE WIN");
      //System.Windows.Forms.Application.Restart();

      System.Diagnostics.Process.Start(Application.ResourceAssembly.Location);
      Application.Current.Shutdown();
    }

    public void Win(string colore)
    {
      MessageBox.Show($"{colore} WIN");
      //System.Windows.Forms.Application.Restart();

      System.Diagnostics.Process.Start(Application.ResourceAssembly.Location);
      Application.Current.Shutdown();
    }

    public void MoveTo(string fromPosition, string toPosition)
    {


      var fromPawn = this.GetPawn(fromPosition);
      var toCase = this.GetCase(toPosition);



      //gestion du roc
      if (fromPawn.PossibleTrips.Contains(toPosition))
      {

        if (fromPawn.Name == "Rook")
        {
          //pour le roc, il faut prend le roi et emplecher le roc déplacement
          var associateKing = this.GetKing(fromPawn.Colore);

          if (fromPawn.X == "a")
            associateKing.IsLeftRookFirstMove = false;
          if (fromPawn.X == "h")
            associateKing.IsRightRookFirstMove = false;


        }

        //if (this.SelectedPawn == null)
        //this.SelectedPawn = fromPawn;
        fromPawn.Move(toCase);
      }




      // Chess2Console.Utils.MovingList.Add

      this.FromPosition = "";
      this.ToPosition = "";

      if (_isVSPythonMode)
      {
        // System.Threading.Thread.Sleep(10000);
        VSPythonMoveTo(fromPosition + toPosition);
      }
      // Thread.Sleep(TimeSpan.FromSeconds(5));
      // System.GC.Collect();

      /////System.GC.Collect();
    }

    public (string minPosition, int minScore, string maxPosition, int maxScore, string bestPosition) Emulate(string initialPosition, string newPosition, List<Pawn> initialPawnsList)
    {
      // if (maxDeepStep == 5)
      //  return("", 0, "", 0);
      //maxDeepStep++;
      List<Pawn> depPawnsList = new List<Pawn>();
      depPawnsList.AddRange(initialPawnsList);
      Pawn selectedPawn = new Pawn();
      selectedPawn = pawnGetPawnsInList(depPawnsList, initialPosition);
      var destinationPawn = pawnGetPawnsInList(depPawnsList, newPosition);
      if (destinationPawn != null)
      {
        depPawnsList.Remove(destinationPawn);
      }
      selectedPawn.Location = newPosition;
      selectedPawn.X = newPosition[0].ToString();
      selectedPawn.Y = newPosition[1].ToString();

      selectedPawn.FillPossibleTrips();
      selectedPawn.EvaluateScorePossibleTrips();



      //on regarde les scores de la nouvelle position
      var maxScore = 0;
      var maxPosition = "";
      var position = "";
      var score = 0;

      for (int i = 0; i < selectedPawn.PossibleTrips.Count; i++)
      {
        position = selectedPawn.PossibleTrips[i];
        score = selectedPawn.PossibleTripsScore[i];
        if (score >= maxScore)
        {
          maxScore = score;
          maxPosition = position;
        }
      }


      var minScore = 0;
      var minPosition = "";



      for (int i = 0; i < selectedPawn.PossibleTrips.Count; i++)
      {
        position = selectedPawn.PossibleTrips[i];
        score = selectedPawn.PossibleTripsScore[i];
        if (score <= minScore)
        {
          minScore = score;
          minPosition = position;
        }
      }





      //fin, on reinitalise
      selectedPawn.Location = initialPosition;
      selectedPawn.X = initialPosition[0].ToString();
      selectedPawn.Y = initialPosition[1].ToString();

      selectedPawn.FillPossibleTrips();
      selectedPawn.EvaluateScorePossibleTrips();
      //selectedPawn.PossibleTrips = initialPossibleTrips;




      return (minPosition, minScore, maxPosition, maxScore, newPosition);

    }



    private Pawn pawnGetPawnsInList(List<Pawn> pawnsList, string position)
    {
      return pawnsList.FirstOrDefault(x => x.Location == position);
    }

    private (string initialPosition, string destionitionPosition, int score) elulateAll(List<Pawn> pawnList)
    {


      foreach (var pawn in pawnList)
      {
        pawn.EmulateAllPossibleTips();
      }

      foreach (var pawn in pawnList)
      {
        var t = pawn.MinPosition;
        var tm = pawn.MaxPosition;
      }

      var minScorePawn = pawnList.OrderBy(x => x.MinScore).First();
      var maxScorePawn = pawnList.OrderByDescending(x => x.MaxScore).First();
      minScorePawn.FillPossibleTrips();

      //MoveTo(minScorePawn.Location, minScorePawn.MinPosition);
      //MoveTo(maxScorePawn.Location, maxScorePawn.BestPositionAfterEmul);
      return (maxScorePawn.Location, maxScorePawn.BestPositionAfterEmul, maxScorePawn.MaxScore);
    }

    private (string initialPosition, string destionitionPosition, int score) searchAndExecuteBestMove(List<Pawn> pawnList)
    {
      //pour tous le pion de la list
      //on avalue les scrore pour chque déplacement
      //Pawn selectedPawn = new Pawn();

      dynamic bestPawn = null;
      var allMaxScore = 0;
      var allBestPosition = "";
      var pawnListInOrder = pawnList.OrderBy(x => x.PossibleTrips.Count);

      foreach (var pawn in pawnListInOrder)
      {
        var maxScore = 0;
        var maxPosition = "";
        pawn.EvaluateScorePossibleTrips();
        var position = "";
        var score = 0;

        for (int i = 0; i < pawn.PossibleTrips.Count; i++)
        {
          position = pawn.PossibleTrips[i];
          score = pawn.PossibleTripsScore[i];
          if (score >= maxScore)
          {
            maxScore = score;
            maxPosition = position;
          }
        }


        if (maxScore >= allMaxScore)
        {
          allMaxScore = maxScore;
          bestPawn = pawn;
          allBestPosition = maxPosition;
        }

      }
      //le pion à deplacer est celui qui a le milleur score
      //et il sera déplacer vers la position du milleur score
      

      //ajout d'un hazar
      if (allMaxScore == 0)//si tout les score sont à 0
      {
        var ls = pawnList.Where(x => x.PossibleTrips.Count > 0).ToList();
        Random rnd = new Random();
        int index = rnd.Next(0, ls.Count);
        bestPawn = ls.ElementAt(index);

        // bestPawn = ls[Random.Range(0, ls.Count)];
      }


      //MoveTo(((Pawn)bestPawn).Location, allBestPosition);
      return (((Pawn)bestPawn).Location, allBestPosition, allMaxScore);
    }

    /*tsiry;06-09-2021
          * verifie si peut mettre en echec en une mouvement
          * utile pour faire passer T07 et T56
          * */
    public bool GetIsInChessInLevel1(List<Pawn> currentList, string color)
    {
      var opinionList = currentList.Where(x => x.Colore != color);
      foreach (var opinionPawn in opinionList)
      {
        var initialPosition = opinionPawn.Location;
        for (int i = 0; i < opinionPawn.PossibleTrips.Count; i++)
        {
          //deep++;
          var evaluatePosition = opinionPawn.PossibleTrips[i];

          //si evaluatePosition est menacer, on continu
          /* var menacedColor = "White";
           if (ComputerColore == "White")
             menacedColor = "Black";
           var t_isMenaced = LoactionIsMenaced(evaluatePosition, "", currentList);
           if(t_isMenaced)
           {
             var t_ = t_isMenaced;
             continue;
           }  
           */

          var depPawnsList = copyPawnList(PawnList);
          var selectedPawn = pawnGetPawnsInList(depPawnsList, initialPosition);


          var destinationPawn = pawnGetPawnsInList(depPawnsList, evaluatePosition);
          if (destinationPawn != null)
          {
            depPawnsList.Remove(destinationPawn);


          }
          selectedPawn.Location = evaluatePosition;

          foreach (var panw in depPawnsList)
          {
            panw.FillPossibleTrips();
          }

          if (isInChess(depPawnsList, color))
            return true;
        }


      }

      return false;
    }

    /*tsiry;02-09-2021
     * Verifie si une position possible d'un pion adverse est menacée
     * pour T56
     * */
    public List<string> GetAllPossibleTimpsAttackFor(string color, List<Pawn> currentList)
    {
      var alierPawnList = currentList.Where(x => x.Colore == color);
      var result = new List<string>();
      foreach (var pawn in alierPawnList)
      {

        foreach (var possibleLocation in pawn.PossibleTrips)
        {
          //si SimplePawn, on ne prend que les diagonales
          if (isSimplePawnAndInSameLine(pawn.Name, pawn.Location, possibleLocation))
            continue;

          result.Add(possibleLocation);
        }
        //result.AddRange(pawn.PossibleTrips);
      }

      return result;
    }
    /*tsiry;02-09-2021
     * cette fonction verifie si les deux positions sont sur le meme ligne
     * pour completer GetAllPossibleTimpsAttackFor pour les SimplePawn 
     * car les SimplePawn ne peuvent attaquer qu'on diagonale
   * */
    private bool isSimplePawnAndInSameLine(string pawnName, string location1, string location2)
    {
      if (pawnName != "SimplePawn")
        return false;
      if (location1[0] == location2[0])
        return true;
      return false;
    }

    /*tsiry;02-09-2021
     * verifie si le roi et un autre pion majeur sont menacés au tour suivant de l'adversaire
     * Pour T56
     * */
    public bool GetIsMancedInLevel2(List<Pawn> currentList)
    {
      var opinionList = currentList.Where(x => x.Colore != ComputerColore);
      foreach (var opinionPawn in opinionList)
      {
        var initialPosition = opinionPawn.Location;
        for (int i = 0; i < opinionPawn.PossibleTrips.Count; i++)
        {
          //deep++;
          var evaluatePosition = opinionPawn.PossibleTrips[i];



          //si evaluatePosition est menacer, on continu
          var allAllPossibleTimps = GetAllPossibleTimpsAttackFor(ComputerColore, currentList);
          if (allAllPossibleTimps.Contains(evaluatePosition))
            continue;


          var menacedColor = "White";
          if (ComputerColore == "White")
            menacedColor = "Black";
          if (LoactionIsProtected(initialPosition, evaluatePosition, menacedColor, currentList))
            continue;




          var depPawnsList = copyPawnList(PawnList);
          var selectedPawn = pawnGetPawnsInList(depPawnsList, initialPosition);


          var destinationPawn = pawnGetPawnsInList(depPawnsList, evaluatePosition);
          if (destinationPawn != null)
          {
            depPawnsList.Remove(destinationPawn);


          }
          selectedPawn.Location = evaluatePosition;

          foreach (var panw in depPawnsList)
          {
            panw.FillPossibleTrips();
          }

          var menacedList = GetMenacedList(depPawnsList, ComputerColore);
          var kingMenaced = menacedList.FirstOrDefault(x => x.Name == "King");
          if (kingMenaced != null)
          {
            var menacedListwithOutSimplePawn = menacedList.Where(x => x.Name != "SimplePawn");
            if (menacedListwithOutSimplePawn.Count() > 1)
              return true;



          }







        }


      }



      return false;
    }

    public bool LoactionIsMenaced(string location, string colore, List<Pawn> currentList)
    {

      var result = false;
      var opignionList = currentList.Where(x => x.Colore != colore);
      foreach (var pawn in opignionList)
      {
        if (pawn.Name == "SimplePawn")
        {
          //si simple pion on prend les diagonaux avant
          var toAdd = 0;
          if (pawn.Colore == "White")
          {
            toAdd = +1;

          }
          else
          {
            toAdd = -1;
          }
          var xasciiCode = (int)Convert.ToChar(pawn.X);
          var intY = 0;
          //Int32.Parse(Y);
          bool success = Int32.TryParse(pawn.Y, out intY);
          var tripsPosition = Convert.ToChar(xasciiCode - 1).ToString() + (intY + toAdd).ToString();
          if (tripsPosition == location)
            return true;
          tripsPosition = Convert.ToChar(xasciiCode + 1).ToString() + (intY + toAdd).ToString();
          if (tripsPosition == location)
            return true;

        }
        if (pawn.PossibleTrips.Contains(location))
        {
          result = true;
          break;
        }
      }
      return result;

    }
    /*tsiry;27-08-2021
       * pour déterminer si un pion est protégé
       * */
    public bool LoactionIsProtected(string actualLocation, string movingLoaction, string colore, List<Pawn> currentList)
    {

      var result = false;
      var tmpList = copyPawnList(currentList);

      var locationPawn = tmpList.FirstOrDefault(x => x.Location == actualLocation);
      locationPawn.Location = movingLoaction;



      if (colore == "White")
        locationPawn.Colore = "Black";
      else
        locationPawn.Colore = "White";
      var alierList = tmpList.Where(x => x.Colore == colore);

      foreach (var pawn in alierList)
      {
        pawn.FillPossibleTrips(tmpList);

        if (pawn.Name == "SimplePawn")
        {
          //si simple pion on prend les diagonaux avant
          var toAdd = 0;
          if (pawn.Colore == "White")
          {
            toAdd = +1;

          }
          else
          {
            toAdd = -1;
          }
          var xasciiCode = (int)Convert.ToChar(pawn.X);
          var intY = 0;
          //Int32.Parse(Y);
          bool success = Int32.TryParse(pawn.Y, out intY);
          var tripsPosition = Convert.ToChar(xasciiCode - 1).ToString() + (intY + toAdd).ToString();
          if (tripsPosition == movingLoaction)
            return true;
          tripsPosition = Convert.ToChar(xasciiCode + 1).ToString() + (intY + toAdd).ToString();
          if (tripsPosition == movingLoaction)
            return true;

        }
        if (pawn.PossibleTrips.Contains(movingLoaction))
        {
          if (!isSimplePawnAndInSameLine(pawn.Name, pawn.Location, movingLoaction))
          {
            result = true;
            break;
          }


        }
      }
      return result;

    }

    public bool LoactionIsMenaced(string location, string colore)
    {

      var result = false;
      foreach (var pawn in GetOpignonPawnList(colore))
      {


        if (pawn.Name == "SimplePawn")
        {
          //si simple pion on prend les diagonaux avant
          var toAdd = 0;
          if (pawn.Colore == "White")
          {
            toAdd = +1;

          }
          else
          {
            toAdd = -1;
          }
          var xasciiCode = (int)Convert.ToChar(pawn.X);
          var intY = 0;
          //Int32.Parse(Y);
          bool success = Int32.TryParse(pawn.Y, out intY);
          var tripsPosition = Convert.ToChar(xasciiCode - 1).ToString() + (intY + toAdd).ToString();
          if (tripsPosition == location)
            return true;
          tripsPosition = Convert.ToChar(xasciiCode + 1).ToString() + (intY + toAdd).ToString();
          if (tripsPosition == location)
            return true;

        }
        if (pawn.PossibleTrips.Contains(location))
        {
          result = true;
          break;
        }
      }
      return result;

    }




    public List<Pawn> GetMenacedListAndNotProtected(List<Pawn> pawnList, string actualColor)
    {


      var menacerList = new List<Pawn>();
      foreach (var item in pawnList.Where(x => x.Colore == actualColor))
      {
        // var isMenaced = LoactionIsMenaced(item.Location, actualColor, pawnList);
        var isProtected = LoactionIsProtected(item.Location, item.Location, actualColor, pawnList);
        //var isProtected
        if (/*isMenaced && */!isProtected)
        {
          //var resultArray0 = new int[2] { -(movingPawn.Value * 100), makeCheckmateLevel };
          //return resultArray0;
          menacerList.Add(item);
        }
      }
      return menacerList;
    }

    public List<Pawn> GetMenacedList(List<Pawn> pawnList, string actualColor)
    {
      var menacerList = new List<Pawn>();
      foreach (var item in pawnList.Where(x => x.Colore == actualColor))
      {
        if (LoactionIsMenaced(item.Location, actualColor, pawnList))
        {
          //var resultArray0 = new int[2] { -(movingPawn.Value * 100), makeCheckmateLevel };
          //return resultArray0;
          menacerList.Add(item);
        }
      }
      return menacerList;
    }

    private List<Pawn> copyPawnList(List<Pawn> pawnListIn)
    {
      // Pawn(string name,string location, Button associateButton,string colore, MainWindow mainWindowParent)
      var pawnListOut = new List<Pawn>();
      // var pawnListOut = pawnListIn.GetRange(0, pawnListIn.Count);
      // pawnListOut.AddRange(pawnListIn);
      foreach (var item in pawnListIn)
      {
        var newPawn = new Pawn(item.Name, item.Location, new Button(), item.Colore, this);
        //;{pawn.IsFirstMove};{pawn.IsFirstMoveKing};{pawn.IsLeftRookFirstMove};{pawn.IsRightRookFirstMove}
        /* newPawn.Name = item.Name;
         newPawn.Colore = item.Colore;
         newPawn.X = item.X;
         newPawn.Y = item.Y;
         newPawn.Location = item.Location;
         newPawn.PossibleTrips = new List<string>();
         newPawn.PossibleTripsScore = new List<int>();
         newPawn.Value = item.Value;
         newPawn.MainWindowParent = this;*/
        newPawn.AssociateButton = item.AssociateButton;
        newPawn.IsFirstMove = item.IsFirstMove;
        newPawn.IsFirstMoveKing = item.IsFirstMoveKing;
        newPawn.IsLeftRookFirstMove = item.IsLeftRookFirstMove;
        newPawn.IsRightRookFirstMove = item.IsRightRookFirstMove;
        pawnListOut.Add(newPawn);
      }
      return pawnListOut;


    }
    /*tsiry;12-08-2021
      * Attribution d'un score à une position
      *  cette fonction serivar à generer la liste des positions
      *  particuliaire et leurs symetries
      */

    public void GenereteBestList()
    {


      var serviceChessDB = new ServiceChessDB();
      var vBestPostions = serviceChessDB.GetVBestPostions();

      SpecificPositionsList = new List<SpecificPositions>();

      foreach (var item in vBestPostions)
      {
        var result = GetWhiteAndBlackList(item.PawnListStr);
        var specificPositions = new SpecificPositions();
        specificPositions.Color = item.BestPositionsFor;
        specificPositions.Weight = item.BestPositionsWeight.Value;
        specificPositions.Positions = result;
        SpecificPositionsList.Add(specificPositions);
        //Symetrique de TSpecificPosition0
        var symetricColor = "White";
        if (item.BestPositionsFor == "White")
          symetricColor = "Black";
        result = this.GetSymmetryList(result);
        specificPositions = new SpecificPositions();
        specificPositions.Color = symetricColor;
        specificPositions.Weight = item.BestPositionsWeight.Value;
        specificPositions.Positions = result;
        SpecificPositionsList.Add(specificPositions);
      }

      foreach (var item in SpecificPositionsList)
      {
        item.GenerateSpecificsBoard();
      }

      //Pour les BestsPosition

      SpecifiBoardList = new List<SpecificBoard>();
      foreach (var item in SpecificPositionsList)
      {
        var specificBoard = new SpecificBoard();

        specificBoard.Color = item.Color[0].ToString();
        specificBoard.Weight = item.Weight;
        specificBoard.SpecificsBoard = item.SpecificsBoard;
        SpecifiBoardList.Add(specificBoard);
      }





      // var isEquals = IsEquals(resultB, resultA);

    }

    public void GenereteBestListOLDOK()
    {



      SpecificPositionsList = new List<SpecificPositions>();

      //TSpecificPosition0
      var whiteListString = "" +
          "King;e1;White;False;True;True;True" +
"\nQueen;d1;White;False;False;False;False" +
"\nRook;a1;White;False;False;False;False" +
"\nRook;h1;White;False;False;False;False" +
"\nBishop;c1;White;False;False;False;False" +
"\nBishop;c4;White;False;False;False;False" +
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
      var result = GetWhiteAndBlackList(whiteListString, blackListString);
      var specificPositions = new SpecificPositions();
      specificPositions.Color = "White";
      specificPositions.Weight = 9999999;
      specificPositions.Positions = result;
      SpecificPositionsList.Add(specificPositions);






      // var isEquals = IsEquals(resultB, resultA);

    }


    public void GenereteBestList588()
    {



      SpecificPositionsList = new List<SpecificPositions>();

      //TSpecificPosition0
      var whiteListString = "" +
"King;e1;White;False;True;True;True" +
"\nQueen;d1;White;False;False;False;False" +
"\nRook;a1;White;False;False;False;False" +
"\nRook;h1;White;False;False;False;False" +
"\nBishop;c1;White;False;False;False;False" +
"\nBishop;c4;White;False;False;False;False" +
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
      var blackListString = "" +
      "King;e8;Black;False;False;True;True" +
      "\nQueen;d8;Black;False;False;False;False" +
      "\nRook;a8;Black;False;False;False;False" +
      "\nRook;h8;Black;False;False;False;False" +
      "\nKnight;b8;Black;False;False;False;False" +
      "\nKnight;f6;Black;False;False;False;False" +
      "\nBishop;c8;Black;False;False;False;False" +
      "\nBishop;f8;Black;False;False;False;False" +
      "\nSimplePawn;a5;Black;False;False;False;False" +
      "\nSimplePawn;b6;Black;False;False;False;False" +
      "\nSimplePawn;c6;Black;False;False;False;False" +
      "\nSimplePawn;d6;Black;False;False;False;False" +
      "\nSimplePawn;e7;Black;True;False;False;False" +
      "\nSimplePawn;f7;Black;True;False;False;False" +
      "\nSimplePawn;g7;Black;True;False;False;False" +
      "\nSimplePawn;h7;Black;True;False;False;False";
      /*

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
      "\nSimplePawn;h7;Black;True;False;False;False";*/

      //var r = whiteListString.Split('\n');
      var result = GetWhiteAndBlackList(whiteListString, blackListString);
      var specificPositions = new SpecificPositions();
      specificPositions.Color = "White";
      specificPositions.Weight = 9999999;
      specificPositions.Positions = result;
      SpecificPositionsList.Add(specificPositions);


    }

    /*tsiry;12-08-2021
* Attribution d'un score à une position
*  cette fonction serivar à remvoyer une symetrique 
*  avec inserion des position
*/
    public List<Pawn> GetSymmetryList(List<Pawn> pawnsInList)
    {

      var symmetryList = new List<Pawn>();
      foreach (var pawn in pawnsInList)
      {
        symmetryList.Add(pawn.GetSymmetry());
      }
      return symmetryList;
    }




    /*tsiry;12-08-2021
 * Attribution d'un score à une position
 *  cette fonction serivar à avoir une liste à partir des strings en entrés
 */
    public List<Pawn> GetWhiteAndBlackList(string pawnListString1, string pawnListString2 = null)
    {

      var pawnList = new List<Pawn>();




      var whiteList = pawnListString1.Split('\n');
      foreach (var line in whiteList)
      {
        if (!line.Contains(";"))
          continue;
        var datas = line.Split(';');
        var newPawn = new Pawn(datas[0], datas[1], new Button(), datas[2], this);
        //;{pawn.IsFirstMove};{pawn.IsFirstMoveKing};{pawn.IsLeftRookFirstMove};{pawn.IsRightRookFirstMove}
        newPawn.IsFirstMove = bool.Parse(datas[3]);
        newPawn.IsFirstMoveKing = bool.Parse(datas[4]);
        newPawn.IsLeftRookFirstMove = bool.Parse(datas[5]);
        newPawn.IsRightRookFirstMove = bool.Parse(datas[6]);
        pawnList.Add(newPawn);
      }

      if (pawnListString2 != null)
      {
        var blackList = pawnListString2.Split('\n');
        foreach (var line in blackList)
        {
          var datas = line.Split(';');
          var newPawn = new Pawn(datas[0], datas[1], new Button(), datas[2], this);
          //;{pawn.IsFirstMove};{pawn.IsFirstMoveKing};{pawn.IsLeftRookFirstMove};{pawn.IsRightRookFirstMove}
          newPawn.IsFirstMove = bool.Parse(datas[3]);
          newPawn.IsFirstMoveKing = bool.Parse(datas[4]);
          newPawn.IsLeftRookFirstMove = bool.Parse(datas[5]);
          newPawn.IsRightRookFirstMove = bool.Parse(datas[6]);
          pawnList.Add(newPawn);
        }
      }





      return pawnList;
    }


    public List<Pawn> GetPawnList(string pawnListString)
    {

      var pawnList = new List<Pawn>();


      var tempPawnList = pawnListString.Split('\n');
      foreach (var line in tempPawnList)
      {
        //Debug.WriteLine(line);
        if (!line.Contains(";"))
          continue;

        var datas = line.Split(';');
        var bt = (Button)this.FindName(datas[1]);
        var newPawn = new Pawn(datas[0], datas[1], bt, datas[2], this);
        //;{pawn.IsFirstMove};{pawn.IsFirstMoveKing};{pawn.IsLeftRookFirstMove};{pawn.IsRightRookFirstMove}
        newPawn.IsFirstMove = bool.Parse(datas[3]);
        newPawn.IsFirstMoveKing = bool.Parse(datas[4]);
        newPawn.IsLeftRookFirstMove = bool.Parse(datas[5]);
        newPawn.IsRightRookFirstMove = bool.Parse(datas[6]);
        pawnList.Add(newPawn);
      }






      return pawnList;
    }



    /*tsiry;12-08-2021
* Attribution d'un score à une position
*  cette fonction serivar a comparer deux liste de PawnList
*/
    private bool IsEquals(List<Pawn> pawnsA, List<Pawn> pawnsB)
    {
      if (pawnsA.Count != pawnsB.Count)
        return false;
      pawnsA = pawnsA.OrderBy(x => x.Colore).ThenBy(x => x.Name).ThenBy(x => x.Location).ToList();
      pawnsB = pawnsB.OrderBy(x => x.Colore).ThenBy(x => x.Name).ThenBy(x => x.Location).ToList();
      for (int i = 0; i < pawnsA.Count; i++)
      {
        if (!pawnsA[i].Compare(pawnsB[i]))
        {
          return false;
        }
      }

      return true;

    }


    /*tsiry;12-08-2021
* Attribution d'un score à une position
*pour prendre le pion de différence
*/
    public List<Pawn> GetDiff(List<Pawn> pawnsActual, List<Pawn> pawnsFutur)
    {


      var actualLocations = pawnsActual.Select(x => x.Location);
      var notInActual = pawnsFutur.Where(x => !actualLocations.Contains(x.Location)).ToList();



      return notInActual;

    }




    private bool isInChess(List<Pawn> actualPawnList, string colore)
    {
      var kingLocation = actualPawnList.FirstOrDefault(x => x.Colore == colore && x.Name == "King");
      if (kingLocation == null)
        return false;
      var opignonPawnList = actualPawnList.Where(x => x.Colore != colore);
      foreach (var opignonPawn in opignonPawnList)
      {

        foreach (var item in opignonPawn.PossibleTrips)
        {
          if (item == kingLocation.Location)
          {
            return true;
          }
        }

      }

      return false;
    }

    private bool opinionIsCheckmate(string curentColor, List<Pawn> actualPawnList)
    {
      var opinionKing = actualPawnList.FirstOrDefault(x => x.Colore != curentColor && x.Name == "King");
      if (opinionKing == null)
        return false;

      var opinionKingLocation = opinionKing.Location;
      var alierPawnList = actualPawnList.Where(x => x.Colore == curentColor);

      foreach (var pawn in alierPawnList)
      {

        if (pawn.PossibleTrips.Contains(opinionKingLocation))
          return true;
      }

      return false;

    }








    public int GetScore(string colore)
    {

      if (colore == "Black")
      {

        return PawnList.Where(x => x.Colore == "Black").Sum(x => x.Value);
      }
      else
      {
        return PawnList.Where(x => x.Colore == "White").Sum(x => x.Value);
      }


    }

    private void simulProgression()
    {
      //pbCalculationProgress.Value = 0;

      BackgroundWorker worker = new BackgroundWorker();
      worker.WorkerReportsProgress = true;
      worker.DoWork += worker_DoWork;
      worker.ProgressChanged += worker_ProgressChanged;
      worker.RunWorkerCompleted += worker_RunWorkerCompleted;
      worker.RunWorkerAsync(10000);
    }
    void worker_ProgressChanged(object sender, ProgressChangedEventArgs e)
    {
      //pbCalculationProgress.Value = e.ProgressPercentage;
      /* if (e.UserState != null)
         lbResults.Items.Add(e.UserState);*/
    }

    void worker_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
    {
      MessageBox.Show("Numbers between 0 and 10000 divisible by 7: " + e.Result);
    }


    void worker_DoWork(object sender, DoWorkEventArgs e)
    {
      int max = (int)e.Argument;
      int result = 0;
      for (int i = 0; i < max; i++)
      {
        int progressPercentage = Convert.ToInt32(((double)i / max) * 100);
        if (i % 42 == 0)
        {
          result++;
          (sender as BackgroundWorker).ReportProgress(progressPercentage, i);
        }
        else
          (sender as BackgroundWorker).ReportProgress(progressPercentage);
        System.Threading.Thread.Sleep(1);

      }
      e.Result = result;
    }


    public Node GetBestPositionAndMoveFor(string colore)
    {
      Thread threadTimer = new Thread(ThreadCountCPUReflectionTime);
      threadTimer.Start();

      var node = new Node();

      //simulProgression();

      if (_isInLocalEgine)
      {
        //utilisation du moteur local
         Thread sherchThread = new Thread(() => node = ThreadGetBestMove(colore));
       // Thread sherchThread = new Thread(() => node = GetBestPositionLocalNotTaskUsingMiltiThreading(colore));
        
        sherchThread.Start();
        // ThreadGetBestMove(colore);
      }
      else
      {
        //utilisation du moteur du server
        Thread sherchThread = new Thread(() => ThreadGetBestMoveFromServer(colore));
        sherchThread.Start();
      }








      return node;
    }

    /*tsiry;26-05-2021
     * copie de GetBestPositionAndMoveFor mais pour les tests
     * */
    public Node GetBestPositionLocalNotTask(string colore)
    {
      return ThreadGetBestMoveNotTask(colore);
    }


   

   




    //TODO  REMPLACER PAR CHESS2
    private Node ThreadGetBestMove(string color)
    {
     // System.GC.Collect();
      Thread.Sleep(TimeSpan.FromSeconds(5));

     
      Node node = new Node();
      this.Dispatcher.BeginInvoke(new Action(() =>
      {
        /* var boarChess2 = Chess2Utils.GenerateBoardFormPawnList(this.PawnList);

         //pour T82 NUll 2
         //  boarChess2.MovingList

         var engine = new Engine(DeeLevel, ComputerColore[0].ToString(), IsReprise, SpecifiBoardList, true);

         var bestNodeChess2 = engine.Search(boarChess2, TurnNumberLabel.Content.ToString());

        // Node node = new Node();
         node.Location = Chess2Utils.GetLocationFromIndex(bestNodeChess2.FromIndex);
         node.BestChildPosition = Chess2Utils.GetLocationFromIndex(bestNodeChess2.ToIndex);
         node.AssociatePawn = GetPawn(node.Location);
         //Seulment pour les test
         node.AsssociateNodeChess2 = bestNodeChess2;
         //return node;
         //node.AsssociateNodeChess2 = bestNodeChess2;
         */
        var boarChess = Chess2Utils.GenerateBoardFormPawnList(this.PawnList);
        node = Chess2Utils.GetBestPositionLocalUsingMiltiThreading(color, boarChess,this.IsReprise,this.SpecifiBoardList);
        MoveTo(node.Location, node.BestChildPosition);

        
        // Notifier.ShowInformation("Move completed");

        _cpuTimer?.Stop();
       
       
      }));
      return node;








    }

    /*tsiry;26-05-2021
     * copie de ThreadGetBestMove pour les test
     * */




    //Pour les test
    public Node ThreadGetBestMoveNotTask(string color)
    {

      try
      {
        //System.GC.Collect();
        // GC.WaitForPendingFinalizers();

        // Node node = new Node();

        //Pour les BestsPosition

        if (SpecificPositionsList != null)
        {
          var specifiBoardList = new List<SpecificBoard>();
          foreach (var item in SpecificPositionsList)
          {
            var specificBoard = new SpecificBoard();

            specificBoard.Color = item.Color[0].ToString();
            specificBoard.Weight = item.Weight;
            specificBoard.SpecificsBoard = item.SpecificsBoard;
            specifiBoardList.Add(specificBoard);
          }
        }




        var boarChess2 = Chess2Utils.GenerateBoardFormPawnList(this.PawnList);

        //pour T82 NUll 2
        //  boarChess2.MovingList

        var engine = new Engine(DeeLevel, ComputerColore[0].ToString(), IsReprise, SpecifiBoardList,true);
        var firstInLastMove = GetTreeLastAction();

        var positions = firstInLastMove.Substring(firstInLastMove.Count() - 8, 8);
        positions = positions.Replace(" ", "");
        positions = positions.Replace("=", "");
        var positionsDatas = positions.Split('>');
        var fromIndexNotValide = Chess2Utils.GetIndexFromLocation(positionsDatas[0]);
        var toIndexNotValide = Chess2Utils.GetIndexFromLocation(positionsDatas[1]);

        var bestNodeChess2 = engine.Search(boarChess2, TurnNumberLabel.Content.ToString(), fromIndexNotValide, toIndexNotValide);

        Node node = new Node();
        node.Location = Chess2Utils.GetLocationFromIndex(bestNodeChess2.FromIndex);
        node.BestChildPosition = Chess2Utils.GetLocationFromIndex(bestNodeChess2.ToIndex);
        node.AssociatePawn = GetPawn(node.Location);
        //Seulment pour les test
        node.AsssociateNodeChess2 = bestNodeChess2;
        return node;
      }
      catch (Exception ex)
      {
        WriteInLog(ex.ToString());
        return null;
      }
    }

    /*tsiry;04-10-2021
     * Implementation de "Eviter partie NUll
     * on prend les 3 dérniéres actions
     * */
    public string GetTreeLastAction()
    {
      try
      {
        if (String.IsNullOrEmpty(DebugTextBlock.Text))
          return "-1 => -1";
        var moveList = DebugTextBlock.Text.Split('\n');
        var lastMovesList = moveList.Skip(Math.Max(0, moveList.Count() - 4)).Take(4);
        var movesComputerColorList = new List<string>();
        foreach (var move in lastMovesList)
        {
          if (move.Contains(ComputerColore))
            movesComputerColorList.Add(move);
        }
        // t_lastMovesList.ToList().RemoveAll(x => !x.ToString() .Contains(ComputerColore));

        return movesComputerColorList[0].ToString();
      }
      catch (Exception ex)
      {

        WriteInLog(ex.ToString());
        return null;
      }


    }


    public static string StartClient(string message)
    {
      byte[] bytes = new byte[1024];

      try
      {
        // Connect to a Remote server  
        // Get Host IP Address that is used to establish a connection  
        // In this case, we get one IP address of localhost that is IP : 127.0.0.1  
        // If a host has multiple addresses, you will get a list of addresses  
        // IPHostEntry host = Dns.GetHostEntry("127.0.0.1");
        IPHostEntry host = Dns.GetHostEntry("192.168.15.166");
        IPAddress ipAddress = host.AddressList[0];
        IPEndPoint remoteEP = new IPEndPoint(ipAddress, 65432);

        // Create a TCP/IP  socket.    
        Socket sender = new Socket(ipAddress.AddressFamily,
            SocketType.Stream, ProtocolType.Tcp);

        // Connect the socket to the remote endpoint. Catch any errors.    
        try
        {
          // Connect to Remote EndPoint  
          sender.Connect(remoteEP);

          Console.WriteLine("Socket connected to {0}",
              sender.RemoteEndPoint.ToString());

          // Encode the data string into a byte array.    
          byte[] msg = Encoding.ASCII.GetBytes(message + "<EOF>");

          // Send the data through the socket.    
          int bytesSent = sender.Send(msg);

          // Receive the response from the remote device.    
          int bytesRec = sender.Receive(bytes);
          Console.WriteLine("Echoed test = {0}",
              Encoding.ASCII.GetString(bytes, 0, bytesRec));
          var result = Encoding.ASCII.GetString(bytes, 0, bytesRec);

          // Release the socket.    
          sender.Shutdown(SocketShutdown.Both);
          sender.Close();
          return result;

        }
        catch (ArgumentNullException ane)
        {
          Console.WriteLine("ArgumentNullException : {0}", ane.ToString());
          return ane.ToString();
        }
        catch (SocketException se)
        {
          Console.WriteLine("SocketException : {0}", se.ToString());
          return se.ToString();
        }
        catch (Exception e)
        {
          Console.WriteLine("Unexpected exception : {0}", e.ToString());
          return e.ToString();
        }

      }
      catch (Exception e)
      {
        Console.WriteLine(e.ToString());

        return e.ToString();
      }
    }
    private void ThreadGetBestMoveFromServer(string color)
    {
      try
      {
        Thread.Sleep(TimeSpan.FromSeconds(5));
        var pawnStringList = new List<string>();

        foreach (var pawn in PawnList)
        {
          pawnStringList.Add(($"{pawn.Name};{pawn.Location};{pawn.Colore};{pawn.IsFirstMove};{pawn.IsFirstMoveKing};{pawn.IsLeftRookFirstMove};{pawn.IsRightRookFirstMove}"));

        }

        var message = String.Join(".", pawnStringList);

        this.Dispatcher.BeginInvoke(new Action(() =>
        {
          //var answer = StartClient(color + "." + cumputerLevel.ToString() + "." + message);
          ////return answer;
          //var answerList = answer.Split(';');
          //var location = answerList[0];
          //var bestPosition = answerList[1];


          //MoveTo(location, bestPosition);
          //_cpuTimer.Stop();






        }));
      }
      catch (Exception ex)
      {

        WriteInLog(ex.ToString());
      }





    }

    private async void RunEngineForWhite_Click(object sender, RoutedEventArgs e)
    {

      try
      {

        while (true)
        {

          await Task.Delay(1);
          GetBestPositionAndMoveFor("White");
          await Task.Delay(1);
          var bestNode = GetBestPositionAndMoveFor("Black");


          if (bestNode.Colore == CurrentTurn)//bug, on load
          {
            LoadOld();
            GetBestPositionAndMoveFor(CurrentTurn);
          }

          Save(PawnList);




        }
      }
      catch (Exception ex)
      {

        WriteInLog(ex.ToString());
      }

      ComputerColore = "";


    }


    private async void RunEngineForBlack_Click(object sender, RoutedEventArgs e)
    {

      try
      {
        ComputerColore = "";

        while (true)
        {

          await Task.Delay(1);
          GetBestPositionAndMoveFor("Black");
          await Task.Delay(1);
          var bestNode = GetBestPositionAndMoveFor("White");


          if (bestNode.Colore == CurrentTurn)//bug, on load
          {
            LoadOld();
            GetBestPositionAndMoveFor(CurrentTurn);
          }

          Save(PawnList);

        }
      }
      catch (Exception ex)
      {

        WriteInLog(ex.ToString());
      }




    }



    private void startDB()
    {
      try
      {
        CreateLogFile();
        if (_serviceChessDB == null)
        {
          //Historique local
          CreateHistoryFile();
          return;
        }



        _serviceChessDB.CreateNewGamePart($"Part {DateTime.Now.ToString("HH:mm:ss dd/MM/yyyy")}", DateTime.Now, _mode);
        _gamePartID = _serviceChessDB.GetLastGamePart().GamePartID;
      }
      catch (Exception ex)
      {
        WriteInLog(ex.ToString());

      }



    }

    private void WhiteFirstButon_Click(object sender, RoutedEventArgs e)
    {

      try
      {
        startDB();
        _dateTimeCount = DateTime.Now;
        CurrentTurn = "White";




        //GetBestPositionAndMoveFor("Black");
        WhiteTurnButton.Visibility = Visibility.Visible;
        BlackTurnButton.Visibility = Visibility.Hidden;
        //  _computerColore = "Black";
        WhiteRunEngineButton.IsEnabled = true;
        BlackRunEngineButton.IsEnabled = true;


        if (ComputerColore == "Black")
          return;
        if (!String.IsNullOrEmpty(ComputerColore))
        {
          //Save();
          //LoadOld();
          var bestNode = GetBestPositionAndMoveFor(ComputerColore);

        }
      }
      catch (Exception ex)
      {

        WriteInLog(ex.ToString());
      }


    }

    private void BlackFirstButon_Click(object sender, RoutedEventArgs e)
    {
      try
      {
        startDB();
        CurrentTurn = "Black";
        _dateTimeCount = DateTime.Now;

        WhiteTurnButton.Visibility = Visibility.Hidden;
        BlackTurnButton.Visibility = Visibility.Visible;
        //GetBestPositionAndMoveFor("White");
        //  _computerColore = "White";
        WhiteRunEngineButton.IsEnabled = true;
        BlackRunEngineButton.IsEnabled = true;




        if (ComputerColore == "White")
          return;
        if (!String.IsNullOrEmpty(ComputerColore))
        {
          //Save();
          //LoadOld();
          var bestNode = GetBestPositionAndMoveFor(ComputerColore);

        }
      }
      catch (Exception ex)
      {

        WriteInLog(ex.ToString());
      }



    }



    private void saveButton_Click(object sender, RoutedEventArgs e)
    {
      Save(PawnList);
    }

    public void Save(List<Pawn> pawns, string destinationPathParam = null)
    {
      try
      {
        var destinationPath = "./";
        if (destinationPathParam != null)
          destinationPath = destinationPathParam;

        var whiteListFile = $"{destinationPath}\\WHITEList.txt";
        var blackListFile = $"{destinationPath}\\BLACKList.txt";
        /* var whiteListOldFile = "./WHITEListOld.txt";
         var blackListOldFile = "./BLACKListOld.txt";*/
        //implemenation de preview
        /*File.Copy(whiteListFile, whiteListOldFile, true);
        File.Copy(blackListFile, blackListOldFile, true);*/
        var pawnListWhite = pawns.Where(x => x.Colore == "White").ToList();
        var pawnListBlack = pawns.Where(x => x.Colore == "Black").ToList();
        using (var writer = new StreamWriter(whiteListFile))
        {

          foreach (var pawn in pawnListWhite)
          {
            writer.WriteLine($"{pawn.Name};{pawn.Location};{pawn.Colore};{pawn.IsFirstMove};{pawn.IsFirstMoveKing};{pawn.IsLeftRookFirstMove};{pawn.IsRightRookFirstMove}");
          }
        }
        using (var writer = new StreamWriter(blackListFile))
        {

          foreach (var pawn in pawnListBlack)
          {
            writer.WriteLine($"{pawn.Name};{pawn.Location};{pawn.Colore};{pawn.IsFirstMove};{pawn.IsFirstMoveKing};{pawn.IsLeftRookFirstMove};{pawn.IsRightRookFirstMove}");
          }
        }

        //sauvegarde du cemetiaire

        var deadListFile = $"{destinationPath}\\Graveyard.txt";
        using (var writer = new StreamWriter(deadListFile))
        {

          foreach (var item in _deadList)
          {
            writer.WriteLine($"{item}");
          }
        }
      }
      catch (Exception ex)
      {

        WriteInLog(ex.ToString());
      }



    }


    /*tsiry;01-06-2021
* creation de l'historique
* on copie les entien coordonnées dans un docier*/
    public void SaveToHistorical(int turnNumber, string color)
    {


      try
      {
        var srtListPawn = new List<string>();

        foreach (var pawn in PawnList)
        {
          srtListPawn.Add($"{pawn.Name};{pawn.Location};{pawn.Colore};{pawn.IsFirstMove};{pawn.IsFirstMoveKing};{pawn.IsLeftRookFirstMove};{pawn.IsRightRookFirstMove}");
        }

        if (color == "White")
        {
          HistoricalWhiteList.Add(srtListPawn);
        }
        else
        {
          HistoricalBlackList.Add(srtListPawn);
        }
      }
      catch (Exception ex)
      {

        WriteInLog(ex.ToString());
      }






    }



    public void CleanPawnList()
    {
      try
      {
        foreach (var pawn in PawnList)
        {
          pawn.Clean();
        }

        /*  foreach (var pawn in PawnListWhite)
          {
            pawn.Clean();
          }

          foreach (var pawn in PawnListBlack)
          {
            pawn.Clean();
          }*/


        PawnListWhite = null;
        PawnListBlack = null;
        PawnList = null;
        PawnListWhite = new List<Pawn>();
        PawnListBlack = new List<Pawn>();
        PawnList = new List<Pawn>();
      }
      catch (Exception ex)
      {

        WriteInLog(ex.ToString());
      }

    }
    /*tsiry;30-06-2021
     * utilisation de load à partir de la base de donnée
     * */
    public void LoadSelectedGamePart()
    {
      try
      {
        if (GamePartComboBox.SelectedItem == null)
          return;

        CleanPawnList();
        var pawnListWhite = new List<Pawn>();
        var pawnListBlack = new List<Pawn>();

        _gamePartID = ((GamePart)GamePartComboBox.SelectedItem).GamePartID;

        var turnList = _serviceChessDB.GetGameTurns(_gamePartID);
        var currentTurn = turnList[turnList.Count - 1];
        var currentListTurnsList = currentTurn;
        TurnNumberLabel.Content = turnList.IndexOf(currentTurn);


        var pawnList = new List<Pawn>();
        if (!_isFromStart)
        {
          _navigationInDBIndex = turnList.IndexOf(currentTurn) - turnList.Count + 1;
          NextButon.IsEnabled = false;
          PreviousButon.IsEnabled = true;
        }





        var tempPawnList = currentListTurnsList.PawnListStr.Split('\n');
        foreach (var line in tempPawnList)
        {
          //Debug.WriteLine(line);
          if (!line.Contains(";"))
            continue;

          var datas = line.Split(';');
          var bt = (Button)this.FindName(datas[1]);
          var newPawn = new Pawn(datas[0], datas[1], bt, datas[2], this);
          //;{pawn.IsFirstMove};{pawn.IsFirstMoveKing};{pawn.IsLeftRookFirstMove};{pawn.IsRightRookFirstMove}
          newPawn.IsFirstMove = bool.Parse(datas[3]);
          newPawn.IsFirstMoveKing = bool.Parse(datas[4]);
          newPawn.IsLeftRookFirstMove = bool.Parse(datas[5]);
          newPawn.IsRightRookFirstMove = bool.Parse(datas[6]);
          pawnList.Add(newPawn);
        }

        var whiteList = pawnList.Where(x => x.Colore == "White").ToList();
        var blackList = pawnList.Where(x => x.Colore == "Black").ToList();



        FillPawnListAndFillAllPossibleTrips(whiteList, blackList);



        SetVisibleOrCollapsedStars(currentTurn);
      }
      catch (Exception ex)
      {

        WriteInLog(ex.ToString());
      }





    }

    public void LoadFromDirectorie(string dirLocation)
    {
      try
      {
        var pawnListWhite = new List<Pawn>();
        var pawnListBlack = new List<Pawn>();

        var whiteFileLocation = dirLocation + "/WHITEList.txt";
        var blackFileLocation = dirLocation + "/BlackList.txt";






        var readText = File.ReadAllText(whiteFileLocation);

        using (StringReader sr = new StringReader(readText))
        {
          string line;
          while ((line = sr.ReadLine()) != null)
          {
            //Debug.WriteLine(line);

            var datas = line.Split(';');
            var bt = (Button)this.FindName(datas[1]);
            var newPawn = new Pawn(datas[0], datas[1], bt, datas[2], this);
            //;{pawn.IsFirstMove};{pawn.IsFirstMoveKing};{pawn.IsLeftRookFirstMove};{pawn.IsRightRookFirstMove}
            newPawn.IsFirstMove = bool.Parse(datas[3]);
            newPawn.IsFirstMoveKing = bool.Parse(datas[4]);
            newPawn.IsLeftRookFirstMove = bool.Parse(datas[5]);
            newPawn.IsRightRookFirstMove = bool.Parse(datas[6]);
            pawnListWhite.Add(newPawn);

          }
        }

        readText = File.ReadAllText(blackFileLocation);

        using (StringReader sr = new StringReader(readText))
        {
          string line;
          while ((line = sr.ReadLine()) != null)
          {
            //Debug.WriteLine(line);

            var datas = line.Split(';');
            var bt = (Button)this.FindName(datas[1]);
            var newPawn = new Pawn(datas[0], datas[1], bt, datas[2], this);
            //;{pawn.IsFirstMove};{pawn.IsFirstMoveKing};{pawn.IsLeftRookFirstMove};{pawn.IsRightRookFirstMove}
            newPawn.IsFirstMove = bool.Parse(datas[3]);
            newPawn.IsFirstMoveKing = bool.Parse(datas[4]);
            newPawn.IsLeftRookFirstMove = bool.Parse(datas[5]);
            newPawn.IsRightRookFirstMove = bool.Parse(datas[6]);
            pawnListBlack.Add(newPawn);

          }
        }





        FillPawnListAndFillAllPossibleTrips(pawnListWhite, pawnListBlack);
      }
      catch (Exception ex)
      {
        Debug.WriteLine(ex);
        return;
      }
        
    }



    public void LoadOld(string old = "", bool isForPrevious = false)
    {
      try
      {
        CleanPawnList();

        var pawnListWhite = new List<Pawn>();
        var pawnListBlack = new List<Pawn>();

        var whiteFileLocation = "./WHITEList" + old + ".txt";
        var blackFileLocation = "./BlackList" + old + ".txt";






        var readText = File.ReadAllText(whiteFileLocation);

        using (StringReader sr = new StringReader(readText))
        {
          string line;
          while ((line = sr.ReadLine()) != null)
          {
            //Debug.WriteLine(line);

            var datas = line.Split(';');
            var bt = (Button)this.FindName(datas[1]);
            var newPawn = new Pawn(datas[0], datas[1], bt, datas[2], this);
            //;{pawn.IsFirstMove};{pawn.IsFirstMoveKing};{pawn.IsLeftRookFirstMove};{pawn.IsRightRookFirstMove}
            newPawn.IsFirstMove = bool.Parse(datas[3]);
            newPawn.IsFirstMoveKing = bool.Parse(datas[4]);
            newPawn.IsLeftRookFirstMove = bool.Parse(datas[5]);
            newPawn.IsRightRookFirstMove = bool.Parse(datas[6]);
            pawnListWhite.Add(newPawn);

          }
        }

        readText = File.ReadAllText(blackFileLocation);

        using (StringReader sr = new StringReader(readText))
        {
          string line;
          while ((line = sr.ReadLine()) != null)
          {
            //Debug.WriteLine(line);

            var datas = line.Split(';');
            var bt = (Button)this.FindName(datas[1]);
            var newPawn = new Pawn(datas[0], datas[1], bt, datas[2], this);
            //;{pawn.IsFirstMove};{pawn.IsFirstMoveKing};{pawn.IsLeftRookFirstMove};{pawn.IsRightRookFirstMove}
            newPawn.IsFirstMove = bool.Parse(datas[3]);
            newPawn.IsFirstMoveKing = bool.Parse(datas[4]);
            newPawn.IsLeftRookFirstMove = bool.Parse(datas[5]);
            newPawn.IsRightRookFirstMove = bool.Parse(datas[6]);
            pawnListBlack.Add(newPawn);

          }
        }





        FillPawnListAndFillAllPossibleTrips(pawnListWhite, pawnListBlack);




      }
      catch (Exception ex)
      {

        WriteInLog(ex.ToString());
      }




    }

    public void FillPawnListAndFillAllPossibleTrips(List<Pawn> pawnListWhite, List<Pawn> pawnListBlack)
    {

      try
      {
        PawnList.Clear();
        PawnList = null;
        PawnList = new List<Pawn>();
        PawnListWhite.Clear();
        PawnListWhite = null;
        PawnListWhite = new List<Pawn>();
        PawnList.Clear();
        PawnListBlack = null;
        PawnListBlack = new List<Pawn>();


        PawnList.AddRange(pawnListWhite.OrderByDescending(x => x.Value));
        PawnList.AddRange(pawnListBlack.OrderByDescending(x => x.Value));
        PawnListWhite = PawnList.Where(x => x.Colore == "White").ToList();
        PawnListBlack = PawnList.Where(x => x.Colore == "Black").ToList();


        var whiteScore = GetScore("White");
        var blackScore = GetScore("Black");
        lbWhiteScore.Content = whiteScore;
        lbBlackScore.Content = blackScore;

        PawnList = PawnList.OrderByDescending(x => x.Value).ToList();
        //     PawnList = PawnList.OrderBy(x => x.Value).ToList();




        FillAllPossibleTrips();
      }
      catch (Exception ex)
      {

        WriteInLog(ex.ToString());
      }


    }

  

    /*tsiry;10-05-2021
     * lecture du cemetiére
     * */

    public void LoadGraveyardFile()
    {
      try
      {
        //lecture du cimetiére
        if (!_graveyardIsLoaded)
        {
          var readText = File.ReadAllText("./Graveyard.txt");

          using (StringReader sr = new StringReader(readText))
          {
            string line;
            while ((line = sr.ReadLine()) != null)
            {
              //Debug.WriteLine(line);

              fillGraveyard(line);
              _deadList.Add(line);

            }
          }
          calculatePoint();
        }

        _graveyardIsLoaded = true;
      }
      catch (Exception ex)
      {

        WriteInLog(ex.ToString());
      }




    }

    private void loadButton_Click(object sender, RoutedEventArgs e)
    {


      // GamePartComboBox.IsEnabled = false;
      Mouse.OverrideCursor = System.Windows.Input.Cursors.Wait;

      LoadDB();
      Mouse.OverrideCursor = null;
      GamePartComboBox.IsEnabled = true;

    }

    private void LoadDB()
    {
      try
      {
        if (_serviceChessDB == null)
          return;
        GamePartComboBox.ItemsSource = _serviceChessDB.GetValidGameParts(/*"Release"*/_mode);
        GamePartComboBox.IsEnabled = true;
        SaveBestPostionsForButon.IsEnabled = true;
      }
      catch (Exception ex)
      {

        WriteInLog(ex.ToString());
      }

    }
    private void GamePartComboBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
    {
      /* LoadButton.IsEnabled = true;
       if (GamePartComboBox.SelectedItem == null)
         LoadButton.IsEnabled = false;*/
      IsReprise = true;
      LoadSelectedGamePart();

    }

    private void ChoseWhiteForCoputerButon_Click(object sender, RoutedEventArgs e)
    {
      ComputerColore = "White";
      ChoseBlackForCoputerButon.IsEnabled = false;
      //si on choisis CPU White on débute dirrectement la partie avec les Blanchs 
      WhiteFirstButon_Click(sender, e);


    }

    private void ChoseBlackForCoputerButon_Click(object sender, RoutedEventArgs e)
    {
      ComputerColore = "Black";
      ChoseWhiteForCoputerButon.IsEnabled = false;

      //TODO A DECOMMENTER
      //si on choisis CPU Black on inverse le Board et on débute dirrectement la partie avec les Blanchs 
      RotationButon_Click(sender, e);
      WhiteFirstButon_Click(sender, e);

    }

    private void PreviousButon_Click(object sender, RoutedEventArgs e)
    {
      /* if (HistoricalBlackList.Count == 0 && HistoricalWhiteList.Count == 0)
         LoadOld("Old");
       else*/
      PreviousFromDB();

    }

    private void NextButon_Click(object sender, RoutedEventArgs e)
    {

      NextFromDB();

    }
        /*tsiry;28-05-2021
    * implementation de l'historique
    * en utilisant Hisyory.txt
    * */

        public void PreviousFromHistoryFile()
        {
            try
            {

            }
            catch (Exception ex)
            {

                throw;
            }

        }

    /*tsiry;28-05-2021
 * implementation de l'historique
 * en utilisant la base
 * */

    public void NextFromDB()
    {
      try
      {
        PreviousButon.IsEnabled = true && _isConnectedDB;
        _navigationInDBIndex++;

        //LoadOld("Old", _previousCount);


        var turnList = _serviceChessDB.GetGameTurns(_gamePartID);
        var index = turnList.Count - 1 + _navigationInDBIndex;
        TurnNumberLabel.Content = index;

        LoadBoardFromIndex(turnList, index);



        //LoadGraveyardFile();

        if (_navigationInDBIndex == 0)
          NextButon.IsEnabled = false;

        /*tsiry;17-08-2021
         * gestion des étoiles
         * */

        var currentTurn = turnList[index];
        SetVisibleOrCollapsedStars(currentTurn);
      }
      catch (Exception ex)
      {

        WriteInLog(ex.ToString());
      }



    }
    /*tsiry;28-05-2021
     * implementation de l'historique
     * en utilisant la base
     * */

    public void PreviousFromDB()
    {

      try
      {
        NextButon.IsEnabled = true && _isConnectedDB;
        _navigationInDBIndex--;


        var turnList = _serviceChessDB.GetGameTurns(_gamePartID);
        var index = turnList.Count - 1 + _navigationInDBIndex;
        LoadBoardFromIndex(turnList, index);






        if ((turnList.Count + _navigationInDBIndex) == 1)
          PreviousButon.IsEnabled = false;

        /*tsiry;17-08-2021
         * gestion des étoiles
         * */

        var currentTurn = turnList[index];
        SetVisibleOrCollapsedStars(currentTurn);
      }
      catch (Exception ex)
      {

        WriteInLog(ex.ToString());
      }



    }

    public void LoadBoardFromIndex(List<Turns> turnList, int index)
    {
      try
      {
        CleanPawnList();
        var currentListTurnsList = turnList[index];
        TurnNumberLabel.Content = index;

        var pawnList = new List<Pawn>();
        var tempPawnList = currentListTurnsList.PawnListStr.Split('\n');
        foreach (var line in tempPawnList)
        {
          //Debug.WriteLine(line);
          if (!line.Contains(";"))
            continue;

          var datas = line.Split(';');
          var bt = (Button)this.FindName(datas[1]);
          var newPawn = new Pawn(datas[0], datas[1], bt, datas[2], this);
          //;{pawn.IsFirstMove};{pawn.IsFirstMoveKing};{pawn.IsLeftRookFirstMove};{pawn.IsRightRookFirstMove}
          newPawn.IsFirstMove = bool.Parse(datas[3]);
          newPawn.IsFirstMoveKing = bool.Parse(datas[4]);
          newPawn.IsLeftRookFirstMove = bool.Parse(datas[5]);
          newPawn.IsRightRookFirstMove = bool.Parse(datas[6]);
          pawnList.Add(newPawn);
        }

        var whiteList = pawnList.Where(x => x.Colore == "White").ToList();
        var blackList = pawnList.Where(x => x.Colore == "Black").ToList();



        FillPawnListAndFillAllPossibleTrips(whiteList, blackList);
      }
      catch (Exception ex)
      {

        WriteInLog(ex.ToString());
      }






    }

    /*tsiry;17-08-2021
     * affiche ou cacher les étoiles
     * */
    public void SetVisibleOrCollapsedStars(Turns currentTurn)
    {
      //si currentTurn et favorie
      var bestPostion = _serviceChessDB.GetVBestPostion(currentTurn.TurnID);
      if (bestPostion == null)
      {
        DeleteBestPostionsForButon.Visibility = Visibility.Collapsed;
        SaveBestPostionsForButon.Visibility = Visibility.Visible;
      }
      else
      {
        DeleteBestPostionsForButon.Visibility = Visibility.Visible;
        SaveBestPostionsForButon.Visibility = Visibility.Collapsed;
      }
    }

    /*tsiry;28-05-2021
      * implementation de l'historique
      * */

    public void PreviousOld()
    {

      try
      {
        //LoadOld("Old", _previousCount);
        CleanPawnList();
        var pawnList = new List<Pawn>();
        if (CurrentTurn == "Black")
        {
          WhiteTurnNumber--;

          //LoadOld("Old", true);


          var tempPawnList = HistoricalWhiteList[WhiteTurnNumber];
          foreach (var line in tempPawnList)
          {
            //Debug.WriteLine(line);

            var datas = line.Split(';');
            var bt = (Button)this.FindName(datas[1]);
            var newPawn = new Pawn(datas[0], datas[1], bt, datas[2], this);
            //;{pawn.IsFirstMove};{pawn.IsFirstMoveKing};{pawn.IsLeftRookFirstMove};{pawn.IsRightRookFirstMove}
            newPawn.IsFirstMove = bool.Parse(datas[3]);
            newPawn.IsFirstMoveKing = bool.Parse(datas[4]);
            newPawn.IsLeftRookFirstMove = bool.Parse(datas[5]);
            newPawn.IsRightRookFirstMove = bool.Parse(datas[6]);
            pawnList.Add(newPawn);
          }

          var whiteList = pawnList.Where(x => x.Colore == "White").ToList();
          var blackList = pawnList.Where(x => x.Colore == "Black").ToList();



          FillPawnListAndFillAllPossibleTrips(whiteList, blackList);


          CurrentTurn = "White";

        }
        else if (CurrentTurn == "White")
        {
          BlackTurnNumber--;
          var tempPawnList = HistoricalBlackList[BlackTurnNumber];
          foreach (var line in tempPawnList)
          {
            //Debug.WriteLine(line);

            var datas = line.Split(';');
            var bt = (Button)this.FindName(datas[1]);
            var newPawn = new Pawn(datas[0], datas[1], bt, datas[2], this);
            //;{pawn.IsFirstMove};{pawn.IsFirstMoveKing};{pawn.IsLeftRookFirstMove};{pawn.IsRightRookFirstMove}
            newPawn.IsFirstMove = bool.Parse(datas[3]);
            newPawn.IsFirstMoveKing = bool.Parse(datas[4]);
            newPawn.IsLeftRookFirstMove = bool.Parse(datas[5]);
            newPawn.IsRightRookFirstMove = bool.Parse(datas[6]);
            pawnList.Add(newPawn);
          }

          var whiteList = pawnList.Where(x => x.Colore == "White").ToList();
          var blackList = pawnList.Where(x => x.Colore == "Black").ToList();



          FillPawnListAndFillAllPossibleTrips(whiteList, blackList);
          CurrentTurn = "Black";

        }

        LoadGraveyardFile();

        if (BlackTurnNumber == 0 && WhiteTurnNumber == 0)
          PreviousButon.IsEnabled = false;
      }
      catch (Exception ex)
      {

        WriteInLog(ex.ToString());
      }



    }


    private void GrapheButon_Click(object sender, RoutedEventArgs e)
    {


    }



    private void SwithToServerEngineButon_Click(object sender, RoutedEventArgs e)
    {
      _isInLocalEgine = true;
      ////SwithToServerEngineButon.Visibility = Visibility.Collapsed;
      ////SwithToLocalEngineButon.Visibility = Visibility.Visible;
    }

    private void SwithToLocalEngineButon_Click(object sender, RoutedEventArgs e)
    {
      _isInLocalEgine = false;
      ////SwithToServerEngineButon.Visibility = Visibility.Visible;
      ////SwithToLocalEngineButon.Visibility = Visibility.Collapsed;
    }

    /*tsiry;22-06-2021
     * ajout d'un mode vs le scripte python
     * */

    private void VSPythonButon_Click(object sender, RoutedEventArgs e)
    {
      //VSPythonMoveTo("a2a3");
      // VSPythonGoAndGetAnswer();

      _isVSPythonMode = true;
      if (_isVSPythonMode)
      {
        VSPythonSendNewName();
        ////PythonTurnButon.IsEnabled = _isVSPythonMode;
      }

    }

    private void VSPythonSendNewName()
    {
      var answer = StartClient($"NewGame;5;");
      //return answer;
      //var answerList = answer.Split(';');

    }

    private void VSPythonMoveTo(string fromPositionToPosition)
    {
      var answer = StartClient($"Move;{fromPositionToPosition}");
      //return answer;
      //var answerList = answer.Split(';');

    }

    private void VSPythonGoAndGetAnswer()
    {
      var answer = StartClient($"Go;Go");
      //return answer;
      var answerList = answer.Split(';');
      var fromPosition = answerList[0];
      var toPosition = answerList[1];
      //System.Threading.Thread.Sleep(10000);
      MoveTo(fromPosition, toPosition);
    }

    private void PythonTurnButon_Click(object sender, RoutedEventArgs e)
    {
      VSPythonGoAndGetAnswer();
    }

    #endregion


    /*tsiry;01-10-2021
     * implementation de Rotation
     * */
    public void Rotate()
    {
      try
      {
        _rotationIsRevert = !_rotationIsRevert;
        var angle = 0;
        if (_rotationIsRevert)
        {
          angle = 180;
        }


        var rotate = new RotateTransform(angle);
        ChessBoardGrid.LayoutTransform = rotate;
        BlackTurnButton.LayoutTransform = rotate;
        WhiteTurnButton.LayoutTransform = rotate;
        Label8.LayoutTransform = rotate;
        Label7.LayoutTransform = rotate;
        Label6.LayoutTransform = rotate;
        Label5.LayoutTransform = rotate;
        Label4.LayoutTransform = rotate;
        Label3.LayoutTransform = rotate;
        Label2.LayoutTransform = rotate;
        Label1.LayoutTransform = rotate;
        LabelA.LayoutTransform = rotate;
        LabelB.LayoutTransform = rotate;
        LabelC.LayoutTransform = rotate;
        LabelD.LayoutTransform = rotate;
        LabelE.LayoutTransform = rotate;
        LabelF.LayoutTransform = rotate;
        LabelG.LayoutTransform = rotate;
        LabelH.LayoutTransform = rotate;
        a8.LayoutTransform = rotate;
        a7.LayoutTransform = rotate;
        a6.LayoutTransform = rotate;
        a5.LayoutTransform = rotate;
        a4.LayoutTransform = rotate;
        a3.LayoutTransform = rotate;
        a2.LayoutTransform = rotate;
        a1.LayoutTransform = rotate;

        b8.LayoutTransform = rotate;
        b7.LayoutTransform = rotate;
        b6.LayoutTransform = rotate;
        b5.LayoutTransform = rotate;
        b4.LayoutTransform = rotate;
        b3.LayoutTransform = rotate;
        b2.LayoutTransform = rotate;
        b1.LayoutTransform = rotate;

        c8.LayoutTransform = rotate;
        c7.LayoutTransform = rotate;
        c6.LayoutTransform = rotate;
        c5.LayoutTransform = rotate;
        c4.LayoutTransform = rotate;
        c3.LayoutTransform = rotate;
        c2.LayoutTransform = rotate;
        c1.LayoutTransform = rotate;

        d8.LayoutTransform = rotate;
        d7.LayoutTransform = rotate;
        d6.LayoutTransform = rotate;
        d5.LayoutTransform = rotate;
        d4.LayoutTransform = rotate;
        d3.LayoutTransform = rotate;
        d2.LayoutTransform = rotate;
        d1.LayoutTransform = rotate;

        e8.LayoutTransform = rotate;
        e7.LayoutTransform = rotate;
        e6.LayoutTransform = rotate;
        e5.LayoutTransform = rotate;
        e4.LayoutTransform = rotate;
        e3.LayoutTransform = rotate;
        e2.LayoutTransform = rotate;
        e1.LayoutTransform = rotate;

        f8.LayoutTransform = rotate;
        f7.LayoutTransform = rotate;
        f6.LayoutTransform = rotate;
        f5.LayoutTransform = rotate;
        f4.LayoutTransform = rotate;
        f3.LayoutTransform = rotate;
        f2.LayoutTransform = rotate;
        f1.LayoutTransform = rotate;

        g8.LayoutTransform = rotate;
        g7.LayoutTransform = rotate;
        g6.LayoutTransform = rotate;
        g5.LayoutTransform = rotate;
        g4.LayoutTransform = rotate;
        g3.LayoutTransform = rotate;
        g2.LayoutTransform = rotate;
        g1.LayoutTransform = rotate;

        h8.LayoutTransform = rotate;
        h7.LayoutTransform = rotate;
        h6.LayoutTransform = rotate;
        h5.LayoutTransform = rotate;
        h4.LayoutTransform = rotate;
        h3.LayoutTransform = rotate;
        h2.LayoutTransform = rotate;
        h1.LayoutTransform = rotate;

        SimplePawnWhiteDeadButton.LayoutTransform = rotate;
        SimplePawnWhiteDeadNumberLabel.LayoutTransform = rotate;
        BishopWhiteDeadButton.LayoutTransform = rotate;
        BishopWhiteDeadNumberLabel.LayoutTransform = rotate;
        KnightWhiteDeadButton.LayoutTransform = rotate;
        KnightWhiteDeadNumberLabel.LayoutTransform = rotate;
        RookWhiteDeadButton.LayoutTransform = rotate;
        RookWhiteDeadNumberLabel.LayoutTransform = rotate;
        QueenWhiteDeadButton.LayoutTransform = rotate;
        QueenWhiteDeadNumberLabel.LayoutTransform = rotate;
        BlackPointLabel.LayoutTransform = rotate;

        SimplePawnBlackDeadButton.LayoutTransform = rotate;
        SimplePawnBlackDeadNumberLabel.LayoutTransform = rotate;
        BishopBlackDeadButton.LayoutTransform = rotate;
        BishopBlackDeadNumberLabel.LayoutTransform = rotate;
        KnightBlackDeadButton.LayoutTransform = rotate;
        KnightBlackDeadNumberLabel.LayoutTransform = rotate;
        RookBlackDeadButton.LayoutTransform = rotate;
        RookBlackDeadNumberLabel.LayoutTransform = rotate;
        QueenBlackDeadButton.LayoutTransform = rotate;
        QueenBlackDeadNumberLabel.LayoutTransform = rotate;
        WhitePointLabel.LayoutTransform = rotate;
      }
      catch (Exception ex)
      {

        WriteInLog(ex.ToString());
      }



    }


    public void InitDBConnection()
    {
      if (!_isConnectedDB)
      {
        DisconnetDataBaseButon.Visibility = Visibility.Collapsed;
        ConnetDataBaseButon.Visibility = Visibility.Visible;
        _serviceChessDB = null;
        LoadButton.IsEnabled = false;
        SaveFilesToDBButton.IsEnabled = false;
      }
      else
      {
        DisconnetDataBaseButon.Visibility = Visibility.Visible;
        ConnetDataBaseButon.Visibility = Visibility.Collapsed;
        GenereteBestList();
        _serviceChessDB = new ServiceChessDB();
        LoadButton.IsEnabled = true;
        SaveFilesToDBButton.IsEnabled = true;
      }
    }
    public void SetIsConnectedDB(bool isConnectedDB)
    {
      _isConnectedDB = isConnectedDB;
      InitDBConnection();
    }

    public MainWindow()
    {
      try
      {
        InitializeComponent();

        SaveHistoryToFileButton.IsEnabled = false;
        CpuTurnIndication.Visibility = Visibility.Visible;
        HumanTurnIndication.Visibility = Visibility.Visible;

        /*tsiry;30-09-2021
         * integration de Deep level selection
         * */
        switch (DeeLevel)
        {
          case 5:
            RadioButtonDeepLevel5.IsChecked = true;
            break;
          case 4:
            RadioButtonDeepLevel4.IsChecked = true;
            break;
          case 3:
            RadioButtonDeepLevel3.IsChecked = true;
            break;
          case 2:
            RadioButtonDeepLevel2.IsChecked = true;
            break;
          case 1:
            RadioButtonDeepLevel1.IsChecked = true;
            break;
        }

        InitDBConnection();










        /*tsiry;30-06-2021
          *implementation de la base
          *création d'une partie
          */
        _mode = "Release";
        if (IsDebug)
          _mode = "Debug";



        GamePartComboBox.IsEnabled = false;
        SaveBestPostionsForButon.IsEnabled = false;
        DeleteBestPostionsForButon.Visibility = Visibility.Collapsed;


        NextButon.IsEnabled = false;
        PreviousButon.IsEnabled = false;

        _isVSPythonMode = false;
        ////PythonTurnButon.IsEnabled = _isVSPythonMode;

        HistoricalWhiteList = new List<List<string>>();
        HistoricalBlackList = new List<List<string>>();



        _isInLocalEgine = true;
        ////SwithToServerEngineButon.Visibility = Visibility.Collapsed;
        ////SwithToLocalEngineButon.Visibility = Visibility.Visible;

        //pour les notification
        Notifier = new Notifier(cfg =>
        {
          cfg.PositionProvider = new WindowPositionProvider(
          parentWindow: Application.Current.MainWindow,
          corner: Corner.TopRight,
          offsetX: 10,
          offsetY: 10);

          cfg.LifetimeSupervisor = new TimeAndCountBasedLifetimeSupervisor(
          notificationLifetime: TimeSpan.FromSeconds(3),
          maximumNotificationCount: MaximumNotificationCount.FromCount(5));

          cfg.Dispatcher = Application.Current.Dispatcher;
        });
        //NotificationManagerWindows
        NotificationManagerWindows = new NotificationManager();





        _deadList = new List<string>();
        _graveyardIsLoaded = false;
        _blackCountTime = new DateTime();
        _whiteCountTime = new DateTime();

        WhiteRunEngineButton.IsEnabled = false;
        BlackRunEngineButton.IsEnabled = false;


        FromPosition = "";
        ToPosition = "";
        CaseList = null;
        PawnList = null;
        PawnListWhite = null;
        PawnListBlack = null;
        CaseList = new List<Case>();
        PawnList = new List<Pawn>();
        PawnListWhite = new List<Pawn>();
        PawnListBlack = new List<Pawn>();





        for (int x = 0; x <= 7; x++)
        {
          for (int y = 1; y <= 8; y++)
          {
            var X = Convert.ToChar(97 + x).ToString();
            var Y = y.ToString();
            var bt = (Button)this.FindName(X + Y);
            var location = Convert.ToChar(97 + x).ToString() + y.ToString();

            //initialisation des cases
            CaseList.Add(new Case(Convert.ToChar(97 + x).ToString(), y.ToString(), bt, this));

            //initialisation des pions 
            //SimplePawn
            if (y == 2)
              PawnListWhite.Add(new Pawn("SimplePawn", location, bt, "White", this));
            if (y == 7)
              PawnListBlack.Add(new Pawn("SimplePawn", location, bt, "Black", this));

            //Rook (Tour)
            if (y == 1 && (X == "a" || X == "h"))
              PawnListWhite.Add(new Pawn("Rook", location, bt, "White", this));
            if (y == 8 && (X == "a" || X == "h"))
              PawnListBlack.Add(new Pawn("Rook", location, bt, "Black", this));

            //Knight (chevalier)
            if (y == 1 && (X == "b" || X == "g"))
              PawnListWhite.Add(new Pawn("Knight", location, bt, "White", this));
            if (y == 8 && (X == "b" || X == "g"))
              PawnListBlack.Add(new Pawn("Knight", location, bt, "Black", this));

            //Bishop (fou)
            if (y == 1 && (X == "c" || X == "f"))
              PawnListWhite.Add(new Pawn("Bishop", location, bt, "White", this));
            if (y == 8 && (X == "c" || X == "f"))
              PawnListBlack.Add(new Pawn("Bishop", location, bt, "Black", this));

            //Queen


            if (y == 1 && (X == "d"))
              PawnListWhite.Add(new Pawn("Queen", location, bt, "White", this));
            if (y == 8 && (X == "d"))
              PawnListBlack.Add(new Pawn("Queen", location, bt, "Black", this));

            //King
            if (y == 1 && (X == "e"))
              PawnListWhite.Add(new Pawn("King", location, bt, "White", this));
            if (y == 8 && (X == "e"))
              PawnListBlack.Add(new Pawn("King", location, bt, "Black", this));


          }
        }








        PawnList.AddRange(PawnListWhite.OrderByDescending(x => x.Value));
        PawnList.AddRange(PawnListBlack.OrderByDescending(x => x.Value));
        PawnList = PawnList.OrderByDescending(x => x.Value).ToList();
        FillAllPossibleTrips();





      }
      catch (Exception ex)
      {

        WriteInLog(ex.ToString());
      }





    }

    private void loadeFileButtonButton_Click(object sender, RoutedEventArgs e)
    {
      IsReprise = true;
      LoadOld();
      LoadHistory();

    }
    /*tsiry;06-10-2021
     * quand on Load
     * on charge aussi le dérnier historique
     * */
    private void LoadHistory()
    {
      try
      {
        var readText = File.ReadAllText("./History.txt");
        if (readText.Contains("("))// si History.txt contient un (
            readText = Chess2Utils.HistoryWebToHistoryApp(readText);
        DebugTextBlock.Text = "";
        DebugTextBlock.Text = readText;

                CreateHistoryFileAndWrite(readText);
        //System.GC.Collect();
        // GC.WaitForPendingFinalizers();
        

        var numberOfTurn = readText.Count(x => x == '\n');

        SetTurnNumberLabel(numberOfTurn.ToString());


      }
      catch (Exception ex)
      {

        WriteInLog(ex.ToString());
      }
    }


    /*tsiry;13-08-2021
     * print screen*/

    private void CameratButon_Click(object sender, RoutedEventArgs e)
    {

      try
      {


        //EN pdf
        // var boardGrid = (Grid)this.FindName("ChessBoardGrid");
        // PrintCharts(boardGrid);


        //en image
        var w = 970;
        var h = 890;

        var screen = System.Windows.Application.Current.Windows.OfType<Window>().SingleOrDefault(x => x.IsActive);

        var visual = new DrawingVisual();
        using (var context = visual.RenderOpen())
        {
          context.DrawRectangle(new VisualBrush(screen),
                                null,
                                new Rect(new Point(), new Size(screen.Width, screen.Height)));
        }

        visual.Transform = new ScaleTransform(w / screen.ActualWidth, h / screen.ActualHeight);

        var rtb = new RenderTargetBitmap(w, h, 96, 96, PixelFormats.Pbgra32);
        rtb.Render(visual);

        var enc = new PngBitmapEncoder();
        enc.Frames.Add(BitmapFrame.Create(rtb));

        //Chois du docier de sorte

        CommonOpenFileDialog dialog = new CommonOpenFileDialog();
        var initialDirectory = "";

        dialog.InitialDirectory = initialDirectory;
        dialog.IsFolderPicker = true;
        var destionationPath = "";
        if (dialog.ShowDialog() == CommonFileDialogResult.Ok)
        {
          //BackupPath = dialog.FileName;
          destionationPath = dialog.FileName;
        }

        var destinanitionDirName = destionationPath.Split('\\').Last();

        Save(PawnList, destionationPath);
        var destinationImageName = Path.Combine(destionationPath, $"{destinanitionDirName}.png");
        using (var stm = File.Create(destinationImageName))
        {
          enc.Save(stm);
        }
      }
      catch (Exception ex)
      {

        MessageBox.Show(ex.ToString());
      }
    }

    private void PrintCharts(Grid grid)
    {
      PrintDialog print = new PrintDialog();
      if (print.ShowDialog() == true)
      {
        PrintCapabilities capabilities = print.PrintQueue.GetPrintCapabilities(print.PrintTicket);

        double scale = Math.Min(capabilities.PageImageableArea.ExtentWidth / grid.ActualWidth,
                                capabilities.PageImageableArea.ExtentHeight / grid.ActualHeight);

        Transform oldTransform = grid.LayoutTransform;

        grid.LayoutTransform = new ScaleTransform(scale, scale);

        Size oldSize = new Size(grid.ActualWidth, grid.ActualHeight);
        Size sz = new Size(capabilities.PageImageableArea.ExtentWidth, capabilities.PageImageableArea.ExtentHeight);
        grid.Measure(sz);
        ((UIElement)grid).Arrange(new Rect(new Point(capabilities.PageImageableArea.OriginWidth, capabilities.PageImageableArea.OriginHeight),
            sz));

        print.PrintVisual(grid, "Print Results");
        grid.LayoutTransform = oldTransform;
        grid.Measure(oldSize);

        ((UIElement)grid).Arrange(new Rect(new Point(0, 0),
            oldSize));
      }
    }

    /*tsiry;16-08-2021
     * ajout de la finctionnaliter pour enregistrer les bestPositions
     * pour une couleure*/

    private void SaveBestPostionsForButon_Click(object sender, RoutedEventArgs e)
    {

      try
      {
        _isFromStart = true;
        var turnList = _serviceChessDB.GetGameTurns(_gamePartID);
        var index = turnList.Count - 1 + _navigationInDBIndex;
        var currentTurn = turnList[index];
        //TODO à determiner
        var weigth = 9999999;
        var saveBestPositionsFofWindow = new SaveBestPositionsFofWindow(currentTurn.TurnID, ComputerColore, weigth);

        saveBestPositionsFofWindow.ShowDialog();

        saveBestPositionsFofWindow = null;



        var currentIndex = GamePartComboBox.SelectedIndex;


        LoadDB();
        // GamePartComboBox.SelectedIndex = index;
        //GamePartComboBox.SelectedItem = _serviceChessDB.GetGamePart(_gamePartID);
        //GamePartComboBox.SelectedIndex = turnList.Count - index -1 ;
        GamePartComboBox.SelectedIndex = currentIndex;
        LoadBoardFromIndex(turnList, index);
        SetVisibleOrCollapsedStars(currentTurn);
        _isFromStart = false;
      }
      catch (Exception ex)
      {

        WriteInLog(ex.ToString());
      }


    }

    private void DeleteBestPostionsForButon_Click(object sender, RoutedEventArgs e)
    {
      try
      {
        _isFromStart = true;
        var turnList = _serviceChessDB.GetGameTurns(_gamePartID);
        var index = turnList.Count - 1 + _navigationInDBIndex;
        var currentTurn = turnList[index];
        _serviceChessDB.DeleteBestPostion(currentTurn.TurnID);

        var currentIndex = GamePartComboBox.SelectedIndex;
        LoadDB();
        //((GamePart)GamePartComboBox.SelectedItem).GamePartID;
        //GamePartComboBox.SelectedItem = _serviceChessDB.GetGamePart(_gamePartID);
        // GamePartComboBox.SelectedIndex = turnList.Count- index -1;
        GamePartComboBox.SelectedIndex = currentIndex;

        LoadBoardFromIndex(turnList, index);
        SetVisibleOrCollapsedStars(currentTurn);
        _isFromStart = false;
      }
      catch (Exception ex)
      {

        WriteInLog(ex.ToString());
      }



    }

    private void ConnectDataBaseButon_Click(object sender, RoutedEventArgs e)
    {
      DisconnetDataBaseButon.Visibility = Visibility.Visible;
      ConnetDataBaseButon.Visibility = Visibility.Collapsed;
      LoadButton.IsEnabled = true;
      _serviceChessDB = new ServiceChessDB();
      //GamePartComboBox.IsEnabled = true;
      _isConnectedDB = true;
      SaveFilesToDBButton.IsEnabled = true;
    }

    private void DisconnectDataBaseButon_Click(object sender, RoutedEventArgs e)
    {
      DisconnetDataBaseButon.Visibility = Visibility.Collapsed;
      ConnetDataBaseButon.Visibility = Visibility.Visible;
      LoadButton.IsEnabled = false;
      _serviceChessDB = null;
      GamePartComboBox.SelectedItem = null;
      GamePartComboBox.IsEnabled = false;
      _isConnectedDB = false;
      NextButon.IsEnabled = false;
      PreviousButon.IsEnabled = false;
      SaveFilesToDBButton.IsEnabled = false;

    }

    private void RadioButtonDeepLevel_Checked(object sender, RoutedEventArgs e)
    {
      if (sender == RadioButtonDeepLevel1)
      {
        DeeLevel = 1;
      }
      if (sender == RadioButtonDeepLevel2)
      {
        DeeLevel = 2;
      }
      if (sender == RadioButtonDeepLevel3)
      {
        DeeLevel = 3;
      }
      if (sender == RadioButtonDeepLevel4)
      {
        DeeLevel = 4;
      }
      if (sender == RadioButtonDeepLevel5)
      {
        DeeLevel = 5;
      }
    }

    private void RotationButon_Click(object sender, RoutedEventArgs e)
    {
      Rotate();
    }

        private void CreateHistoryFileAndWrite(string readText)
        {
            try
            {
                if (!String.IsNullOrEmpty(_partHistoryDestinationFileFullPath))
                    return;

                //_serviceChessDB.CreateNewGamePart($"Part {DateTime.Now.ToString("HH-mm-ss dd-MM-yyyy")}", DateTime.Now, _mode);
                var dateTimeString = DateTime.Now.ToString("HH-mm-ss dd-MM-yyyy");
                _partHistoryDestinationFileFullPath = Path.Combine(_destinationHistoryFolderPath, $"{dateTimeString}History.txt");

                if (File.Exists(_partHistoryDestinationFileFullPath))
                    File.Delete(_partHistoryDestinationFileFullPath);

                using (StreamWriter sw = File.CreateText(_partHistoryDestinationFileFullPath))
                {
                    var line = "";
                    using (var sr = new StringReader(readText))
                    {

                        while ((line = sr.ReadLine()) != null)
                        {
                            sw.WriteLine(line);
                        }
                    }

                }

                // File.AppendAllText(_partHistoryDestinationFileFullPath, );

            }
            catch (Exception ex)
            {

                WriteInLog(ex.ToString());
            }
        }

        private void CreateHistoryFile()
    {
      try
      {
        if (!String.IsNullOrEmpty(_partHistoryDestinationFileFullPath))
          return;

        //_serviceChessDB.CreateNewGamePart($"Part {DateTime.Now.ToString("HH-mm-ss dd-MM-yyyy")}", DateTime.Now, _mode);
        var dateTimeString = DateTime.Now.ToString("HH-mm-ss dd-MM-yyyy");
        _partHistoryDestinationFileFullPath = Path.Combine(_destinationHistoryFolderPath, $"{dateTimeString}History.txt");
        File.Create(_partHistoryDestinationFileFullPath);

                
      }
      catch (Exception ex)
      {

        WriteInLog(ex.ToString());
      }
    }

    private void CreateLogFile()
    {
      try
      {
        //_serviceChessDB.CreateNewGamePart($"Part {DateTime.Now.ToString("HH-mm-ss dd-MM-yyyy")}", DateTime.Now, _mode);
        var dateTimeString = DateTime.Now.ToString("HH-mm-ss dd-MM-yyyy");
        _partLogDestinationFileFullPath = Path.Combine(_destinationLogFolderPath, $"{dateTimeString}Log.txt");
        File.Create(_partLogDestinationFileFullPath);
      }
      catch (Exception ex)
      {

        WriteInLog(ex.ToString());
      }
    }

    public void WriteInLog(string message)
    {
      try
      {

        File.AppendAllText(_partLogDestinationFileFullPath + "\n", message);
      }
      catch (Exception ex)
      {
        Debug.WriteLine(ex.ToString());
        //WriteInLog(ex.ToString());
      }
    }

    public void AppEndInPartHistory(string line)
    {
      try
      {
        if (!_isConnectedDB)
        {
          File.AppendAllText(_partHistoryDestinationFileFullPath, line);

          //copy de History sur le repertoir local affin de re reloader lors du chargement des fichiers
          File.Copy(_partHistoryDestinationFileFullPath, "./History.txt", true);

        }

      }
      catch (Exception ex)
      {
        WriteInLog(ex.ToString());
      }
    }

    private void SaveToHistoryTXTButton_Click(object sender, RoutedEventArgs e)
    {
      try
      {
        var historyText = DebugTextBlock.Text;
        historyText.Replace("\n", "");
        var dateTimeString = DateTime.Now.ToString("dd-MM-yy-hh-mm");

        var destinationFileFullPath = Path.Combine(_destinationHistoryFolderPath, $"{dateTimeString}History.txt");
        File.WriteAllText(destinationFileFullPath, historyText);
        MessageBox.Show("Save to file compleded");
        SaveHistoryToFileButton.IsEnabled = false;
      }
      catch (Exception ex)
      {
        WriteInLog(ex.ToString());

      }

    }

    /*tsiry;04-10-2021
     * Implementation de "Eviter partie NUll
     * attibution de DebugTextBlock
     * */
    public void SetDebugTextBlockText(string text)
    {
      DebugTextBlock.Text = text;
    }




    private void SaveHistoriesFilesToDBAndCleanHistoriesFolderButton_Click(object sender, RoutedEventArgs e)
    {
      try
      {
        var historiesFiles = Directory.GetFiles(_destinationHistoryFolderPath, "*History*.txt");
        if (historiesFiles.Count() == 0)
        {
          MessageBox.Show("Historeis does not content Histories files", "Warning");
          return;
        }

        foreach (var historyFile in historiesFiles)
        {

          var lines = File.ReadAllLines(historyFile);

          var tempMainWindows = new MainWindow();
          //var pawnList = copyPawnList(tempMainWindows.PawnList);
          var pawnList = tempMainWindows.PawnList;
          //Une nouvelle Partie
          if (_serviceChessDB == null)
            return;
          //si le ficheir est vide, on passe au suivant
          if (new FileInfo(historyFile).Length == 0)
          {
            continue;
          }

          //./HistoriesFiles/07-59-09 05-10-2021History.txt
          var historyFileDatas = historyFile.Split('/');
          var creationDateString = historyFileDatas[2].Replace("History.txt", "");
          //"07-59-09 05-10-2021"
          var dateDatas = creationDateString.Split(' ');
          var date = dateDatas[1];
          var time = dateDatas[0].Replace("-", ":");
          creationDateString = $"{date} {time}";
          //08-25-3805:10:2021
          //08-25-38 05-10-2021
          //var t_creationDateString = creationDateString;
          var dateTime = Convert.ToDateTime(creationDateString);
          _serviceChessDB.CreateNewGamePart($"Part {creationDateString}", Convert.ToDateTime(creationDateString), _mode);

          var gamePartID = _serviceChessDB.GetLastGamePart().GamePartID;
          _serviceChessDB.InserTurn(gamePartID, pawnList, "");
          foreach (var line in lines)
          {
            //un tour
            if (String.IsNullOrEmpty(line))
              continue;
           // var t_line = line;
            var lineDatas = line.Split(':');
            var currentTurn = lineDatas[0].Trim();
            var fromAndDestinationLocations = lineDatas[1].Split('\t')[2];
            fromAndDestinationLocations = fromAndDestinationLocations.Replace("=>", "");
            fromAndDestinationLocations = fromAndDestinationLocations.Replace(" ", "");
            var fromLocation = fromAndDestinationLocations.Substring(0, 2);
            var toLocation = fromAndDestinationLocations.Substring(2, 2);
            //pawnList = copyPawnList(pawnList);
            var toLocationPawn = pawnList.FirstOrDefault(x => x.Location == toLocation);
            if (toLocationPawn != null)
              pawnList.Remove(toLocationPawn);

           // var t_dd = historyFile;

            var currentPawn = pawnList.FirstOrDefault(x => x.Location == fromLocation);
            // pawnList.Remove(currentPawn);
            if (currentPawn == null)
              break;

            currentPawn.Location = toLocation;

            _serviceChessDB.InserTurn(gamePartID, pawnList, currentTurn);

          }

          //TODO SUPPRESSION DU FICHIER

          File.Delete(historyFile);

        }
        MessageBox.Show("Save histores files to DB compleded");
      }
      catch (Exception ex)
      {

        WriteInLog(ex.ToString());
      }




    }

    private void ClearLogButon_Click(object sender, RoutedEventArgs e)
    {
      try
      {
        var logsFiles = Directory.GetFiles(_destinationLogFolderPath, "*Log*.txt");
        if (logsFiles.Count() == 0)
        {
          MessageBox.Show("Log folder does not content log files", "Warning");
          return;
        }

        foreach (var logFile in logsFiles)
        {
          File.Delete(logFile);
        }

        MessageBox.Show("Clrearing compleded");


      }
      catch (Exception ex)
      {

        WriteInLog(ex.ToString());
      }
    }

    private void Window_Closed(object sender, EventArgs e)
    {

    }

    private void Window_Closing(object sender, CancelEventArgs e)
    {
      System.Windows.Application.Current.Shutdown();
    }
  }

}