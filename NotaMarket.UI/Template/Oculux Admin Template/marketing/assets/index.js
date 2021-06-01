(function(i,s,o,g,r,a,m){i['GoogleAnalyticsObject']=r;i[r]=i[r]||function(){
(i[r].q=i[r].q||[]).push(arguments)},i[r].l=1*new Date();a=s.createElement(o),
m=s.getElementsByTagName(o)[0];a.async=1;a.src=g;m.parentNode.insertBefore(a,m)
})(window,document,'script','https://www.google-analytics.com/analytics.js','ga');

ga('create', 'UA-62526832-4', 'auto');
ga('send', 'pageview');

var purchaseBtn = document.getElementById('link-purchase');
var htmlAdminBtn = document.getElementById('link-html-a');
var htmlFrontendBtn = document.getElementById('link-html-f');
var vueBtn = document.getElementById('link-vue');

/*
// Wrong
// Category should describe type of event, event should be unique, label is optional dynamic or static data
purchaseBtn.addEventListener('click', function() {
	ga('send', 'event', 'Buttons', 'click', 'Click Purchase button');
});

var links = document.querySelectorAll('a');
forEach(links, function(idx) {
	links[idx].addEventListener('click', function() {
		ga('send', 'event', 'Click', links[idx].title, '_secondsAfterPageInit');
	});
});
*/
// Correct
purchaseBtn.addEventListener('click', function() {
	ga('send', 'event', 'Click', 'Click Purchase button');
});

htmlAdminBtn.addEventListener('click', function(){
	ga('send', 'event', 'Click', 'Check HTML Admin');
});

htmlFrontendBtn.addEventListener('click', function(){
	ga('send', 'event', 'Click', 'Check HTML Frontend');
});

vueBtn.addEventListener('click', function(){
	ga('send', 'event', 'Click', 'Check Vue.js Version');
});
