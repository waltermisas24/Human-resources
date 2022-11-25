using Human.Resources.API.Domain.Entities;
using Human.Resources.API.DTOs;

namespace Human.Resources.API.Mapper
{
    public static class WorkerMapper
    {
        public static WorkerEntity MapWorkerDtoToEntity(WorkerDTO workerDTO)
        {
            WorkerEntity workerEntity = new WorkerEntity
            {
                Id = workerDTO.Id,
                Name = workerDTO.Name,
                LastName = workerDTO.LastName,
                Email = workerDTO.Email,
                PhoneNumber = workerDTO.PhoneNumber,
                WorkerStatus = workerDTO.WorkerStatus
            };
            workerEntity.WorkTitleInfo = new WorkTitleInfoEntity
            {
                WorkTitle = workerDTO.WorkTitle,
                DateIn = workerDTO.DateIn,
                DateOut = workerDTO.DateOut,
                Reason = workerDTO.ReasonOut
            };

            return workerEntity;
        }

        public static WorkerDTO MapWorkerEntityToDTO(WorkerEntity workerEntity)
        {
            WorkerDTO workerDTO = new WorkerDTO
            {
                Id = workerEntity.Id,
                Name = workerEntity.Name,
                LastName = workerEntity.LastName,
                Email = workerEntity.Email,
                PhoneNumber = workerEntity.PhoneNumber,
                WorkerStatus = workerEntity.WorkerStatus,
                WorkTitle = workerEntity.WorkTitleInfo.WorkTitle,
                DateIn = workerEntity.WorkTitleInfo.DateIn,
                DateOut = workerEntity.WorkTitleInfo.DateOut,
                ReasonOut = workerEntity.WorkTitleInfo.Reason
            };

            return workerDTO;
        }

        public static WorkerFiredEntity workerFiredDTOToEntity(WorkerFiredDTO workerFiredDTO)
        {
            WorkerFiredEntity workerFiredEntity = new WorkerFiredEntity()
            {
                DateOut = workerFiredDTO.DateOut,
                ReasonOut = workerFiredDTO.ReasonOut
            };

            return workerFiredEntity;
        }

        public static List<WorkerDTO> MapWorkerEntityToDTO(List<WorkerEntity> workerEntity)
        {
            List<WorkerDTO> workerDTOs = new List<WorkerDTO>();

            foreach (WorkerEntity data in workerEntity)
            {
                WorkerDTO workerDTO = new WorkerDTO();

                workerDTO.Id = data.Id;
                workerDTO.Name = data.Name;
                workerDTO.LastName = data.LastName;
                workerDTO.Email = data.Email;
                workerDTO.PhoneNumber = data.PhoneNumber;
                workerDTO.WorkerStatus = data.WorkerStatus;
                workerDTO.WorkTitle = data.WorkTitleInfo.WorkTitle;
                workerDTO.DateIn = data.WorkTitleInfo.DateIn;
                workerDTO.DateOut = data.WorkTitleInfo.DateOut;
                workerDTO.ReasonOut = data.WorkTitleInfo.Reason;

                workerDTOs.Add(workerDTO);
            }

            return workerDTOs;
        }

        public static UserEntity UserDTOToEntity(string userName, string password)
        {
            UserEntity UserEntity = new UserEntity()
            {
                User = userName,
                Password = password
            };

            return UserEntity;
        }
    }
}
