(window.webpackJsonp=window.webpackJsonp||[]).push([[0],{146:function(e,t,n){e.exports=n(316)},316:function(e,t,n){"use strict";n.r(t);var a=n(0),r=n.n(a),i=n(17),o=n.n(i);Boolean("localhost"===window.location.hostname||"[::1]"===window.location.hostname||window.location.hostname.match(/^127(?:\.(?:25[0-5]|2[0-4][0-9]|[01]?[0-9][0-9]?)){3}$/));var c=n(41),u=n(26),l=n(30),s=n(126),m=n(84),d=n.n(m),p=n(34),E=n(68),f=n(33),h=n(16),g=n(133),b=n.n(g),v=n(134),y=n.n(v),w=n(52),O=n.n(w),x=n(31),j=n.n(x),D=n(28),k=n.n(D),C=n(132),T=n.n(C),M=n(32),N=n(135),P=n.n(N),R=n(136),A=n.n(R),S=n(5),B=n.n(S),G=n(137),U=n.n(G),_=n(85),W=n.n(_),z=n(138),F=n.n(z),I=n(89),L=n.n(I),q=n(66),H=n.n(q),J=n(86),X=n.n(J),V=n(87),$=n.n(V),K=n(129),Q=n.n(K),Y=n(130),Z=n.n(Y),ee=function(e,t){e.history.push("/"+t)},te=Object(p.e)(function(e){return r.a.createElement("div",null,r.a.createElement(H.a,{button:!0,onClick:function(){return ee(e,"groups")}},r.a.createElement(X.a,null,r.a.createElement(Q.a,null)),r.a.createElement($.a,{primary:"Agrupamentos"})),r.a.createElement(H.a,{button:!0,onClick:function(){return ee(e,"relatorios")}},r.a.createElement(X.a,null,r.a.createElement(Z.a,null)),r.a.createElement($.a,{primary:"Relat\xf3rios"})))}),ne=function(e,t){e({anchorEl:null,isMenuExpanded:t})},ae=function(e,t){t({isMenuExpanded:!1}),e.toogleNavigation(!1)},re=Object(u.b)(function(e){return Object(h.a)({},e.navigation)},function(e){return{toogleNavigation:function(t){return e(function(e){return{type:"TOOGLE_MENU",isMenuExpanded:e}}(t))}}})(Object(M.withStyles)(function(e){return{toolbar:{paddingRight:24},toolbarIcon:Object(h.a)({display:"flex",alignItems:"center",justifyContent:"flex-end",padding:"0 8px"},e.mixins.toolbar),appBar:{zIndex:e.zIndex.drawer+1},menuButton:{marginLeft:10,marginRight:36},menuButtonHidden:{display:"none"},title:{flexGrow:1},drawerPaper:{position:"relative",whiteSpace:"nowrap",width:190,transition:e.transitions.create("width",{easing:e.transitions.easing.sharp,duration:e.transitions.duration.enteringScreen})},drawerPaperClose:Object(f.a)({overflowX:"hidden",transition:e.transitions.create("width",{easing:e.transitions.easing.sharp,duration:e.transitions.duration.leavingScreen}),width:7*e.spacing.unit},e.breakpoints.up("sm"),{width:9*e.spacing.unit})}})(function(e){var t=Object(a.useState)({anchorEl:e.anchorEl,isMenuExpanded:e.isMenuExpanded}),n=Object(E.a)(t,2),i=n[0],o=n[1];i.isMenuExpanded!==e.isMenuExpanded&&o({isMenuExpanded:e.isMenuExpanded,anchorEl:e.anchorEl});var c=i.anchorEl,u=i.isMenuExpanded,l=e.classes,s=r.a.createElement(T.a,{anchorEl:c,anchorOrigin:{vertical:"top",horizontal:"right"},transformOrigin:{vertical:"top",horizontal:"right"},open:Boolean(c),onClose:function(){return ne(o,e.isMenuExpanded)}},r.a.createElement(k.a,{onClick:function(){return ne(o,e.isMenuExpanded)}},"Minha conta"),r.a.createElement(k.a,{onClick:function(){return ne(o,e.isMenuExpanded)}},"Sair"));return r.a.createElement(r.a.Fragment,null,r.a.createElement(b.a,{position:"absolute",className:l.appBar},r.a.createElement(y.a,{className:l.toolbar},r.a.createElement(O.a,{color:"inherit","aria-label":"Open drawer",onClick:function(){return function(e,t){t({isMenuExpanded:!0}),e.toogleNavigation(!0)}(e,o)},className:B()(l.menuButton,u&&l.menuButtonHidden)},"  ",r.a.createElement(P.a,null)),r.a.createElement(O.a,{color:"inherit","aria-label":"Close drawer",onClick:function(){return ae(e,o)},className:B()(l.menuButton,!u&&l.menuButtonHidden)},r.a.createElement(L.a,null)),r.a.createElement(j.a,{className:l.title,variant:"h6",color:"inherit",noWrap:!0},"Financeiro"),r.a.createElement(O.a,{"aria-owns":u?"material-appbar":void 0,"aria-haspopup":"true",onClick:function(t){return function(e,t,n){t({anchorEl:e.currentTarget,isMenuExpanded:n})}(t,o,e.isMenuExpanded)},color:"inherit"},r.a.createElement(A.a,null)))),s,r.a.createElement(U.a,{variant:"permanent",classes:{paper:B()(l.drawerPaper,!i.isMenuExpanded&&l.drawerPaperClose)},open:u},r.a.createElement("div",{className:l.toolbarIcon},r.a.createElement(O.a,{onClick:function(){return ae(e,o)}},r.a.createElement(L.a,null))),r.a.createElement(F.a,null),r.a.createElement(W.a,null,r.a.createElement(te,null))))})),ie=n(141),oe=n.n(ie),ce=n(143),ue=n.n(ce),le=n(35),se=n.n(le),me=n(142),de=n.n(me),pe=n(90),Ee=n.n(pe),fe=n(48),he=n.n(fe),ge=n(139),be=n.n(ge),ve=n(140),ye=n.n(ve);var we=Object(u.b)(function(e){return{items:e.group.items}})(Object(p.e)(Object(M.withStyles)(function(e){var t;return{root:{width:"100%",overflowX:"auto"},table:{minWidth:700},tableRow:{cursor:"pointer"},fab:(t={},Object(f.a)(t,e.breakpoints.down("sm"),{position:"absolute",bottom:2*e.spacing.unit,right:2*e.spacing.unit}),Object(f.a)(t,e.breakpoints.up("sm"),{margin:2*e.spacing.unit,float:"right"}),t)}})(function(e){var t=e.classes;return r.a.createElement(r.a.Fragment,null,r.a.createElement(be.a,{color:"primary","aria-label":"Add",className:t.fab,onClick:function(){return ee(e,"groups/new")}},r.a.createElement(ye.a,null)),r.a.createElement(j.a,{variant:"h4",gutterBottom:!0,component:"h2"},"Agrupamentos"),r.a.createElement(he.a,{className:t.root},r.a.createElement(oe.a,{className:t.table},r.a.createElement(de.a,null,r.a.createElement(Ee.a,null,r.a.createElement(se.a,null,"Nome"),r.a.createElement(se.a,{align:"right"},"Prioridade"),r.a.createElement(se.a,{align:"right"},"Tipo"))),r.a.createElement(ue.a,null,e.items.map(function(n){return r.a.createElement(Ee.a,{className:t.tableRow,key:n.uuid,onClick:function(){return ee(e,"groups/edit/".concat(n.uuid))}},r.a.createElement(se.a,{component:"th",scope:"row"},n.name),r.a.createElement(se.a,{align:"right"},n.priority),r.a.createElement(se.a,{align:"right"},n.categoryType))})))))}))),Oe=n(50),xe=n.n(Oe),je=n(53),De=n.n(je),ke=n(69),Ce=n.n(ke),Te=n(49),Me=n.n(Te),Ne=n(70),Pe=n.n(Ne),Re=n(6),Ae=n.n(Re),Se=n(144),Be=n.n(Se),Ge=function(e,t,n,a,r){e.preventDefault(),n.uuid?t.update(n):t.add(n),xe.a.success("Group saved!!"),a?r({uuid:0,priority:1,name:"",categoryType:1}):t.history.push("/groups")},Ue=Object(u.b)(function(e){return{items:e.group.items}},function(e){return{update:function(t){return e({type:"UPDATE_GROUP",item:t})},add:function(t){return e({type:"ADD_GROUP",item:t})},deleteGroup:function(t){return e(function(e){return{type:"DELETE_GROUP",uuid:e}}(t))}}})(Object(p.e)(Ae()(function(e){return{form:{maxWidth:"350px",marginTop:e.spacing.unit},button:{marginTop:3*e.spacing.unit,marginRight:e.spacing.unit}}})(function(e){var t=e.classes,n={uuid:0,priority:1,name:"",categoryType:2},i=parseInt(e.match.params.uuid);if(i){var o=e.items.find(function(e){return e.uuid===i});o?n=o:i=null}var c=Object(a.useState)(Object(h.a)({},n)),u=Object(E.a)(c,2),l=u[0],s=u[1];n.uuid!==l.uuid&&s(Object(h.a)({},n));var m=n.uuid&&0!==n.uuid?r.a.createElement(De.a,{type:"button",variant:"contained",color:"secondary",size:"small",className:t.button,onClick:function(t){return function(e,t){e.deleteGroup(t),xe.a.success("Group deleted!!"),e.history.push("/groups")}(e,l.uuid)}},"Excluir"):r.a.createElement(De.a,{type:"button",variant:"contained",size:"small",className:t.button,onClick:function(t){return Ge(t,e,l,!0,s)}},"Salvar e novo");return r.a.createElement(r.a.Fragment,null,r.a.createElement("div",null,"text"),r.a.createElement(j.a,{component:"h1",variant:"h5"},"Agrupamento"),r.a.createElement("form",{className:t.form,onSubmit:function(t){return Ge(t,e,l,!1,s)}},r.a.createElement("input",{type:"hidden",name:"id",value:l.uuid}),r.a.createElement(Ce.a,{margin:"normal",required:!0,fullWidth:!0},r.a.createElement(Pe.a,{htmlFor:"email"},"Nome"),r.a.createElement(Me.a,{id:"name",name:"name",autoFocus:!0,value:l.name,onChange:function(e){return s(Object(h.a)({},l,{name:e.target.value}))}})),r.a.createElement(Ce.a,{margin:"normal",required:!0,fullWidth:!0},r.a.createElement(Pe.a,{htmlFor:"priority"},"Prioridade"),r.a.createElement(Me.a,{name:"priority",type:"number",step:"1",id:"priority",value:l.priority,onChange:function(e){return s(Object(h.a)({},l,{priority:e.target.value}))}})),r.a.createElement(Ce.a,{margin:"normal",required:!0,fullWidth:!0},r.a.createElement(Pe.a,{htmlFor:"categoryType"},"Tipo"),r.a.createElement(Be.a,{value:l.categoryType,onChange:function(e){return s(Object(h.a)({},l,{categoryType:e.target.value}))},inputProps:{name:"categoryType",id:"categoryType"}},r.a.createElement(k.a,{value:1},"Cr\xe9dito"),r.a.createElement(k.a,{value:2},"D\xe9bito"),r.a.createElement(k.a,{value:3},"Tranfer\xeancia de cr\xe9dito"),r.a.createElement(k.a,{value:4},"Tranfer\xeancia de d\xe9bito"))),r.a.createElement(De.a,{type:"submit",variant:"contained",color:"primary",size:"small",className:t.button},"Salvar"),m,r.a.createElement(De.a,{type:"button",variant:"contained",size:"small",className:t.button,onClick:function(){return function(e){e.history.push("/groups")}(e)}},"Voltar")))}))),_e=n(145),We=n.n(_e),ze=function(e){return{root:{display:"flex"},content:{flexGrow:1,padding:3*e.spacing.unit,height:"100vh",overflow:"auto"},appBarSpacer:e.mixins.toolbar}},Fe=Object(M.withStyles)(ze)(function(e){var t=e.classes;return r.a.createElement("div",{className:t.root},r.a.createElement(We.a,null),r.a.createElement(re,null),r.a.createElement("main",{className:t.content},r.a.createElement("div",{className:t.appBarSpacer}),r.a.createElement("div",{className:[ze.MainContainer,"container"].join(" ")},r.a.createElement(p.c,null,r.a.createElement(p.a,{path:"/groups/new",component:Ue}),r.a.createElement(p.a,{path:"/groups/edit/:uuid",exact:!0,component:Ue}),r.a.createElement(p.a,{path:"/groups",exact:!0,render:function(){return r.a.createElement(we,null)}}),r.a.createElement(p.a,{exact:!0,path:"/",render:function(){return r.a.createElement(we,null)}})))))}),Ie=n(67),Le={products:[{id:1,price:13.5,name:"keyboard",description:"A keyboard full of keys",creationDate:Date()},{id:2,price:7.75,name:"mouse",description:"A mouse with three buttons",creationDate:Date()},{id:3,price:700,name:"laptop",description:"A laptop with screen and a keyboard",creationDate:Date()},{id:4,price:150,name:"monitor",description:"A widescreen monitor",creationDate:Date()},{id:5,price:120.99,name:"desk",description:"A big desk",creationDate:Date()}]},qe=function(e){return 0===e.products.length?0:Math.max.apply(Math,e.products.map(function(e){return e.id}))},He=function(){var e=arguments.length>0&&void 0!==arguments[0]?arguments[0]:Le,t=arguments.length>1?arguments[1]:void 0;switch(t.type){case"ADD_PRODUCT":return function(e,t){return{products:[].concat(Object(Ie.a)(e.products),[Object(h.a)({},t.product,{id:qe(e)+1,creationDate:Date()})])}}(e,t);case"UPDATE_PRODUCT":return function(e,t){return{products:e.products.map(function(e){return e.id===t.product.id?Object(h.a)({},t.product,{creationDate:e.creationDate}):e})}}(e,t);case"DELETE_PRODUCT":return function(e,t){return{products:e.products.filter(function(e){return t.id!==e.id})}}(e,t);default:return e}},Je={items:[{uuid:1,priority:1,name:"keyboard",type:1},{uuid:2,priority:2,name:"keyb222oard",type:2}]},Xe=function(){var e=arguments.length>0&&void 0!==arguments[0]?arguments[0]:Je,t=arguments.length>1?arguments[1]:void 0;switch(t.type){case"ADD_GROUP":return function(e,t){return{items:[].concat(Object(Ie.a)(e.items),[Object(h.a)({},t.item,{uuid:1e4*(new Date).getTime()+621355968e9})])}}(e,t);case"UPDATE_GROUP":return function(e,t){return{items:e.items.map(function(e){return e.uuid===t.item.uuid?Object(h.a)({},t.item):e})}}(e,t);case"DELETE_GROUP":return function(e,t){return{items:e.items.filter(function(e){return t.uuid!==e.uuid})}}(e,t);default:return e}},Ve={anchorEl:null,isMenuExpanded:window.innerWidth>600},$e=function(){var e=arguments.length>0&&void 0!==arguments[0]?arguments[0]:Ve,t=arguments.length>1?arguments[1]:void 0;switch(t.type){case"TOOGLE_MENU":return{anchorEl:null,isMenuExpanded:t.isMenuExpanded};default:return e}},Ke=Object(l.combineReducers)({product:He,group:Xe,navigation:$e}),Qe=Object(l.createStore)(Ke,Object(s.offline)(d.a));xe.a.options={hideDuration:300,timeOut:1200,positionClass:"toast-top-full-width"},o.a.render(r.a.createElement(u.a,{store:Qe},r.a.createElement(c.a,null,r.a.createElement(Fe,null))),document.getElementById("root")),"serviceWorker"in navigator&&navigator.serviceWorker.ready.then(function(e){e.unregister()})}},[[146,1,2]]]);
//# sourceMappingURL=main.dc46ab6a.chunk.js.map