using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Windows.Forms.VisualStyles;
using Manager;
using RoomReservationSystem;
using RoomReservationSyster;

namespace RoomReservationSystem.UserInterface
{
    public partial class FormNewRoom : Form
    {
        private FormMode _mode;
        public FormNewRoom(FormMode mode)
        {
            InitializeComponent();
            _mode = mode;
            FillMealsComboBox();
            FillFacilitiesComboBox();
            FillTypesOfBedComboBox();
            FillStandardComboBox();
            _roomManager = new RoomManager();
        }
        private RoomManager _roomManager;
        
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

            if (_mode == FormMode.NewElement)
            {
                _roomManager.Insert(roomName.Text, Convert.ToDouble(price.Text), Convert.ToDouble(squareMeters.Text),
                    Convert.ToInt32(maxNumGuests.Text), beds, meals, facilitiesEnumList,
                    standardComboBox.GetItemText(this.standardComboBox.SelectedItem));
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
    }
}