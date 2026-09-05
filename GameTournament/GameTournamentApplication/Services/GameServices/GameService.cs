using GameTournamentApplication.Common.Errors;
using GameTournamentApplication.Common.Results;
using GameTournamentApplication.Services.GameServices.DTOs;
using GameTournamentDomain.Entities;
using GameTournamentInfrastructure.Persistence;
using Microsoft.EntityFrameworkCore;

namespace GameTournamentApplication.Services.GameServices
{
    public class GameService : IGameService
    {
        private readonly ChampionDbContext _championDbContext;

        public GameService(ChampionDbContext championDbContext)
        {
            _championDbContext = championDbContext;
        }

        public async Task<Result> AddGameAsync(CreateGameDTO createGameDTO,CancellationToken cancellationToken)
        {
            var gameName = createGameDTO.Name.Trim();
            var normalizedGameName = gameName.ToLower();

            if (string.IsNullOrWhiteSpace(gameName))
            {
                return Result.Failure(Error.Validation("نام بازی نمی‌تواند خالی باشد"));
            }

            var exists = await _championDbContext.Games
                .AnyAsync(x => x.Name.Trim().ToLower() == normalizedGameName, cancellationToken);

            if (exists)
            {
                return Result.Failure(Error.Conflict("این بازی قبلاً ثبت شده است"));
            }

            var game = new Game
            {
                Name = gameName,
                Description = createGameDTO.Description?.Trim(),
                IsActive = createGameDTO.IsActive
            };

            await _championDbContext.Games.AddAsync(game, cancellationToken);

            await _championDbContext.SaveChangesAsync(cancellationToken);

            return Result.Success();
        }


        public async Task<Result> DeleteGameAsync(int gameId, CancellationToken cancellationToken)
        {
            var game = await _championDbContext.Games
                .FirstOrDefaultAsync(x => x.Id == gameId, cancellationToken);

            if (game is null)
            {
                return Result.Failure(Error.NotFound("بازی موردنظر پیدا نشد"));
            }

            _championDbContext.Games.Remove(game);

            await _championDbContext.SaveChangesAsync(cancellationToken);

            return Result.Success();
        }


        public async Task<Result<List<GameDTO>>> GetAllAsync(CancellationToken cancellationToken)
        {
            var games = await _championDbContext.Games
                .AsNoTracking()
                .Select(x => new GameDTO
                {
                    Id = x.Id,
                    Name = x.Name,
                    Description = x.Description,
                    IsActive = x.IsActive
                })
                .ToListAsync(cancellationToken);

            return Result<List<GameDTO>>.Success(games);
        }



        public async Task<Result<GameDTO>> GetByIdAsync(int gameId, CancellationToken cancellationToken)
        {
            var game = await _championDbContext.Games
                .AsNoTracking()
                .Where(x => x.Id == gameId)
                .Select(x => new GameDTO
                {
                    Id = x.Id,
                    Name = x.Name,
                    Description = x.Description,
                    IsActive = x.IsActive
                })
                .FirstOrDefaultAsync(cancellationToken);

            if (game is null)
            {
                return Result<GameDTO>.Failure(Error.NotFound("بازی موردنظر پیدا نشد"));
            }

            return Result<GameDTO>.Success(game);
        }



        public async Task<Result> UpdateGameAsync(UpdateGameDTO updateGameDTO, int gameId, CancellationToken cancellationToken)
        {
            var game = await _championDbContext.Games
                .FirstOrDefaultAsync(x => x.Id == gameId, cancellationToken);

            if (game is null)
            {
                return Result.Failure(Error.NotFound("بازی موردنظر پیدا نشد"));
            }

            var duplicateName = await _championDbContext.Games
                .AnyAsync(x => x.Name == updateGameDTO.Name && x.Id != gameId, cancellationToken);

            if (duplicateName)
            {
                return Result.Failure(Error.Conflict("بازی دیگری با این نام وجود دارد"));
            }

            game.Name = updateGameDTO.Name;
            game.Description = updateGameDTO.Description;
            game.IsActive = updateGameDTO.IsActive;

            await _championDbContext.SaveChangesAsync(cancellationToken);

            return Result.Success();
        }
    }
}
