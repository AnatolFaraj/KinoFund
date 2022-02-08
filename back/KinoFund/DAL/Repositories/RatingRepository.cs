using Core.Interfaces;
using DAL.data;
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Repositories
{
    public class RatingRepository : IRatingRepository
    {
        private readonly MyContext _dbContext;

        public RatingRepository(MyContext context)
        {
            _dbContext = context;
        }

        public int GetValueByMovieId(long movieId)
        {
            var inParam = new SqlParameter("@movieId", movieId);
            var outParam = new SqlParameter
            {
                ParameterName = "@outputValue",
                SqlDbType = System.Data.SqlDbType.Int,
                Direction = System.Data.ParameterDirection.Output,

            };

            var procedure = _dbContext.Database.ExecuteSqlRaw("spGetTotalMovieRating @movieId, @outputValue OUT", inParam, outParam);

            return Convert.ToInt32(outParam.Value);
        }

        
    }
}
