using CommunicationLayer;
using DataAccessLayer;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLogicLayer
{
    public class FeeBLL
    {
        rainbowjanakpuriEntities dbcontext = new rainbowjanakpuriEntities();
        //public Collection<FeeGroupCL> viewFeeGroups(int sessionId)
        //{
        //    Collection<FeeGroupCL> queryFeeGroups = new Collection<FeeGroupCL>();
        //    IEnumerable<FeeGroup> queryFeeGroupDB = from x in dbcontext.FeeGroups where x.SessionId == sessionId && x.IsDeleted == false select x;
        //    foreach (FeeGroup item in queryFeeGroupDB)
        //    {
        //        queryFeeGroups.Add(
        //            new FeeGroupCL()
        //            {
        //                description = item.Description,
        //                id = item.Id,
        //                months = item.Months,
        //                name = item.Name,
        //                sessionId = item.SessionId,
        //                session = item.Session.StartingYear + "-" + item.Session.EndingYear,
        //            });
        //    }
        //    return queryFeeGroups;
        //}
        //public FeeGroupCL viewFeeGroupById(int feeId)
        //{
        //    FeeGroup query = (from x in dbcontext.FeeGroups where x.Id == feeId && x.IsDeleted == false select x).FirstOrDefault();
        //    FeeGroupCL feeGroup = new FeeGroupCL()
        //    {
        //        dateCreated = query.DateCreated,
        //        dateModified = query.DateModified,
        //        description = query.Description,
        //        id = query.Id,
        //        isDeleted = query.IsDeleted,
        //        months = query.Months,
        //        name = query.Name,
        //        sessionId = query.SessionId,
        //        session= query.Session.StartingYear + "-" + query.Session.EndingYear,
        //    };
        //    return feeGroup;
        //}
        //public FeeGroupCL addFeeGroup(FeeGroupCL feeInput)
        //{
        //    FeeGroup feeQuery = dbcontext.FeeGroups.Add(new FeeGroup
        //    {
        //        Description = feeInput.description,
        //        Id = feeInput.id,
        //        Months = feeInput.months,
        //        Name = feeInput.name,
        //        SessionId = feeInput.sessionId,
        //        IsDeleted = feeInput.isDeleted,
        //        DateCreated = feeInput.dateCreated,
        //        DateModified = feeInput.dateModified,
        //    });
        //    dbcontext.SaveChanges();
        //    FeeGroupCL returnFeeGroup = new FeeGroupCL()
        //    {
        //        description = feeQuery.Description,
        //        id = feeQuery.Id,
        //        months = feeQuery.Months,
        //        name = feeQuery.Name,
        //        sessionId = feeQuery.SessionId,
        //        dateCreated = feeQuery.DateCreated,
        //        dateModified = feeQuery.DateModified,
        //        isDeleted = feeQuery.IsDeleted,
        //    };
        //    return returnFeeGroup;
        //}
        //public FeeGroupCL updateFeeGroup(FeeGroupCL feeInput)
        //{
        //    FeeGroup feeQuery = (from x in dbcontext.FeeGroups where x.Id == feeInput.id && x.IsDeleted == false select x).FirstOrDefault();
        //    feeQuery.DateCreated = feeInput.dateCreated;
        //    feeQuery.DateModified = feeInput.dateModified;
        //    feeQuery.IsDeleted = feeInput.isDeleted;
        //    feeQuery.Months = feeInput.months;
        //    feeQuery.Name = feeInput.name;
        //    dbcontext.SaveChanges();
        //    FeeGroupCL returnFee = new FeeGroupCL()
        //    {
        //        description = feeQuery.Description,
        //        id = feeQuery.Id,
        //        months = feeQuery.Months,
        //        name = feeQuery.Name,
        //        sessionId = feeQuery.SessionId,
        //        dateCreated = feeQuery.DateCreated,
        //        dateModified = feeQuery.DateModified,
        //        isDeleted = feeQuery.IsDeleted,
        //    };
        //    return returnFee;
        //}
        public void deleteFeeGroup(int feeinput)
        {
            //FeeGroup feeQuery = (from x in dbcontext.FeeGroups where x.Id == feeinput && x.IsDeleted == false select x).FirstOrDefault();
            //feeQuery.IsDeleted = true;
            //dbcontext.SaveChanges();
        }
        //public Collection<FeeClassMapCL> viewFeeClassMaps()
        //{
        //    Collection<FeeClassMapCL> queryFeeClassMaps = new Collection<FeeClassMapCL>();
        //    IEnumerable<ClassFeeMap> queryFeeClassMapDB = from x in dbcontext.ClassFeeMaps select x;
        //    foreach (ClassFeeMap item in queryFeeClassMapDB)
        //    {
        //        queryFeeClassMaps.Add(
        //            new FeeClassMapCL()
        //            {
        //                classId = item.ClassId,
        //                feeId = item.FeeId,
        //                id = item.Id,
        //            });
        //    }
        //    return queryFeeClassMaps;
        //}
        //public FeeClassMapCL addFeeClassMap(FeeClassMapCL feeClassInput)
        //{
        //    ClassFeeMap feeClassMap = dbcontext.ClassFeeMaps.Add(new ClassFeeMap()
        //    {
        //        ClassId = feeClassInput.classId,
        //        FeeId = feeClassInput.feeId,
        //        Id = feeClassInput.id,
        //    });
        //    FeeClassMapCL returnClassFeeMap = new FeeClassMapCL()
        //    {
        //        id = feeClassMap.Id,
        //        feeId = feeClassMap.Id,
        //        classId = feeClassMap.ClassId,
        //    };
        //    return returnClassFeeMap;
        //}
        //public FeeClassMapCL updateFeeClassMap(FeeClassMapCL feeClassInput)
        //{
        //    ClassFeeMap feeClassMap = (from x in dbcontext.ClassFeeMaps where x.Id == feeClassInput.id select x).FirstOrDefault();
        //    feeClassMap.FeeId = feeClassInput.feeId;
        //    feeClassMap.ClassId = feeClassInput.classId;
        //    dbcontext.SaveChanges();
        //    FeeClassMapCL returnClassFeeMap = new FeeClassMapCL()
        //    {
        //        id = feeClassMap.Id,
        //        feeId = feeClassMap.Id,
        //        classId = feeClassMap.ClassId,
        //    };
        //    return returnClassFeeMap;
        //}
        public void deleteFeeClassMap(int feeClassInput)
        {
            //ClassFeeMap feeClassMap = (from x in dbcontext.ClassFeeMaps where x.Id == feeClassInput select x).FirstOrDefault();
            //dbcontext.ClassFeeMaps.Remove(feeClassMap);
            //dbcontext.SaveChanges();
        }
    }
}
