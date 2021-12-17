using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

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
        }


        private void confirmButton_Click(object sender, EventArgs e)
        {
            //brak konstruktora room
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
