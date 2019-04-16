namespace OnlineBookStoreDemo.Services.Data
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    using Microsoft.EntityFrameworkCore;
    using OnlineBookStoreDemo.Data.Common.Repositories;
    using OnlineBookStoreDemo.Data.Models;
    using OnlineBookStoreDemo.Services.Models.Catalog;

    public class CategoriesService : ICategoriesService
    {
        private readonly IDeletableEntityRepository<Category> categoriesRepository;

        public CategoriesService(IDeletableEntityRepository<Category> categoriesRepository)
        {
            this.categoriesRepository = categoriesRepository;
        }

        public IEnumerable<CategoryViewModel> GetAll()
        {
            // TODO: Mapping
            var allCategories = this.categoriesRepository.All()
                .Select(x => new CategoryViewModel
                {
                    Name = x.Name,
                    Id = x.Id,
                })
                .ToList();

            return allCategories;
        }

        public IEnumerable<CategoryViewModel> GetAllSubCategoriesByParentId(int? parentCategoryId)
        {
            if (parentCategoryId.HasValue && parentCategoryId > 0)
            {
                // TODO: Mapping

                // getting all sub categories of the parent category
                var allSubCategories = this.categoriesRepository.All()
                    .Where(x => x.ParentCategoryId == parentCategoryId)
                    .Select(x => new CategoryViewModel
                    {
                        Id = x.Id,
                        Name = x.Name,
                        ParentCategoryId = x.ParentCategoryId,
                        ParentCategoryName = x.ParentCategory.Name,
                        SubCategories = x.SubCategories
                        .Select(s => new SubCategoryViewModel
                        {
                            Id = s.Id,
                            Name = s.Name,
                            ParentId = s.ParentCategoryId,
                            ParentName = s.ParentCategory.Name,
                        })
                        .ToList(),
                    })
                    .ToList();

                return allSubCategories;
            }
            else
            {
                return null;
            }
        }

        public CategoryViewModel GetCategoryById(int? categoryId)
        {
            if (!categoryId.HasValue || categoryId <= 0)
            {
                return null;
            }

            // TODO: Mapping
            var category = this.categoriesRepository.All()
                .Where(x => x.Id == categoryId)
                .Select(x => new CategoryViewModel
                {
                    Name = x.Name,
                    Id = x.Id,
                    ParentCategoryId = x.ParentCategoryId,
                    ParentCategoryName = x.ParentCategory.Name,
                    SubCategories = x.SubCategories
                    .Select(s => new SubCategoryViewModel
                    {
                        Id = s.Id,
                        Name = s.Name,
                        ParentId = s.ParentCategoryId,
                        ParentName = s.ParentCategory.Name,
                    }).ToList(),
                })
                .FirstOrDefault();

            return category;
        }

        public IEnumerable<CategoryViewModel> GetAllMainCategories()
        {
            // TODO: Mapping
            var mainCategories = this.categoriesRepository.All()
                .Where(x => !(x.ParentCategoryId.HasValue))
                .Select(x => new CategoryViewModel
                {
                    Name = x.Name,
                    Id = x.Id,
                })
                .ToList();
            return mainCategories;
        }

        public CategoryViewModel GetCategoryRootById(int? categoryId)
        {
            if (!categoryId.HasValue || categoryId <= 0)
            {
                return null;
            }

            CategoryViewModel categoryRoot = this.GetCategoryById(categoryId);
            if (categoryRoot.ParentCategoryId.HasValue)
            {
                var parentId = categoryRoot.ParentCategoryId;
                return this.GetCategoryRootById(parentId);
            }
            else
            {
                return categoryRoot;
            }
        }

        public List<CategoryIdAndNameViewModel> GetAllParentsById(int? categoryId)
        {
            if (!categoryId.HasValue || categoryId <= 0)
            {
                return null;
            }

            var category = this.categoriesRepository.All()
                .Include(x => x.ParentCategory)
                .AsEnumerable()
                .Where(x => x.Id == categoryId)
                .FirstOrDefault();

            var allParentsList = new List<CategoryIdAndNameViewModel>();

            var parent = category.ParentCategory;

            while (!(parent is null))
            {
                allParentsList.Add(new CategoryIdAndNameViewModel { Id = parent.Id, Name = parent.Name });
                parent = parent.ParentCategory;
            }

            allParentsList.Reverse();

            return allParentsList;
        }

        public NavigationCategoryViewModel GetNavigationCategoryById(int? categoryId)
        {
            if (!categoryId.HasValue || categoryId <= 0)
            {
                return null;
            }

            var navigationCategory = this.categoriesRepository.All()
                .Where(x => x.Id == categoryId)
                .Select(x => new NavigationCategoryViewModel
                {
                    Id = x.Id,
                    Name = x.Name,
                    SubCategoriesList = x.SubCategories
                    .Select(s => new CategoryIdAndNameViewModel
                    {
                        Id = s.Id,
                        Name = s.Name,
                    })
                    .ToList(),
                })
                .FirstOrDefault();

            navigationCategory.ParentsList = this.GetAllParentsById(categoryId);

            return navigationCategory;
        }
    }
}
