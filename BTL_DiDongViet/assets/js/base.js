//<![CDATA[

function tog(v) {

      return v ? 'addClass' : 'removeClass';

}

$(document).on('input', '.clearable', function() {

      $(this)[tog(this.value)]('x');

}).on('mousemove', '.x', function(e) {

      $(this)[tog(this.offsetWidth - 18 < e.clientX - this.getBoundingClientRect().left)]('onX');

}).on('touchstart click', '.onX', function(ev) {

      ev.preventDefault();

      $(this).removeClass('x onX').val('').change();

});

//]]>


// Add Bottom Line
const headerBottom = document.querySelectorAll(".stardust-tabs-header__tab");
for (let i = 0; i < headerBottom.length; i++) {
      headerBottom[i].addEventListener("click", showHeaderBottom);
}

function showHeaderBottom() {
      for (let i = 0; i < headerBottom.length; i++) {
            headerBottom[i].className = headerBottom[i].className.replace(" stardust-tabs-header__tab--active", "");
      }
      if (this.className.indexOf("stardust-tabs-header__tab--active") == -1) {
            this.className += " stardust-tabs-header__tab--active";
      }
}

let nums = [0, 1, 2, 3, 4];
console.log(nums.slice(1,6));