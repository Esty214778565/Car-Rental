using AutoMapper;
using CarRental.Core.DTOs;
using CarRental.Core.Entities;
using CarRental.Core.IRepository;
using CarRental.Core.IService;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.ConstrainedExecution;
using System.Text;
using System.Threading.Tasks;

namespace CarRental.Service
{
    public class CollectionPointService : ICollectionPointService
    {

     
        readonly IRepository<CollectionPointEntity> _CollectionPointRepository;
        readonly IMapper _mapper;
        public CollectionPointService(IRepository<CollectionPointEntity> collectionPointRepository,IMapper mapper)
        {
            _CollectionPointRepository = collectionPointRepository;
            _mapper = mapper;
        }

        public List<CollectionPointDto> GetCollectionPointList()
        {
            var list= _CollectionPointRepository.GetAllDataAsync();
            var listDto=_mapper.Map<IEnumerable<CollectionPointDto>>(list);
            return listDto.ToList();
        }

        public CollectionPointDto GetCollectionPointById(int id)
        {
            var collectionPoint= _CollectionPointRepository.GetById(id);
            return _mapper.Map<CollectionPointDto>(collectionPoint);
        }

        public bool Add(CollectionPointDto CollectionPoint)
        {

            if (_CollectionPointRepository.GetIndexById(CollectionPoint.Id) >-1)
                return false;
            return _CollectionPointRepository.Add(_mapper.Map<CollectionPointEntity>(CollectionPoint));
        }

        public bool Update(CollectionPointDto CollectionPoint)
        {
            if (_CollectionPointRepository.GetIndexById(CollectionPoint.Id)<0)
                return false;
            return _CollectionPointRepository.Update(_mapper.Map<CollectionPointEntity>(CollectionPoint));
        }

        public bool Delete(int id)
        {

            if (_CollectionPointRepository.GetIndexById(id) < 0)
                return false;
            return _CollectionPointRepository.Delete(id);
        }

    }

}
