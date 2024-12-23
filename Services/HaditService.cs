
using haditApi.Data;
using haditApi.Models;
using haditApi.Services;

using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

using System.Reflection.Metadata.Ecma335;
using System.Text.Json;

using static System.Runtime.InteropServices.JavaScript.JSType;

namespace haditApi
{
    public class HaditService
    {
        private readonly dbContext _dbContext;
        private readonly Security security;
        public HaditService(dbContext dbContext, Security security)
        {
            _dbContext = dbContext;
            this.security = security;
        }
        public ApiResponse<List<Category>> GetCategories()
        {
            try
            {
                var cates = _dbContext.Categories.AsQueryable();
                cates = cates.Include(i => i.Hadits);
                var result = cates.Where(i=>i.Hadits!=null && i.Hadits.Count()>0).Select(i=> new Category
                {
                    Id = i.Id,
                    Name = i.Name,
                    AddedAt = i.AddedAt
                }).ToList();
                return new ApiResponse<List<Category>>(true, Data: result);
            }
            catch (Exception ex)
            {
                return new ApiResponse<List<Category>>(false, ex.Message);
            }
        }
        public ApiResponse<List<Category>> GetCategories2()
        {
            try
            {
                var cates = _dbContext.Categories.AsQueryable();
                cates = cates.Include(i => i.Hadits);
                var res = cates.Where(i=>i.Hadits!=null && i.Hadits.Count()>0).ToList();
                return new ApiResponse<List<Category>>(true, "",Data: res);
            }
            catch (Exception ex)
            {
                return new ApiResponse<List<Category>>(false, ex.Message);
            }
        }
        public ApiResponse<List<Category>> GetCategoriesXidthHadites()
        {
            try
            {
                var cates = _dbContext.Categories.AsQueryable();
                cates = cates.Include(i => i.Hadits);
                var res = cates.Select(i=> new Category { Id = i.Id, Name = i.Name, AddedAt = i.AddedAt, Hadits = i.Hadits.Select(h=> new Hadit
                {
                    Id = h.Id,
                    CategoryId = h.CategoryId,
                    AddedAt = h.AddedAt,
                    Content = h.Content,
                    OnPublisher = h.OnPublisher
                }) }).ToList();
                var jsonString = System.Text.Json.JsonSerializer.Serialize(res);

                return new ApiResponse<List<Category>>(true, Data: res.OrderByDescending(i=>i.Hadits?.Count()).ToList());
            }
            catch (Exception ex)
            {
                return new ApiResponse<List<Category>>(false, $"{ex.Message} --- {ex.InnerException}");
            }
        }
        public ApiResponse<List<Category>> SearchByName(string name)
        {
            try
            {
                var cates = _dbContext.Categories.Where(i => i.Name.Contains(name))?.ToList();
                return new ApiResponse<List<Category>>(true, Data: cates);

            }
            catch (Exception ex)
            {
                return new ApiResponse<List<Category>>(false, ex.Message);
            }
        }
        public ApiResponse<Category> GetCategory(int id)
        {
            try
            {
                var cate = _dbContext.Categories.Where(i => i.Id == id).FirstOrDefault();
                return new ApiResponse<Category>(true, Data: cate);
            }
            catch (Exception ex)
            {
                return new ApiResponse<Category>(false, ex.Message);
            }
        }
        public ApiResponse<List<Hadit>> GetHaditsByCategory(int id)
        {
            try
            {
                var hadtis = _dbContext.Hadites.Where(i => i.CategoryId == id).ToList();
                return new ApiResponse<List<Hadit>>(true, Data: hadtis);
            }
            catch (Exception ex)
            {
                return new ApiResponse<List<Hadit>>(false, ex.Message);
            }
        }
        public ApiResponse<List<Hadit>> GetHadits()
        {
            try
            {
                var hadits = _dbContext.Hadites.ToList();
                return new ApiResponse<List<Hadit>>(true, Data: hadits);
            }
            catch (Exception ex)
            {
                return new ApiResponse<List<Hadit>>(false, ex.Message);
            }
        }
        public static string RemoveDiacritics(string text)
        {
            if (string.IsNullOrWhiteSpace(text))
                return text;

            string[] arabicDiacritics = new string[]
            {
                "\u064B", // Fathatan
                "\u064C", // Dammatan
                "\u064D", // Kasratan
                "\u064E", // Fatha
                "\u064F", // Damma
                "\u0650", // Kasra
                "\u0651", // Shadda
                "\u0652", // Sukun
                "\u0653", // Mddah
                "\u0654", //Hamza above
                "\u0655", //Hamza bellow
                "\u0657",  //Damma
                "\u0621", // hhamza
                "\u0621", // hhamza
                "\u0658",
                "\u0659",
                "\u065A",
                "\u065B",
                "\u065C",
                "\u065D",
                "\u065E",
                "\u065F",
                "\u0660",
                "\u066B",
                "\u066C",
                "\u0670",
                "\u0671",
                "\u0672",
                "\u0673",
                "\u0674",
                "\u0675",
                "\u0676",
                "\u0678",
                "\u06D8",
                "\u06DC",
            };

            foreach (var diacritic in arabicDiacritics)
            {
                text = text.Replace(diacritic, string.Empty);
            }

            return text;
        }
        public ApiResponse<List<Hadit>> SearchByContent(string name)
        {
            try
            {
                var _haditss = _dbContext.Hadites.ToList();
                var normalizedInput = RemoveDiacritics(name);
                
                var hadits = _dbContext.Hadites.ToList()
                    .Where(i => RemoveDiacritics(i.Content).Contains(normalizedInput)|| RemoveDiacritics(i.OnPublisher).Contains(normalizedInput))
                    ?.ToList();

                return new ApiResponse<List<Hadit>>(true, Data: hadits);

            }
            catch (Exception ex)
            {
                return new ApiResponse<List<Hadit>>(false, ex.Message);
            }
        }
        public ApiResponse<Hadit> GetHadit(int id)
        {
            try
            {
                var cate = _dbContext.Hadites.Where(i => i.Id == id).FirstOrDefault();
                return new ApiResponse<Hadit>(true, Data: cate);
            }
            catch (Exception ex)
            {
                return new ApiResponse<Hadit>(false, ex.Message);
            }
        }
        public ApiResponse PostHadites(ApiPost<List<Hadit>> data)
        {
            try
            {

                if (!security.CheckKey(data.Key))
                    data.Data.ForEach(item =>
                    {
                        item.Confirmed = true;
                    });
                else
                    data.Data.ForEach(item =>
                    {
                        item.Confirmed = false;
                    });

                _dbContext.AddRange(data.Data);
                _dbContext.SaveChanges();
                return new ApiResponse(Success: true);
            }catch(Exception ex)
            {
                return new ApiResponse(false,ex.Message);
            }
        }
    }
}