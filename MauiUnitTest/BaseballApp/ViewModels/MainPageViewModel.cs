using System;
using System.Collections.ObjectModel;
using BaseballApp.Models;
using BaseballApp.Services;

namespace BaseballApp.ViewModels;

//This is the view model which will have the main
//logics for the main page which make it easier to maintain and unit test
public class MainPageViewModel
{
    public ObservableCollection<Player> Players { get;}
    private PlayerService playerService;

    private Player? selectedPlayer;
    public Player? SelectedPlayer
    {
        get { return selectedPlayer; }
        set
        {
            if (selectedPlayer == value || value == null)
                return;

            selectedPlayer = value;

            //pass the selected player to the view
            //this will notify the view in mainpage.xaml.cs to do navigation
            //this allow us to keep only logic while view will handle UI related navigation
            OnPlayerSelected?.Invoke(value);
        }
    }

    // We will use event Action to notify the view when to do navigation.
    //It can do more than navigation but for this example we are using it with navigation
    public event Action<Player>? OnPlayerSelected;

    public MainPageViewModel()
    {
        this.playerService = new PlayerService(new ObservableCollection<Player>());
        this.Players = this.playerService.Players;
    }

    public async Task LoadPlayersAsync()
    {
        await this.playerService.LoadPlayers();
    }

}
