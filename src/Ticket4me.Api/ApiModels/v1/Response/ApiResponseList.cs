﻿using Ticket4me.Application.Common.v1;

namespace Ticket4me.Api.ApiModels.v1.Response;

public class ApiResponseList<TItemData>
    : ApiResponse<IReadOnlyList<TItemData>>
{
    public ApiResponseListMeta Meta { get; private set; }

    public ApiResponseList(
        int currentPage,
        int perPage,
        int total,
        IReadOnlyList<TItemData> data
    ) : base(data)
    {
        Meta = new ApiResponseListMeta(currentPage, perPage, total);
    }

    public ApiResponseList(
        PaginatedListOutput<TItemData> paginatedListOutput
    ) : base(paginatedListOutput.Items)
    {
        Meta = new ApiResponseListMeta(
            paginatedListOutput.Page,
            paginatedListOutput.PerPage,
            paginatedListOutput.Total
        );
    }
}
