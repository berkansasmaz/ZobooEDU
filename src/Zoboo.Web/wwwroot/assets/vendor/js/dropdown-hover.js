!function(t,e){var o=function(t){var e={};function o(n){if(e[n])return e[n].exports;var r=e[n]={i:n,l:!1,exports:{}};return t[n].call(r.exports,r,r.exports,o),r.l=!0,r.exports}return o.m=t,o.c=e,o.d=function(t,e,n){o.o(t,e)||Object.defineProperty(t,e,{enumerable:!0,get:n})},o.r=function(t){"undefined"!=typeof Symbol&&Symbol.toStringTag&&Object.defineProperty(t,Symbol.toStringTag,{value:"Module"}),Object.defineProperty(t,"__esModule",{value:!0})},o.t=function(t,e){if(1&e&&(t=o(t)),8&e)return t;if(4&e&&"object"==typeof t&&t&&t.__esModule)return t;var n=Object.create(null);if(o.r(n),Object.defineProperty(n,"default",{enumerable:!0,value:t}),2&e&&"string"!=typeof t)for(var r in t)o.d(n,r,function(e){return t[e]}.bind(null,r));return n},o.n=function(t){var e=t&&t.__esModule?function(){return t.default}:function(){return t};return o.d(e,"a",e),e},o.o=function(t,e){return Object.prototype.hasOwnProperty.call(t,e)},o.p="",o(o.s=257)}({257:function(t,e){!function(t){if(t&&t.fn){var e="[data-toggle=dropdown][data-trigger=hover]",o=150;t(function(){t("body").on("mouseenter","".concat(e,", ").concat(e," ~ .dropdown-menu"),function(){t(this).hasClass("dropdown-toggle")?t(this):t(this).prev(".dropdown-toggle");var o,n,r=t(this).hasClass("dropdown-menu")?t(this):t(this).next(".dropdown-menu");"static"!==window.getComputedStyle(r[0],null).getPropertyValue("position")&&(t(this).is(e)&&t(this).data("hovered",!0),o=t(this).hasClass("dropdown-toggle")?t(this):t(this).prev(".dropdown-toggle"),(n=o.data("dd-timeout"))&&(clearTimeout(n),n=null,o.data("dd-timeout",n)),"true"!==o.attr("aria-expanded")&&o.dropdown("toggle"))}).on("mouseleave","".concat(e,", ").concat(e," ~ .dropdown-menu"),function(){t(this).hasClass("dropdown-toggle")?t(this):t(this).prev(".dropdown-toggle");var n,r,d=t(this).hasClass("dropdown-menu")?t(this):t(this).next(".dropdown-menu");"static"!==window.getComputedStyle(d[0],null).getPropertyValue("position")&&(t(this).is(e)&&t(this).data("hovered",!1),n=t(this).hasClass("dropdown-toggle")?t(this):t(this).prev(".dropdown-toggle"),(r=n.data("dd-timeout"))&&clearTimeout(r),r=setTimeout(function(){var t=n.data("dd-timeout");t&&(clearTimeout(t),t=null,n.data("dd-timeout",t)),"true"===n.attr("aria-expanded")&&n.dropdown("toggle")},o),n.data("dd-timeout",r))}).on("hide.bs.dropdown",function(o){t(this).find(e).data("hovered")&&o.preventDefault()})})}}(window.jQuery)}});if("object"==typeof o){var n=["object"==typeof module&&"object"==typeof module.exports?module.exports:null,"undefined"!=typeof window?window:null,t&&t!==window?t:null];for(var r in o)n[0]&&(n[0][r]=o[r]),n[1]&&"__esModule"!==r&&(n[1][r]=o[r]),n[2]&&(n[2][r]=o[r])}}(this);