package com.example.PPM.Model;

import java.util.HashSet;
import java.util.Set;

import javax.persistence.CascadeType;
import javax.persistence.Column;
import javax.persistence.Entity;
import javax.persistence.FetchType;
import javax.persistence.GeneratedValue;
import javax.persistence.GenerationType;
import javax.persistence.Id;
import javax.persistence.JoinColumn;
import javax.persistence.OneToMany;
import javax.persistence.OneToOne;
import javax.persistence.Table;

@Entity
@Table(name = "roles")
public class Role 
{
	@Id
	@GeneratedValue(strategy = GenerationType.IDENTITY)
	@Column(name = "role_id")
	public int roleId;
	@Column(name = "role_name")
	public String roleName;
	
	
	@OneToMany(fetch = FetchType.LAZY )
	private Set<Employee> employee = new HashSet<>();
	 
	public Set<Employee> getEmployee() {
		return employee;
	}
	public void setEmployee(Set<Employee> employee) {
		this.employee = employee;
	}
	
	public int getRoleId() {
		return roleId;
	}
	public void setRoleId(int roleId) {
		this.roleId = roleId;
	}
	public String getRoleName() {
		return roleName;
	}
	public void setRoleName(String roleName) {
		this.roleName = roleName;
	}
	
	public Role() {}
	
	public Role( String roleName) {
		super();
		this.roleName = roleName;
	}
	
	
	
	public Role(String roleName, Set<Employee> employee) {
		super();
		this.roleName = roleName;
		this.employee = employee;
	}
	
	@Override
	public String toString() {
		return "" + roleName + "";
	}

}
