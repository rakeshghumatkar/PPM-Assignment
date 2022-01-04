package com.example.PPM.Model;

import java.sql.Date;
import java.time.LocalDate;
import java.util.HashSet;
import java.util.Set;
import javax.persistence.Entity;
import javax.persistence.FetchType;
import javax.persistence.GeneratedValue;
import javax.persistence.GenerationType;
import javax.persistence.Id;
import javax.persistence.JoinTable;
import javax.persistence.ManyToMany;
import javax.persistence.Table;

@Entity
@Table(name = "projects")
public class Project 
{
	@Id
	@GeneratedValue(strategy = GenerationType.IDENTITY)
	private int projectId;
	
	private String projectName;

	private String description;

	private Date startDate;

	private Date endDate;

	private LocalDate createDate;

	private LocalDate modifiedDate;
	
    @ManyToMany(fetch = FetchType.LAZY )
	@JoinTable
	(name = "project_employees", joinColumns = @javax.persistence.JoinColumn(name = "project_id"),
		inverseJoinColumns = @javax.persistence.JoinColumn(name = "employee_id"))
    private Set<Employee> employee = new HashSet<>();
	
	public Set<Employee> getEmployee() {
		return employee;
	}
	public void setEmployee(Set<Employee> employee) {
		this.employee = employee;
	}
	public int getProjectId() {
		return projectId;
	}
	public void setProjectId(int projectId) {
		this.projectId = projectId;
	}
	public String getProjectName() {
		return projectName;
	}
	public void setProjectName(String projectName) {
		this.projectName = projectName;
	}
	public String getDescription() {
		return description;
	}
	public void setDescription(String description) {
		this.description = description;
	}
	public Date getStartDate() {
		return startDate;
	}
	public void setStartDate(Date startDate) {
		this.startDate = startDate;
	}
	public Date getEndDate() {
		return endDate;
	}
	public void setEndDate(Date endDate) {
		this.endDate = endDate;
	}

	
	public LocalDate getCreateDate() {
		return createDate;
	}
	public void setCreateDate(LocalDate createDate) {
		this.createDate = createDate;
	}
	public LocalDate getModifiedDate() {
		return modifiedDate;
	}
	public void setModifiedDate(LocalDate modifiedDate) {
		this.modifiedDate = modifiedDate;
	}
	
	
	
	
	public Project(int projectId, String projectName, String description, Date startDate, Date endDate) {
		super();
		this.projectId = projectId;
		this.projectName = projectName;
		this.description = description;
		this.startDate = startDate;
		this.endDate = endDate;
	}
	
	
	
	
	
	public Project(String projectName, String description, Date startDate, Date endDate, LocalDate createDate,
			LocalDate modifiedDate, Set<Employee> employee) {
		super();
		this.projectName = projectName;
		this.description = description;
		this.startDate = startDate;
		this.endDate = endDate;
		this.createDate = createDate;
		this.modifiedDate = modifiedDate;
		this.employee = employee;
	}
	
	
	public Project() {}
	
	
	@Override
	public String toString() {
		return "Project [projectId=" + projectId + ", projectName=" + projectName + ", description=" + description
				+ ", startDate=" + startDate + ", endDate=" + endDate + ", createDate=" + createDate + ", modifiedDate="
				+ modifiedDate + ", employee=" + employee + "]";
	}
	
	
	
	
	
	

}
