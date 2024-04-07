$(document).ready(function () {
    $('#moviesTable').DataTable({
        "order": [[2, "desc"]],
        "dom": '<"top"f>rt<"bottom"lip>'
    });
});
