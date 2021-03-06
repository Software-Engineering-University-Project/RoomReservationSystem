using System;
using System.Collections.Generic;
using System.Windows.Forms;
using RoomReservationSyster;

namespace RoomReservationSystem.UserInterface
{
    public partial class FormNewRoom : Form
    {
        private FormMode _mode;
        
        private RoomManager _roomManager;
        public FormNewRoom(RoomManager roomManager, FormMode mode)
        {
            InitializeComponent();
            _mode = mode;
            _roomManager = roomManager;
            FillMealsComboBox();
            FillFacilitiesComboBox();
            FillTypesOfBedComboBox();
            FillStandardComboBox();
            if (mode == FormMode.Edit)
            {
                FillWithRoomInformation(roomManager.CurrentRoom);
            }
        }
        
        private void confirmButton_Click(object sender, EventArgs e)
        {
            
            List<BedType> beds = new List<BedType>();
            foreach (var item in typesOfBedList.Items)
            {
                beds.Add((BedType)Enum.Parse(typeof(BedType), item.ToString(), true));
            }

            List<Meals> meals = new List<Meals>();
            foreach (var item in mealsList.Items)
            {
                meals.Add((Meals)Enum.Parse(typeof(Meals), item.ToString(), true));
            }

            List<RoomFacilities> facilitiesEnumList = new List<RoomFacilities>();
            foreach (var item in facilitiesList.Items)
            {
                facilitiesEnumList.Add((RoomFacilities)Enum.Parse(typeof(RoomFacilities), item.ToString(), true));
            }

            RoomState state;
            if (this.isOutOfService.Checked)
            {
                state = RoomState.OutOfUse;
            }
            else
            {
                state = RoomState.Available;
            }
            
            if (_mode == FormMode.NewElement)
            {
                string commentText;
                if (this.comment.Text.Length != 0)
                {
                    commentText = comment.Text;
                }
                else
                {
                    commentText = "";
                }
                try
                {
                    if (_roomManager.Insert(roomName.Text, Convert.ToDouble(price.Text),
                        Convert.ToDouble(squareMeters.Text),
                        Convert.ToInt32(maxNumGuests.Text), state, beds, meals, facilitiesEnumList,
                        standardComboBox.GetItemText(this.standardComboBox.SelectedItem), commentText))
                    {
                        InformationPopup.ShowDialog("Room added successfully.", "Information");
                    }
                    else
                    {
                        InformationPopup.ShowDialog("Room was not added successfully.", "Warning");
                    }
                }
                catch (Exception ex)
                {
                    InformationPopup.ShowDialog("Blank values not allowed", "Warning");
                }
            }
            else
            {
                _roomManager.Update(roomName.Text, Convert.ToDouble(price.Text), Convert.ToDouble(squareMeters.Text),
                    Convert.ToInt32(maxNumGuests.Text),
                    standardComboBox.GetItemText(this.standardComboBox.SelectedItem), this.comment.Text, state, beds, meals,
                    facilitiesEnumList);
                InformationPopup.ShowDialog("Room updated.", "Information");
            }
        }

        private void FillMealsComboBox()
        {
            foreach (var meal in Enum.GetNames(typeof(Meals)))
            {
                mealsComboBox.Items.Add(meal);
            }
        }

        private void FillFacilitiesComboBox()
        {
            foreach (var facility in Enum.GetNames(typeof(RoomFacilities)))
            {
                facilitiesComboBox.Items.Add(facility);
            }

        }

        private void FillTypesOfBedComboBox()
        {
            foreach (var bed in Enum.GetNames(typeof(BedType)))
            {
                typesOfBedComboBox.Items.Add(bed);
            }
        }

        private void FillStandardComboBox()
        {
            foreach (var standard in Enum.GetNames(typeof(RoomStandard)))
            {
                standardComboBox.Items.Add(standard);
            }
        }

        private void addBedTypeButton_Click(object sender, EventArgs e)
        {
            typesOfBedList.Items.Add((BedType)typesOfBedComboBox.SelectedIndex);
        }

        private void addMealButton_Click(object sender, EventArgs e)
        {
            mealsList.Items.Add((Meals)mealsComboBox.SelectedIndex);
        }

        private void addFacilityButton_Click(object sender, EventArgs e)
        {
            facilitiesList.Items.Add((RoomFacilities)facilitiesComboBox.SelectedIndex);
        }

        private void facilitiesList_DoubleClick(object sender, EventArgs e)
        {
            facilitiesList.Items.Remove(facilitiesList.SelectedItem);
        }

        private void mealsList_DoubleClick(object sender, EventArgs e)
        {
            mealsList.Items.Remove(mealsList.SelectedItem);
        }

        private void typesOfBedList_SelectedIndexChanged(object sender, EventArgs e)
        {
            typesOfBedList.Items.Remove(typesOfBedList.SelectedItem);
        }

        private void FillWithRoomInformation(Room room)
        {
            this.price.Text = room.price.ToString();
            this.squareMeters.Text = room.squareMeterage.ToString();
            this.maxNumGuests.Text = room.maxGuestNumber.ToString();
            this.roomName.Text = room.roomNumber;
            this.standardComboBox.SelectedIndex = (int)room.roomStandard;
            this.comment.Text = room.comment;
            if (room.roomState == RoomState.OutOfUse)
            {
                this.isOutOfService.Checked = true;
            }

            foreach(var bed in room.beds)
            {
                this.typesOfBedList.Items.Add(bed.ToString());
            }

            foreach (var meal in room.mealsProvided)
            {
                this.mealsList.Items.Add(meal.ToString());
            }

            foreach (var facility in room.facilitiesProvided)
            {
                this.facilitiesList.Items.Add(facility.ToString());
            }
        }
    }
}