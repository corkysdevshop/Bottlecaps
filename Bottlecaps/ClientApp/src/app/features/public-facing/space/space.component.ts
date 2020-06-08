import { Component, Inject, OnInit, ViewChild } from '@angular/core';
import { BottlecapService } from '../../private/my-bottlecaps/bottlecap.service';
import { SpaceAreaComponent } from './space-area/space-area.component';
import { Bottlecap } from '../../../shared/models';

@Component({
  selector: 'app-space',
  templateUrl: './space.component.html',
  styleUrls: ['./space.component.css']
})
export class SpaceComponent implements OnInit{
	@ViewChild(SpaceAreaComponent, { static: false }) spaceArea: SpaceAreaComponent;

	constructor(private bottlecapService: BottlecapService) { }

	ngOnInit() {
		this.bottlecapService.getBottlecaps(1); //TODO: THIS SHOULD PASS AN ARRAY OF BOTTLCAP IDS AND RETURN AN ARRAY SLICE TO HOLD IN THIS COMPONENT, HOWEVER FOR NOW I'LL JUST REFERENCE THE BOTTLECAP SERVICE TO GET THE IDS TO PLACE IN THE SPACE
	}
	placeBottlecap(bottlecap) {
		console.log("index: ", bottlecap.selectedIndex);
		console.log("value: ", bottlecap.value);
		this.spaceArea.placeBottlecap(bottlecap.value);
	}
}
