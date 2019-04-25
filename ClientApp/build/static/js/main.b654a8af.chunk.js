(window.webpackJsonp=window.webpackJsonp||[]).push([[0],{21:function(e,t,n){e.exports={Error:"Validation_Error__3W5SM"}},26:function(e,t,n){e.exports={MainContainer:"App_MainContainer__3gr_b"}},28:function(e,t,n){e.exports={Product:"ProductItem_Product__1Insr"}},32:function(e,t,n){e.exports={ButtonsArea:"ProductForm_ButtonsArea__1cXLG"}},33:function(e,t,n){e.exports={ViewProduct:"ViewProduct_ViewProduct__2Wekl"}},36:function(e,t,n){e.exports=n(55)},55:function(e,t,n){"use strict";n.r(t);var a=n(0),r=n.n(a),c=n(14),o=n.n(c);Boolean("localhost"===window.location.hostname||"[::1]"===window.location.hostname||window.location.hostname.match(/^127(?:\.(?:25[0-5]|2[0-4][0-9]|[01]?[0-9][0-9]?)){3}$/));var i=n(3),u=n(6),l=n(16),s=(n(45),n(46),n(9)),d=n(26),m=n.n(d),p=function(e){var t=e.links.map(function(e){return r.a.createElement(i.b,{className:"navbar-item",to:e.path,exact:!0},e.label)});return r.a.createElement("nav",{className:"navbar is-primary",role:"navigation","aria-label":"main navigation"},r.a.createElement("div",{className:"navbar-menu"},r.a.createElement("div",{className:"navbar-start"},t)))},E=function(){return r.a.createElement(p,{links:[{path:"/",label:"Products"},{path:"/new",label:"Add new product"}]})},f=n(28),b=n.n(f),v=function(e){return parseFloat(e).toFixed(2)},h=function(e){return new Date(e).toLocaleDateString("en-US",{hour:"2-digit",minute:"2-digit"})},D=n(17),P=n.n(D),g=Object(u.b)(null,function(e){return{deleteProduct:function(t){return e(function(e){return{type:"DELETE_PRODUCT",id:e}}(t))}}})(function(e){return r.a.createElement("div",{className:"buttons"},r.a.createElement(i.b,{className:"button is-info",to:"/view/"+e.productId},"View"),r.a.createElement(i.b,{className:"button is-primary",to:"/edit/"+e.productId},"Edit"),r.a.createElement("button",{className:"button is-danger",onClick:function(){return t=e.deleteProduct,n=e.productId,P.a.success("Product deleted!"),void t(n);var t,n}},"Delete"))}),w=function(e){return r.a.createElement("div",{className:[b.a.Product,"column","is-one-quarter"].join(" ")},r.a.createElement("p",null,e.product.name),r.a.createElement("strong",null,"U$ ",v(e.product.price)),r.a.createElement("div",null,"created at: ",h(e.product.creationDate)),r.a.createElement(g,{productId:e.product.id}))},N=Object(u.b)(function(e){return{products:e.products}})(function(e){Object(a.useEffect)(function(){document.title="This app has "+e.products.length+" products"});var t=e.products.map(function(e){return r.a.createElement(w,{key:e.id,product:e})});return r.a.createElement("div",{className:"columns is-multiline"},t)}),O=function(e){return function(t){var n=parseInt(t.match.params.id),a=t.items.find(function(e){return e.id===n});return a?r.a.createElement(e,Object.assign({},t,{item:a})):r.a.createElement(s.a,{to:"/"})}},_=n(10),j=n(35),y=n(29),k=n.n(y),A=n(30),x=n.n(A),C=n(20),T=n.n(C),U=n(31),S=n.n(U),I=n(32),M=n.n(I),R=n(21),V=n.n(R),B=function(e,t){if(!e.toString().trim().length)return r.a.createElement("p",{className:V.a.Error},t.name+" is required")},F=function(e,t){if(e<=t.min)return r.a.createElement("p",{className:V.a.Error},t.name+" should be greater than "+t.min)},L=Object(s.f)(function(e){var t=Object(a.useState)({id:e.product.id,price:e.product.price,name:e.product.name,description:e.product.description}),n=Object(j.a)(t,2),c=n[0],o=n[1];return r.a.createElement(k.a,{onSubmit:function(t){return function(e,t,n){e.preventDefault(),t.saveProduct(n),t.history.push("/"),P.a.success("Product saved!")}(t,e,c)}},r.a.createElement("input",{type:"hidden",name:"id",value:c.id}),r.a.createElement("div",{className:"control"},r.a.createElement("label",{className:"label"},"Name"),r.a.createElement(T.a,{className:"input",type:"text",name:"name",value:c.name,onChange:function(e){return o(Object(_.a)({},c,{name:e.target.value}))},validations:[B]})),r.a.createElement("div",{className:"control"},r.a.createElement("label",{className:"label"},"Price"),r.a.createElement(T.a,{type:"number",name:"price",step:"0.01",min:"0",value:c.price,validations:[B,F],onChange:function(e){return o(Object(_.a)({},c,{price:e.target.value}))}})),r.a.createElement("div",{className:"control"},r.a.createElement("label",{className:"label"},"Description"),r.a.createElement(S.a,{className:"textarea",name:"description",value:c.description,onChange:function(e){return o(Object(_.a)({},c,{description:e.target.value}))},validations:[B]},c.description)),r.a.createElement("div",{className:[M.a.ButtonsArea,"control","buttons"].join(" ")},r.a.createElement(x.a,{className:"button is-primary",type:"submit"},"Save"),r.a.createElement(i.b,{className:"button is-link",to:"/"},"Show product list")))}),W=Object(u.b)(function(e){return{items:e.products}},function(e){return{updateProduct:function(t){return e(function(e){return{type:"UPDATE_PRODUCT",product:e}}(t))}}})(O(function(e){return r.a.createElement(L,{saveProduct:e.updateProduct,product:e.item})})),$=n(33),q=n.n($),J=Object(u.b)(function(e){return{items:e.products}})(O(function(e){return r.a.createElement("div",{className:q.a.ViewProduct},r.a.createElement("p",null,e.item.name),r.a.createElement("strong",null,"U$ ",v(e.item.price)),r.a.createElement("div",null,"created at: ",h(e.item.creationDate)),r.a.createElement("div",{className:"content"},e.item.description),r.a.createElement(i.b,{className:"button is-info",to:"/"},"Show list"))})),G=Object(u.b)(null,function(e){return{addProduct:function(t){return e(function(e){return{type:"ADD_PRODUCT",product:e}}(t))}}})(function(e){return r.a.createElement(L,{saveProduct:e.addProduct,product:{id:0,price:0,name:"",description:""}})}),X=function(){return r.a.createElement(r.a.Fragment,null,r.a.createElement(E,null),r.a.createElement("div",{className:[m.a.MainContainer,"container"].join(" ")},r.a.createElement(s.d,null,r.a.createElement(s.b,{path:"/new",component:G}),r.a.createElement(s.b,{path:"/edit/:id",exact:!0,component:W}),r.a.createElement(s.b,{path:"/view/:id",exact:!0,component:J}),r.a.createElement(s.b,{path:"/",render:function(){return r.a.createElement(N,null)}}))))},z=n(34),H={products:[{id:1,price:13.5,name:"keyboard",description:"A keyboard full of keys",creationDate:Date()},{id:2,price:7.75,name:"mouse",description:"A mouse with three buttons",creationDate:Date()},{id:3,price:700,name:"laptop",description:"A laptop with screen and a keyboard",creationDate:Date()},{id:4,price:150,name:"monitor",description:"A widescreen monitor",creationDate:Date()},{id:5,price:120.99,name:"desk",description:"A big desk",creationDate:Date()}]},K=function(e){return 0===e.products.length?0:Math.max.apply(Math,e.products.map(function(e){return e.id}))},Q=function(){var e=arguments.length>0&&void 0!==arguments[0]?arguments[0]:H,t=arguments.length>1?arguments[1]:void 0;switch(t.type){case"ADD_PRODUCT":return function(e,t){return{products:[].concat(Object(z.a)(e.products),[Object(_.a)({},t.product,{id:K(e)+1,creationDate:Date()})])}}(e,t);case"UPDATE_PRODUCT":return function(e,t){return{products:e.products.map(function(e){return e.id===t.product.id?Object(_.a)({},t.product,{creationDate:e.creationDate}):e})}}(e,t);case"DELETE_PRODUCT":return function(e,t){return{products:e.products.filter(function(e){return t.id!==e.id})}}(e,t);default:return e}},Y=Object(l.b)(Q);o.a.render(r.a.createElement(u.a,{store:Y},r.a.createElement(i.a,null,r.a.createElement(X,null))),document.getElementById("root")),"serviceWorker"in navigator&&navigator.serviceWorker.ready.then(function(e){e.unregister()})}},[[36,1,2]]]);
//# sourceMappingURL=main.b654a8af.chunk.js.map