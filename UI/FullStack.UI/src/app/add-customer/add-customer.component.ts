import { Component, OnInit,ViewChild,ElementRef } from '@angular/core';
import { customer } from '../Models/Customer.model';
import { CustomerService } from '../Services/customer.service';
import { Router } from '@angular/router';
import { NgForm } from '@angular/forms';

@Component({
  selector: 'app-add-customer',
  templateUrl: './add-customer.component.html',
  styleUrls: ['./add-customer.component.css']
})
export class AddCustomerComponent implements OnInit {
 addcustomerrequest:customer={
  id:'',
  firstname:'',
  lastname:'',
  gender:'',
  email:'',
  country_code:'',
  balance:0,
  phone_Number:''
 }

 constructor(private srv:CustomerService,private router:Router){

 }
 ngOnInit(){

 }
 addcustomer(){
 //console.log( this.addcustomerrequest);
 this.addcustomerrequest.id="00000000-0000-0000-0000-000000000000";
 this.srv.addCustomer(this.addcustomerrequest).subscribe({
  next:(response)=>{
    //console.log(response);
    this.router.navigate(['/customer'])
  },
  error:(error)=>{
    console.log(error);
  },
  complete:()=>{}
 });

//this.srv.addCustomer1(this.addcustomerrequest);
 }
}
