using MediatR;
using Ticket4me.Application.UseCases.v1.Category.Common.v1;

namespace Ticket4me.Application.UseCases.v1.Category.CreateCategory;
public interface ICreateCategory : IRequestHandler<CreateCategoryInput, CategoryModelOutput> { }
