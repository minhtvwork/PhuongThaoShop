using PTS.Domain.Entities;

namespace PTS.Domain.Dto
{
    public class TokenDto
    {
        public string AccessToken { get; set; }
        public string RefreshToken { get; set; }
    }
}