import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import { AddOfferComponent } from './add-offer/add-offer.component';
import { ContactUsComponent } from './contact-us/contact-us.component';
import { HomepageComponent } from './homepage/homepage.component';
import { LoginComponent } from './login/login.component';
import { MainpageComponent } from './mainpage/mainpage.component';
import { MyOffersComponent } from './my-offers/my-offers.component';
import { OfferDetailsComponent } from './offer-details/offer-details.component';
import { OfferEditComponent } from './offer-edit/offer-edit.component';
import { ProfileComponent } from './profile/profile.component';

const routes: Routes = [
  //login page
  { path: 'login', component: LoginComponent },

  //welcome page
  { path: 'homepage', component: HomepageComponent },

  //homepage once logged in
  { path: 'main', component: MainpageComponent},

  //get offer details for a particular offer
  { path: 'offerDetails/:id', component: OfferDetailsComponent},

  //profile of the user
  { path: 'profile', component: ProfileComponent},

  //all the offers of the user
  { path: 'myOffers', component: MyOffersComponent},

  //edit an offer of the user
  { path: 'editOffer/:id', component: OfferEditComponent},

  //add a new offer
  { path: 'addOffer', component: AddOfferComponent },

  //redirection route
  { path: '', redirectTo: "/homepage", pathMatch: "full" },

  //contact us
  { path: 'contactUs', component: ContactUsComponent }
];

@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule]
})
export class AppRoutingModule { }
