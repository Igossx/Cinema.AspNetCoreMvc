$(document).ready(function () {
    const currentPage = location.pathname;
    $('.nav-tabs li a').each(function () {
        const $this = $(this);
        if (currentPage.toLowerCase().indexOf($this.attr('href').toLowerCase()) !== -1) {
            $this.addClass('active');
        }
    });
});
