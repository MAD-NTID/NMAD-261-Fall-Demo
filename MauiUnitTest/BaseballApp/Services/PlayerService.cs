using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Diagnostics;
using BaseballApp.Models;

namespace BaseballApp.Services;

public class PlayerService
{
    public ObservableCollection<Player> Players{get;}

    public PlayerService(ObservableCollection<Player> players)
    {
        this.Players = players;
    }

    public async Task Add(Player player)
    {

        if(player== null)
            throw new ArgumentException("Player cannot be null");

		//add the new player to the collection
		Players.Add(player);
		//add to the storage
		List<Player> playersToSave = Players.ToList();
		await Storage.Save(playersToSave);
    }

    public async Task LoadPlayers()
    {
        Players.Clear();

        List<Player> loadedPlayers = await Storage.LoadAsync();
        foreach (var player in loadedPlayers)
        {
            Players.Add(player);
        }
    }


    
}