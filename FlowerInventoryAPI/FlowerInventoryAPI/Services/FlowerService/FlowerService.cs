using FlowerInventoryAPI.Entities;
using Microsoft.EntityFrameworkCore;

namespace FlowerInventoryAPI.Services.FlowerService
{
    public class FlowerService : IFlowerService
    {
        private readonly ProjectDbContext _projectDbContext;

        public FlowerService(ProjectDbContext projectDbContext)
        {
            _projectDbContext = projectDbContext;
        }

        public async Task<List<Flower>> GetAllFlowers()
        {
            try
            {
                var list = _projectDbContext.Flower.Include(f => f.Category).ToList();
                return list;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public async Task<Flower> GetFlowerByFlowerId(int id)
        {
            try
            {
                var flower = _projectDbContext.Flower.Include(f=>f.Category).FirstOrDefault(f=>f.FlowerId == id);
                if(flower == null)
                {
                    return null;
                } else
                {
                    return flower;
                }
            }catch (Exception ex)
            {
                throw ex;
            }
        }

        public async Task<Flower> CreateFlower(Flower flowerRequest)
        {
            try
            {
                if(flowerRequest == null || flowerRequest.Name == null)
                {
                    throw new Exception("Either the object is null or the Flower name is null. Please check your object again.");
                }
                else
                {
                    _projectDbContext.Flower.Add(flowerRequest);
                    _projectDbContext.SaveChanges();
                    return flowerRequest;
                }
                    
            }catch(Exception ex)
            {
                throw ex;
            }
        }

        public async Task<Flower> UpdateFlower(Flower flowerRequest)
        {
            try
            {
                var flowerExists = _projectDbContext.Flower.AsNoTracking().Include(f=>f.Category).FirstOrDefault(f=>f.FlowerId==flowerRequest.FlowerId);
                if(flowerExists != null)
                {
                    _projectDbContext.Flower.Update(flowerRequest);
                    _projectDbContext.SaveChanges();

                    return _projectDbContext.Flower.Include(f=>f.Category).FirstOrDefault(f=>f.FlowerId==flowerRequest.FlowerId);
                } else
                {
                    throw new Exception("Flower does not exists in the Database.");
                }
            } catch (Exception ex)
            {
                throw ex;
            }
        }

        public async Task<BaseCommandResponse> DeleteFlower(Flower flowerRequest)
        {
            try
            {
                
                _projectDbContext.Flower.Remove(flowerRequest);
                _projectDbContext.SaveChanges();


                BaseCommandResponse response = new BaseCommandResponse
                {
                    Id = flowerRequest.FlowerId,
                    Entity = "Flower",
                    Message = "Flower has been deleted from the Database."
                };
               
                return response;



            }catch(Exception ex)
            {
                throw ex;
            }
        }
        
    }
}
