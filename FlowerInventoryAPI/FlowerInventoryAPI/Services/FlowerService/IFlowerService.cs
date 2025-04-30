using FlowerInventoryAPI.Entities;

namespace FlowerInventoryAPI.Services.FlowerService
{
    public interface IFlowerService
    {
        public Task<List<Flower>> GetAllFlowers();

        public Task<Flower> GetFlowerByFlowerId(int id);

        public Task<Flower> CreateFlower(Flower flowerRequest);

        public Task<Flower> UpdateFlower(Flower flowerRequest);

        public Task<BaseCommandResponse> DeleteFlower(Flower flowerRequest);
    }
}
