using System.Threading.Tasks;
using LeagueConnector.Enum;
using LeagueConnector.Models.Json;
using LeagueConnector.Static;

namespace LeagueConnector.Api
{
    public class LolLobby : BaseApi
    {
        public LolLobby(Connection connection) : base(connection)
        {

        }

        public async Task<bool> PlayAgainV2()
        {
            return await _connection.Post(Endpoints.V2_LOLLOBBY_PLAYAGAIN, "");
        }

        public async Task<bool> CreatePracticeTool()
        {
            //TODO CREATE MODEL FROM THIS
            var data = "{\"customGameLobby\":{\"configuration\":{\"gameMode\":\"CLASSIC\",\"gameMutator\":\"PracticeTool\",\"gameTypeConfig\":{\"id\":1},\"mapId\":11,\"teamSize\":1},\"lobbyName\":\"Game\"},\"isCustom\":true,\"mapId\":11}";
            return await _connection.Post(Endpoints.V1_LOLLOBBY_LOBBY, data);
        }

        public async Task<bool> CustomStartChampSelect()
        {
            return await _connection.Post(Endpoints.V1_LOLOBBY_LOBBY_CUSTOM_STARTCHAMPSELECT, "");
        }

        public async Task<bool> DeleteLobby()
        {
            return await _connection.Delete(Endpoints.V2_LOLLOBBY_LOBBY);
        }

        public async Task<bool> ResponseInvite(ReceivedInvitation invite, EBasicAccept status)
        {
            return await _connection.Post(Endpoints.V2_LOLLOBBY_RECEIVED_INVITATIONS + $"/{invite.InvitationId}/{status.ToString().ToLower()}", "");
        }
    }
}