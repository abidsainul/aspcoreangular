import { VehicleService } from '../services/vehicle.service';
import { ChangeDetectorRef, Component, OnInit } from '@angular/core';

@Component({
  selector: 'app-vehicle-form',
  templateUrl: './vehicle-form.component.html',
  styleUrls: ['./vehicle-form.component.css']
})
export class VehicleFormComponent implements OnInit {
  makes: any;
  vehicle : any = {};
  models:any;
  features:any;
  constructor(private vehicleService : VehicleService) { }

  ngOnInit() {
    this.vehicleService.getMakes().subscribe(res=> {
      this.makes = res;
     // this.ref.detectChanges()
      console.log("MAKES",this.makes); 
    });

    this.vehicleService.getFeatures().subscribe(res=> {
      this.features = res;
     // this.ref.detectChanges()
      console.log("Features",this.features); 
    });
  }

  onMakeChange(){
    var selectedmake = this.makes.find(x=>x.id == this.vehicle.make);
    this.models = selectedmake ? selectedmake.models : [];
    console.log("VEHICLE",this.vehicle);
    console.log("Models",this.models);
  }

}
