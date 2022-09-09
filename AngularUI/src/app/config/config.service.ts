import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { Observable, throwError } from 'rxjs';
import { catchError, retry } from 'rxjs/operators';
import { AuthResponse } from "../model/authResponse";
import { Offer } from "../model/Offer";
import { Employee } from "../model/Employee";
import { messageResponse } from '../model/messageResponse';

@Injectable({
  providedIn: 'root'
})

//service to call all the microservice
export class ConfigService {

  //authentication microservice
  loginserviceUrl = "https://localhost:44305/api/Authenticate"

  //offer microservice
  offerserviceUrl = "https://localhost:44389/api/Offer"

  //employee microservice
  employeeserviceUrl ="https://localhost:44351/api/Employee"

  //points microservice
  pointsserviceUrl = "https://localhost:44385/api/Points"

  constructor(private http: HttpClient) { }

  //------------------------authentication microservice calls -----------------------
  //retrieve token after login
  getUserToken(empDetails: any) {
    return this.http.post<AuthResponse>(this.loginserviceUrl, empDetails);
  }



  //--------------------offer microservice calls --------------------------------
  //get offers by category
  getOffers(token: string, category: string) {
    //let options = {
      //headers: { "Authorization": "Bearer " + token}
    //}
    return this.http.get<Offer[]>(this.offerserviceUrl + "/GetOfferByCategory/" + category)
  }

  //get offers by top likes ( top 3 offers)
  getOffersByTopLikes(token: string) {
    //let options = {
      //headers: { "Authorization": "Bearer " + token }
    //}
    return this.http.get<Offer[]>(this.offerserviceUrl + "/GetOfferByTopThreeLikes")
  }

  //get offers by posted date
  getOffersByPostedDate(token: string, postedDate: string) {
    //let options = {
      //headers: { "Authorization": "Bearer " + token }
    //}
    return this.http.get<Offer[]>(this.offerserviceUrl + "/GetOfferByOpenedDate/" + postedDate)
  }

  //get offer details for a particular offer
  getOfferDetailsById(token: string, id: number) {
    //let options = {
      //headers: { "Authorization": "Bearer " + token }
    //}
    return this.http.get<Offer>(this.offerserviceUrl + "/GetOfferById/" + id)
  }

  //update the offer details 
  updateOffer(token: String, offer: Offer) {
    //let options = {
      //headers: { "Authorization": "Bearer " + token }
    //}
    return this.http.put<Offer>(this.offerserviceUrl + '/EditOffer', offer)
  }

  //add a new offer
  addOffer(token: String, offer: Offer) {
    //let options = {
      //headers: { "Authorization": "Bearer " + token }
    //}
    return this.http.post<Offer>(this.offerserviceUrl + "/PostOffer", offer)
  }

  //engage an offer
  engageOffer(token: String, offerId: number, empId: number) {
    let options = {
      headers: { "Authorization": "Bearer " + token },
      params: { "offerId": offerId, "employeeId": empId }
    }
    return this.http.post<Offer>(this.offerserviceUrl + "/engageOffer", null, options)
  }



  //---------------------------------employee microservice calls -------------------------------
  //save the like of the user
  saveLike(token: string, id: number) {
    let options = {
      headers: { "Authorization": "Bearer " + token }
    }
    return this.http.get<Offer>(this.offerserviceUrl + "/LikeOffer/" + id,  options)
  }

  //get the profile of the user
  getProfile(token: String, id: number) {
    let options = {
      headers: { "Authorization": "Bearer " + token }
    }
    return this.http.get<Employee>(this.employeeserviceUrl + "/GetEmployeeProfile/" + id, options)
  }

  //retrive all the offers of the user
  getMyOffers(token: String, id: number) {
    //let options = {
      //headers: { "Authorization": "Bearer " + token }
    //}
    return this.http.get<Offer[]>(this.employeeserviceUrl + "/ViewEmployeeOffers/" + id)
  }

  //retrived user's recently liked posts
  getRecentlyLiked(token: string) {
    let options = {
      headers: { "Authorization": "Bearer " + token },
    }
    return this.http.get<Offer[]>(this.employeeserviceUrl + "/recentlyLiked",options)
  }



  //---------------------------------points microservice calls ----------------------------------
  //refresh the points of the user
  updatePoints(token: String, id: number) {
    let options = {
      headers: { "Authorization": "Bearer " + token }
    }
    return this.http.get<Employee>(this.pointsserviceUrl + "/RefreshPointsByEmployee/" + id, options)

    //return this.http.post<messageResponse>(this.pointsserviceUrl + "/RefreshPointsByEmployee/" + id, null, options)
  }

}