(window.webpackJsonp=window.webpackJsonp||[]).push([[3],{311:function(t,e,r){"use strict";var n=r(463);e.a=n.a},480:function(t,e,r){"use strict";r.d(e,"a",(function(){return c})),r.d(e,"b",(function(){return d})),r.d(e,"c",(function(){return v}));var n=r(481),o=r(0),c=Object(o.h)("v-card__actions"),l=Object(o.h)("v-card__subtitle"),d=Object(o.h)("v-card__text"),v=Object(o.h)("v-card__title");n.a},481:function(t,e,r){"use strict";r(11),r(7),r(9),r(4),r(15),r(10),r(16);var n=r(2),o=(r(29),r(209),r(210),r(483),r(211)),c=r(482),l=r(92),d=r(13);function v(object,t){var e=Object.keys(object);if(Object.getOwnPropertySymbols){var r=Object.getOwnPropertySymbols(object);t&&(r=r.filter((function(t){return Object.getOwnPropertyDescriptor(object,t).enumerable}))),e.push.apply(e,r)}return e}function h(t){for(var i=1;i<arguments.length;i++){var source=null!=arguments[i]?arguments[i]:{};i%2?v(Object(source),!0).forEach((function(e){Object(n.a)(t,e,source[e])})):Object.getOwnPropertyDescriptors?Object.defineProperties(t,Object.getOwnPropertyDescriptors(source)):v(Object(source)).forEach((function(e){Object.defineProperty(t,e,Object.getOwnPropertyDescriptor(source,e))}))}return t}e.a=Object(d.a)(c.a,l.a,o.a).extend({name:"v-card",props:{flat:Boolean,hover:Boolean,img:String,link:Boolean,loaderHeight:{type:[Number,String],default:4},raised:Boolean},computed:{classes:function(){return h(h({"v-card":!0},l.a.options.computed.classes.call(this)),{},{"v-card--flat":this.flat,"v-card--hover":this.hover,"v-card--link":this.isClickable,"v-card--loading":this.loading,"v-card--disabled":this.disabled,"v-card--raised":this.raised},o.a.options.computed.classes.call(this))},styles:function(){var style=h({},o.a.options.computed.styles.call(this));return this.img&&(style.background='url("'.concat(this.img,'") center center / cover no-repeat')),style}},methods:{genProgress:function(){var t=c.a.options.methods.genProgress.call(this);return t?this.$createElement("div",{staticClass:"v-card__progress",key:"progress"},[t]):null}},render:function(t){var e=this.generateRouteLink(),r=e.tag,data=e.data;return data.style=this.styles,this.isClickable&&(data.attrs=data.attrs||{},data.attrs.tabindex=0),t(r,this.setBackgroundColor(this.color,data),[this.genProgress(),this.$slots.default])}})},482:function(t,e,r){"use strict";r(29);var n=r(1),o=r(311);e.a=n.a.extend().extend({name:"loadable",props:{loading:{type:[Boolean,String],default:!1},loaderHeight:{type:[Number,String],default:2}},methods:{genProgress:function(){return!1===this.loading?null:this.$slots.progress||this.$createElement(o.a,{props:{absolute:!0,color:!0===this.loading||""===this.loading?this.color||"primary":this.loading,height:this.loaderHeight,indeterminate:!0}})}}})},483:function(t,e,r){var content=r(484);content.__esModule&&(content=content.default),"string"==typeof content&&(content=[[t.i,content,""]]),content.locals&&(t.exports=content.locals);(0,r(19).default)("e23b7040",content,!0,{sourceMap:!1})},484:function(t,e,r){var n=r(18)(!1);n.push([t.i,'.theme--light.v-card{background-color:#fff;color:rgba(0,0,0,.87)}.theme--light.v-card>.v-card__subtitle,.theme--light.v-card>.v-card__text{color:rgba(0,0,0,.6)}.theme--dark.v-card{background-color:#1e1e1e;color:#fff}.theme--dark.v-card>.v-card__subtitle,.theme--dark.v-card>.v-card__text{color:hsla(0,0%,100%,.7)}.v-sheet.v-card{border-radius:4px}.v-sheet.v-card:not(.v-sheet--outlined){box-shadow:0 3px 1px -2px rgba(0,0,0,.2),0 2px 2px 0 rgba(0,0,0,.14),0 1px 5px 0 rgba(0,0,0,.12)}.v-sheet.v-card.v-sheet--shaped{border-radius:24px 4px}.v-card{border-width:thin;display:block;max-width:100%;outline:none;text-decoration:none;transition-property:box-shadow,opacity;word-wrap:break-word;position:relative;white-space:normal}.v-card>.v-card__progress+:not(.v-btn):not(.v-chip):not(.v-avatar),.v-card>:first-child:not(.v-btn):not(.v-chip):not(.v-avatar){border-top-left-radius:inherit;border-top-right-radius:inherit}.v-card>:last-child:not(.v-btn):not(.v-chip):not(.v-avatar){border-bottom-left-radius:inherit;border-bottom-right-radius:inherit}.v-card__progress{top:0;left:0;right:0;overflow:hidden}.v-card__subtitle+.v-card__text{padding-top:0}.v-card__subtitle,.v-card__text{font-size:.875rem;font-weight:400;line-height:1.375rem;letter-spacing:.0071428571em}.v-card__subtitle,.v-card__text,.v-card__title{padding:16px}.v-card__title{align-items:center;display:flex;flex-wrap:wrap;font-size:1.25rem;font-weight:500;letter-spacing:.0125em;line-height:2rem;word-break:break-all}.v-card__title+.v-card__subtitle,.v-card__title+.v-card__text{padding-top:0}.v-card__title+.v-card__subtitle{margin-top:-16px}.v-card__text{width:100%}.v-card__actions{align-items:center;display:flex;padding:8px}.v-card__actions>.v-btn.v-btn{padding:0 8px}.v-application--is-ltr .v-card__actions>.v-btn.v-btn+.v-btn{margin-left:8px}.v-application--is-ltr .v-card__actions>.v-btn.v-btn .v-icon--left{margin-left:4px}.v-application--is-ltr .v-card__actions>.v-btn.v-btn .v-icon--right{margin-right:4px}.v-application--is-rtl .v-card__actions>.v-btn.v-btn+.v-btn{margin-right:8px}.v-application--is-rtl .v-card__actions>.v-btn.v-btn .v-icon--left{margin-right:4px}.v-application--is-rtl .v-card__actions>.v-btn.v-btn .v-icon--right{margin-left:4px}.v-card--flat{box-shadow:0 0 0 0 rgba(0,0,0,.2),0 0 0 0 rgba(0,0,0,.14),0 0 0 0 rgba(0,0,0,.12)!important}.v-sheet.v-card--hover{cursor:pointer;transition:box-shadow .4s cubic-bezier(.25,.8,.25,1)}.v-sheet.v-card--hover:focus,.v-sheet.v-card--hover:hover{box-shadow:0 5px 5px -3px rgba(0,0,0,.2),0 8px 10px 1px rgba(0,0,0,.14),0 3px 14px 2px rgba(0,0,0,.12)}.v-card--link,.v-card--link .v-chip{cursor:pointer}.v-card--link:focus:before{opacity:.08}.v-card--link:before{background:currentColor;bottom:0;content:"";left:0;opacity:0;pointer-events:none;position:absolute;right:0;top:0;transition:opacity .2s}.v-card--disabled{pointer-events:none;-webkit-user-select:none;-moz-user-select:none;-ms-user-select:none;user-select:none}.v-card--disabled>:not(.v-card__progress){opacity:.6;transition:inherit}.v-card--loading{overflow:hidden}.v-card--raised{box-shadow:0 5px 5px -3px rgba(0,0,0,.2),0 8px 10px 1px rgba(0,0,0,.14),0 3px 14px 2px rgba(0,0,0,.12)}',""]),t.exports=n},503:function(t,e,r){"use strict";r.r(e);var n={name:"AboutUs",data:function(){return{}},methods:{}},o=r(30),c=r(33),l=r.n(c),d=r(481),v=r(480),h=r(475),m=r(479),_=r(476),component=Object(o.a)(n,(function(){var t=this,e=t.$createElement,r=t._self._c||e;return r("div",[r("div",{staticClass:"feature1-component mini-spacer bg-extra-light"},[r("v-container",[r("v-row",{attrs:{justify:"center"}},[r("v-col",{attrs:{cols:"12",md:"10",lg:"7"}},[r("div",{staticClass:"text-center"},[r("h2",{staticClass:"section-title font-weight-medium"},[t._v("\n              Tec Sol Group y sus lineas de negocios\n            ")]),t._v(" "),r("p",[t._v("\n              Nuestro equipo de trabajo tiene la experiencia en las siguentes lineas de negocio.\n            ")])])])],1),t._v(" "),r("v-row",{staticClass:"mt-13",attrs:{justify:"center"}},[r("v-col",{attrs:{cols:"12",md:"6"}},[r("v-card",{attrs:{elevation:"0"}},[r("v-card-text",[r("div",{staticClass:"icon-round bg-light-info"},[r("i",{staticClass:"mdi mdi-star"})]),t._v(" "),r("h5",{staticClass:"font-weight-medium font-18"},[t._v("Desarrollo de Software escalables")]),t._v(" "),r("p",{staticClass:"mt-10 mb-8"},[t._v("\n                You can relay on our amazing features list and also our\n                customer services will be great experience. Lorem ipsum dolor\n                sit amet, consectetur adipiscing elit. Praesent tristique\n                pellentesque ipsum.\n              ")]),t._v(" "),r("a",{staticClass:"\n                  text-themecolor\n                  linking\n                  text-decoration-none\n                  d-flex\n                  align-center\n                ",attrs:{href:"#"}},[t._v("\n                Explore More "),r("i",{staticClass:"mdi mdi-arrow-right"})])])],1)],1),t._v(" "),r("v-col",{attrs:{cols:"12",md:"6"}},[r("v-card",{attrs:{elevation:"0"}},[r("v-card-text",[r("div",{staticClass:"icon-round bg-light-info"},[r("i",{staticClass:"mdi mdi-check-circle"})]),t._v(" "),r("h5",{staticClass:"font-weight-medium font-18"},[t._v("Desarrollo y Diseño de Aplicaciones y Paginas Web")]),t._v(" "),r("p",{staticClass:"mt-10 mb-8"},[t._v("\n                You can relay on our amazing features list and also our\n                customer services will be great experience. Lorem ipsum dolor\n                sit amet, consectetur adipiscing elit. Praesent tristique\n                pellentesque ipsum.\n              ")]),t._v(" "),r("a",{staticClass:"\n                  text-themecolor\n                  linking\n                  text-decoration-none\n                  d-flex\n                  align-center\n                ",attrs:{href:"#"}},[t._v("\n                Explore More "),r("i",{staticClass:"mdi mdi-arrow-right"})])])],1)],1)],1)],1)],1)])}),[],!1,null,null,null);e.default=component.exports;l()(component,{VCard:d.a,VCardText:v.b,VCol:h.a,VContainer:m.a,VRow:_.a})}}]);