import{j as d,A as l,_ as b,o as K,c as _,a as c,b as s,n as x,t as u,d as i,F as v,r as y,u as S,P as f,l as g,f as n,g as k,p as C,h as I,i as P}from"./index.f1d14265.js";class B{async getProfile(a){const r=await d.get("api/profiles/"+a);l.profile=r.data}async getProfileVaults(a){const r=await d.get("api/profiles/"+a+"/vaults");l.profileVaults=r.data}async getProfileKeeps(a){const r=await d.get("api/profiles/"+a+"/keeps");l.profileKeeps=r.data}}const h=new B;const N={setup(){const o=S();async function a(){try{h.getProfile(o.params.id)}catch(t){f.error(t),g.log(t)}}async function r(){try{h.getProfileVaults(o.params.id)}catch(t){f.error(t),g.log(t)}}async function e(){try{h.getProfileKeeps(o.params.id)}catch(t){f.error(t),g.log(t)}}return K(()=>{a(),r(),e()}),{route:o,profile:_(()=>l.profile),vaults:_(()=>l.profileVaults),keeps:_(()=>l.profileKeeps)}}},m=o=>(C("data-v-10e82b60"),o=o(),I(),o),U={key:0,class:"container p-4"},j={class:"row"},A={class:"col-12 text-center"},F=m(()=>s("section",{class:"row"},null,-1)),z=["src"],D={class:"moveUp text-shadow"},E={key:0,class:"moveUp"},L=m(()=>s("section",{class:"row ps-5 mt-5 text-shadow"},[s("h1",null,"Vaults")],-1)),M={key:0,class:"row"},R={class:"col-6 col-md-3"},q=m(()=>s("section",{class:"row p-5 text-shadow"},[s("h1",null,"Keeps")],-1)),G={key:1,class:"masonry pb-5"},H={class:"brick"};function J(o,a,r,e,t,O){const w=P("VaultComponent"),V=P("KeepComponent");return e.profile?(n(),c("div",U,[s("section",{class:"row justify-content-center accountcover rounded",style:x({backgroundImage:`url('${e.profile.coverImg}')`})},null,4),s("section",j,[s("section",A,[F,s("img",{src:e.profile.picture,alt:"",class:"accountpic moveUp rounded-circle elevation-5 border border-white"},null,8,z),s("h1",D,u(e.profile.name),1),e.vaults&&e.keeps?(n(),c("p",E,u(e.vaults.length)+" Vaults | "+u(e.keeps.length)+" Keeps",1)):i("",!0)])]),L,e.vaults?(n(),c("section",M,[(n(!0),c(v,null,y(e.vaults,p=>(n(),c("section",R,[k(w,{vault:p},null,8,["vault"])]))),256))])):i("",!0),q,e.keeps?(n(),c("section",G,[(n(!0),c(v,null,y(e.keeps,p=>(n(),c("div",H,[k(V,{keep:p},null,8,["keep"])]))),256))])):i("",!0)])):i("",!0)}const T=b(N,[["render",J],["__scopeId","data-v-10e82b60"]]);export{T as default};